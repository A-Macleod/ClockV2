
using ClockV2.Model;
using PriorityQueue;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace ClockV2
{
    public class AlarmPresenter
    {

        private readonly AlarmView _view;
        private readonly AlarmModel _model;
        private Timer _counter;
        private int headTime;



        public AlarmPresenter(AlarmView _view, AlarmModel _model)
        {
            this._view = _view;
            this._model = _model;

            // Link the View to this Presenter
            _view.SetPresenter(this);       
        }



        public void ShowAlarms()
        {
            try
            {
                string alarms = _model.ShowAlarms();
                _view.ShowAlarms(alarms);
            }
            catch (Exception ex)
            {
                _view.ShowAlarms("The Queue is Empty");
            }     
        }



        public void AddAlarm(string alarmName, string priorityHour, string priorityMinute, string priortiySecond)
        {
            int hours = 0;
            int minutes = 0;
            int seconds = 0;

            try
            {
                if (string.IsNullOrWhiteSpace(alarmName))
                {
                    _view.ShowError("Name not Valid");
                    return;
                }

                if (!int.TryParse(priorityHour, out hours))
                { 
                    _view.ShowError("Number not Valid");
                    return;

                }

                if (!int.TryParse(priorityMinute, out minutes))
                {
                    _view.ShowError("Number not Valid");
                    return;
                }

                if (!int.TryParse(priortiySecond, out seconds))
                {
                    _view.ShowError("Number not Valid");
                    return;
                }

                if (hours == 0 && minutes == 0 && seconds == 0 )
                {
                    _view.ShowError("Time not Valid");
                    return;
                }

                int AlarmTimeInSeconds = (hours * 3600) + (minutes * 60) + seconds;

                _model.AddAlarm(alarmName, AlarmTimeInSeconds);

                ShowAlarms();   // update the ui with the alarm
                HeadTime();     // update the ui with the first alarm time to countdown from

            }
            catch (Exception ex)
            {
                _view.ShowError(ex.Message);
            }
        }



        public void RemoveAlarm()
        {
            try
            {
                if (_counter.Enabled)
                {
                    _counter.Stop(); 
                    _view.EnableStartButton();
                }
                 
                _model.RemoveAlarm();
                ShowAlarms();
                HeadTime();
                           
            }
            catch (Exception ex)
            {               
                _view.ShowAlarms(ex.Message);
            }
        }



        public void HeadTime()
        {
            try
            {
                int headAlarmTime = _model.HeadCountdownTime();
                _view.ViewCountdownTime(headAlarmTime);

                if (headAlarmTime == null)
                {

                    _view.ViewCountdownNull(headAlarmTime.ToString());
                }

            }
            catch (Exception ex)
            {
                _view.ViewCountdownNull(ex.Message);
            }
        }



        public void StartAlarm()
        {
            try
            {
                _model.StartAlarm();
                HeadCountdownTime();    // Get the number for the countdown display and create a timed event

            }
            catch (Exception ex)
            {
                _view.ShowAlarms(ex.Message);
            }           
        }


        // https://learn.microsoft.com/en-us/dotnet/api/system.timers.timer?redirectedfrom=msdn&view=netframework-4.8
        public void HeadCountdownTime()
        {
            //headTime = _model.HeadCountdownTime();
            //currentHead = headTime;

            _counter = new System.Windows.Forms.Timer();
            _counter.Interval = 1000;
            _counter.Tick += CountdownToUI_Tick;
            _counter.Start();

        }



        private void CountdownToUI_Tick(object sender, EventArgs e)
        {
            try
            {
                //headTime = _model.HeadCountdownTime();
                //headTime--;
                //_view.ViewCountdownTime(headTime);


                // return the head time each tick instead
                headTime = _model.HeadCountdownTime();
                int headMinusOne = headTime - 1;
                _view.ViewCountdownTime(headMinusOne);

                if (_counter.Enabled == true)
                {
                    if (headTime <= 0)
                    {
                        _counter.Stop();
                        _counter.Tick -= CountdownToUI_Tick; // unsubscribe from the event
                        _counter.Dispose();
                        RemoveAlarm();
                        _view.EnableStartButton();

                    }
                    else
                    {
                        _view.DisableStartButton();
                    }
                }


            }
            catch (Exception ex)
            {
                _view.ViewCountdownNull(ex.Message);
            }
        }


    }
}

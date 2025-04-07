
using ClockV2.Model;
using PriorityQueue;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
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
            string alarms = _model.ShowAlarms();
            _view.ShowAlarms(alarms);
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
                ShowAlarms();
                HeadTime();


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
                _model.RemoveAlarm();
                ShowAlarms();
                HeadTime();
            }
            catch (Exception ex)
            {             
                _view.ShowAlarms(ex.Message);
            }
        }



        public void StartAlarm()
        {
            try
            {
                _model.StartAlarm();
                HeadCountdownTime();    // Get the number for the countdown display and create a timer

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

                if (headAlarmTime == null)
                {

                    _view.ViewCountdownNull(headAlarmTime.ToString());
                }

                _view.ViewCountdownTime(headAlarmTime);

            }
            catch (Exception ex)
            {               
                _view.ViewCountdownNull(ex.Message);
            }

            
        }




        public void HeadCountdownTime()
        {
            headTime = _model.HeadCountdownTime();          

            _counter = new System.Windows.Forms.Timer();
            _counter.Interval = 1000;
            _counter.Tick += CountdownToUI_Tick;

            _counter.Start();            
        }



        private void CountdownToUI_Tick(object sender, EventArgs e)
        {
            int initialValue = headTime;

            headTime--;

            _view.ViewCountdownTime(headTime);

            if (headTime <= 0)
            {
                _counter.Stop();
                _counter.Dispose();
            }

        }

        //private void CountdownToUI_Tick(object sender, EventArgs e)
        //{
        //    //int initialTime = _model.HeadCountdownTime();
        //    //int time = initialTime;
        //    time--;

        //    if (time >= 0)
        //    {
        //        time--;
        //        _view.ViewCountdownTime(time);
                
        //    }
        //    else
        //    {
        //        _counter.Stop();
        //        _counter.Dispose();
        //    }     
            
        //}



        //// https://learn.microsoft.com/en-us/dotnet/api/system.timers.timer?redirectedfrom=msdn&view=netframework-4.8
        //public void AlarmTimer(int AlarmTimeInSeconds)
        //{

        //    int counter = AlarmTimeInSeconds;

        //    Timer countdownTimer = new Timer();
        //    countdownTimer.Interval = 1000; // 1 second
        //    countdownTimer.Tick += CountdownTimer_Tick;

        //    countdownTimer.Start();

        //    _model.AlarmCountdownTimer(AlarmTimeInSeconds);
        //    _view.Countdown(AlarmTimeInSeconds);
        //}



        //private void CountdownTimer_Tick(object sender, EventArgs e)
        //{

        //    if (counter >= 0)
        //    {

        //        _view.Countdown(counter);
        //        counter--;
        //    }
        //    //throw new NotImplementedException();
        //    else
        //    {
        //        // remove the item from the queue 

        //        countdownTimer.Stop();
        //        countdownTimer.Dispose();
        //        return;
        //    }
        //}







    }
}

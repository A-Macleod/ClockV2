
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

namespace ClockV2
{

    public class AlarmPresenter
    {
        private readonly AlarmView _view;
        private readonly AlarmModel _model;

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
                
            }
            catch (Exception ex)
            {
                _view.ShowAlarms(ex.Message);
            }           
        }




        //   TESTING MAYBE REMOVE UNLESS WE CAN GET EVENT HANDLER TO WORK 
        public void HeadCountdownTime()
        {
            int time = _model.HeadCountdownTime();
            _view.HeadCountdownTime(time);
        }



        //// https://learn.microsoft.com/en-us/dotnet/api/system.timers.timer?redirectedfrom=msdn&view=netframework-4.8
        public void ViewAlarmCounter(int AlarmTimeInSeconds)
        {

            int counter = AlarmTimeInSeconds;


            Timer Timer = new System.Windows.Forms.Timer();
            Timer.Interval = 1000;
            Timer.Tick += CountdownToUI;

        }

        public void CountdownToUI(object sender, EventArgs e)
        {
            
        }




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

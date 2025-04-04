
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


                int AlarmTimeInSeconds = (hours * 3600) + (minutes * 60) + seconds; // converting to seconds


                _model.AddAlarm(alarmName, AlarmTimeInSeconds);
                ShowAlarms();                                                       // Updates the view with the Alarms
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
                ShowAlarms();   // Update the view with the Alarms
            }
            catch (Exception ex)
            {

                _view.ShowAlarms(ex.Message);
            }
        }



        public void StartAlarm()
        {

        }



        public void ShowAlarms()
        {
            string alarms = _model.ShowAlarms();
            _view.ShowAlarms(alarms);
        }



        //public void AlarmTimer(int AlarmTimeInSeconds)
        //{

        //    int counter = AlarmTimeInSeconds;

        //    Timer countdownTimer = new Timer();
        //    countdownTimer.Interval = 1000; // 1 second
        //    countdownTimer.Tick += CountdownTimer_Tick;

        //    countdownTimer.Start();

        //    //_model.AlarmCountdownTimer(AlarmTimeInSeconds);
        //    //_view.Countdown(AlarmTimeInSeconds);
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

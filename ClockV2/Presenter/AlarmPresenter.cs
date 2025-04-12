
using ClockV2.Model;
using PriorityQueue;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
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

        private readonly IView _view;
        private readonly AlarmModel _model;

        private new System.Windows.Forms.Timer _counter;
        private int headTime;

        //private Alarm _alarm;
        //public event EventHandler Alarm_Countdown_Tick;




        public AlarmPresenter(IView _view, AlarmModel _model)
        {
            this._view = _view;
            this._model = _model;

            // Link the View to this Presenter
            _view.SetPresenter(this);

            // Completely Decoupled
            _view.Button_Add_Alarm_Click += OnButtonAddAlarmClicked;
            _view.Button_Remove_Alarm_Click += OnButtonRemoveAlarmClicked;
            _view.Button_Start_Timer_Click += OnButtonStartTimerClicked;

            _model.AlarmCreatedInModel += OnAlarmCreatedInModel;


            // Instantiate with _counter
            //_counter = new System.Windows.Forms.Timer();
            //_counter.Interval = 1000;
            //_counter.Tick += CountdownToUI_Tick;
        }



        // Completely Decoupled
        private void OnButtonAddAlarmClicked(object sender, (string alarmName, string priorityHour, string priorityMinute, string priortiySecond) e)
        {
            AddAlarm(e.alarmName, e.priorityHour, e.priorityMinute, e.priortiySecond);
        }


        private void OnButtonRemoveAlarmClicked(object sender, EventArgs e)
        {
            RemoveAlarm();
            HeadTime();
        }


        private void OnButtonStartTimerClicked(object sender, EventArgs e)
        {
            ShowAlarms();
            HeadTime();
            StartAlarm();
        }



        private void OnAlarmCreatedInModel(object sender, Alarm newAlarm)
        {
            newAlarm.Alarm_Countdown_Tick += OnAlarmCountdownTick;
            newAlarm.Alarm_Triggered += OnAlarmTriggered;
        }



        private void OnAlarmCountdownTick(object sender, TimeSpan remainingTimeLeft)
        {
            _view.ViewCountdownEventTimeLeft(remainingTimeLeft);
        }


        private void OnAlarmTriggered(object sender, string AlarmName)
        {
            _view.ShowAlarmCompleteMessageBox(AlarmName);
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
                //if (_counter.Enabled)
                //{
                //    _counter.Stop(); 
                //    _view.EnableStartButton();
                //}
                
                _model.RemoveAlarm();
                ShowAlarms();
                HeadTime();
                           
            }
            catch (Exception ex)
            {               
                _view.ShowAlarms(ex.Message);
            }
        }


        public void ShowAlarms()
        {
            try
            {
                string alarms = _model.ShowAlarms();
                _view.ShowAlarms(alarms);
            }
            catch (Exception)
            {
                _view.ShowAlarms("The Queue is Empty");
            }
        }



        public void StartAlarm()
        {
            try
            {
                
                _model.StartAlarm();
                
                //StartCounter();    // Get the number for the countdown display and create a timed event


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







        // https://learn.microsoft.com/en-us/dotnet/api/system.timers.timer?redirectedfrom=msdn&view=netframework-4.8
        public void StartCounter()
        {
            //headTime = _model.HeadCountdownTime();
            //currentHead = headTime;

            //_counter = new System.Windows.Forms.Timer();
            //_counter.Interval = 1000;
            //_counter.Tick += CountdownToUI_Tick;
            _counter.Start();

        }



        private void CountdownToUI_Tick(object sender, EventArgs e)
        {
            try
            {
                //headTime = _model.HeadCountdownTime();
                //headTime--;
                //_view.ViewCountdownTime(headTime);


                // return the head time each tick instead       // SOMETHING WRONG HERE
                headTime = _model.HeadCountdownTime();
                int headMinusOne = headTime - 1;
                _view.ViewCountdownTime(headMinusOne);

                if (_counter.Enabled)

                if (_counter.Enabled == true)

                if (_counter.Enabled == true)

                if (_counter.Enabled == true)

                if (_counter.Enabled == true)
                {
                    if (headTime <= 0)
                    {
                        _counter.Stop();
                        //_counter.Tick -= CountdownToUI_Tick; // unsubscribe from the event
                        //_counter.Dispose();
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






    }
}

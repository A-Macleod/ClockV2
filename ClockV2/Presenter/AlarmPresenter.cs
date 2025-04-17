﻿
using ClockV2.Model;
using ClockV2.Presenter;
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

        private readonly ClockPresenter _clockPresenter;



        public AlarmPresenter(IView _view, AlarmModel _model, ClockPresenter clockPresenter) // WE ADDED A REFERENCE TO THE CLOCKPRESENTER TO TEST INJECTION
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

            _clockPresenter = clockPresenter;

        }



        // Completely Decoupled
        private void OnButtonAddAlarmClicked(object sender, (string alarmName, string priorityHour, string priorityMinute, string priortiySecond) e)
        {
            AddAlarm(e.alarmName, e.priorityHour, e.priorityMinute, e.priortiySecond);
        }



        private void OnButtonRemoveAlarmClicked(object sender, EventArgs e)
        {
            RemoveAlarm();
            HeadCountdownTime();
        }



        private void OnButtonStartTimerClicked(object sender, EventArgs e)
        {
            
            ShowAlarms();
            HeadCountdownTime();
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
            RemoveAlarm();
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

                ShowAlarms();                   // Update the UI with the alarm
                HeadCountdownTime();            // Update the UI with the first alarm time to countdown from
                UpdateClockViewWithNextAlarm(); // Update the ClockView next alarm details, name & countdown timespan

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
                _model.ModelRemoveAlarm();
                ShowAlarms();
                HeadCountdownTime();
                UpdateClockViewWithNextAlarm();


            }
            catch (Exception ex)
            {               
                _view.ShowAlarms(ex.Message);
            }
        }



        /// <summary>
        /// Try get the head name and time, if its null, tell the clock UI to show that in the label
        /// </summary>
        public void UpdateClockViewWithNextAlarm()
        {
            try
            {
                string clockPresenterHeadName = _model.ShowHeadName();
                TimeSpan clockPresenterHeadTime = _model.ShowHeadTimeTimeSpan();
                _clockPresenter.AlarmPresenterNextAlarm(clockPresenterHeadName, clockPresenterHeadTime);    //  Sending the next alarm name and time to the clockView
            }
            catch (Exception ex)
            {
                _clockPresenter.AlarmPresenterNoAlarm();    //  Clear the ClockView next alarm Name and Time          
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
            }
            catch (Exception ex)
            {
                _view.ShowAlarms(ex.Message);
            }
        }



        public void HeadCountdownTime()
        {
            try
            {                
                TimeSpan headCountdownTime = _model.HeadCountdownTime();
                _view.ViewCountdownTime(headCountdownTime);

           
                if (headCountdownTime == null)
                {

                    _view.ViewCountdownNull(headCountdownTime.ToString());
                }
            }
            catch (Exception ex)
            {
                _view.ViewCountdownNull(ex.Message);
            }
        }


    }
}

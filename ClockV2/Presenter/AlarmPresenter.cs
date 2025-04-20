
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
    /// <summary>
    /// Class to represent the communication layer between the AlarmModel and Interface AlarmView in the MVP design pattern.
    /// This presenter layer is responsible for getting the TimeSpan from the AlarmModel to pass to the ClockPresenter and AlarmView and 
    /// to Return Alarm data from the AlarmModel that is also sent between the Clock and Alarm.
    /// </summary>
    public class AlarmPresenter
    {

        private readonly IView _view;
        private readonly AlarmModel _model;
        private readonly ClockPresenter _clockPresenter;


        /// <summary>
        /// Constructor that takes in an Interface AlarmView, AlarmModel and ClockPresenter argument. Calls the AlarmView and tells it
        /// that this AlarmPresenter is now the AlarmViews Presenter. Subscribes to AlarmView Button Click Events. Instantiated with a copy
        /// of the ClockPresenter to pass data back to it.
        /// </summary>
        /// <param name="_view">The AlarmView name</param>
        /// <param name="_model">The AlarmModel name</param>
        /// <param name="clockPresenter">The ClockPresenter</param>
        public AlarmPresenter(IView _view, AlarmModel _model, ClockPresenter clockPresenter)
        {
            this._view = _view;
            this._model = _model;
            
            _view.SetPresenter(this);       // Link the View to this Presenter

            _view.Button_Add_Alarm_Click += OnButtonAddAlarmClicked;
            _view.Button_Remove_Alarm_Click += OnButtonRemoveAlarmClicked;
            _view.Button_Start_Timer_Click += OnButtonStartTimerClicked;
            
            _model.AlarmCreatedInModel += OnAlarmCreatedInModel;            // AlarmModel Event

            _clockPresenter = clockPresenter;
        }



        /// <summary>
        /// Method Eventhandler that takes in Alarm Name, Hours, Minutes, Seconds as a tuple argument from the AlarmView button click event. Then calls
        /// the AddAlarm method with the tuple as its argument.
        /// </summary>
        /// <param name="sender">The object that raised the event</param>
        /// <param name="e">The argument information</param>
        private void OnButtonAddAlarmClicked(object sender, (string alarmName, string priorityHour, string priorityMinute, string priortiySecond) e)
        {
            AddAlarm(e.alarmName, e.priorityHour, e.priorityMinute, e.priortiySecond);
        }



        /// <summary>
        /// Method Eventhandler that when the Remove Alarm button is clicked, calls the RemoveAlarm and HeadCountdownTime methods. To Remove the Alarm 
        /// and update the AlarmView countdown label 
        /// </summary>
        /// <param name="sender">The object that raised the event</param>
        /// <param name="e">The argument information</param>
        private void OnButtonRemoveAlarmClicked(object sender, EventArgs e)
        {
            RemoveAlarm();
            //HeadCountdownTime();
        }



        /// <summary>
        /// Method Eventhandler that on StartTimer button click, updates the AlarmView with the Head Alarm and Head Time 
        /// </summary>
        /// <param name="sender">The object that raised the event</param>
        /// <param name="e">The argument information</param>
        private void OnButtonStartTimerClicked(object sender, EventArgs e)
        {        
            ShowAlarms();
            HeadCountdownTime();
            StartAlarm();
        }


        /// <summary>
        /// Method Eventhandler that when a New Alarm is created it is passed from the AlarmModel to the AlarmPresenter and subscribed to 
        /// the Alarm_Countdown_Tick and Alarm_Triggered Eventhandler methods
        /// </summary>
        /// <param name="sender">The object that raised the event</param>
        /// <param name="newAlarm">The newAlarm object from AlarmModel</param>
        private void OnAlarmCreatedInModel(object sender, Alarm newAlarm)
        {
            newAlarm.Alarm_Countdown_Tick += OnAlarmCountdownTick;
            newAlarm.Alarm_Triggered += OnAlarmTriggered;
        }



        /// <summary>
        /// Method Eventhandler that on Alarm Tick calls the AlarmView and ClockPresenter to update the remainingTimeLeft on the Alarm Time. 
        /// Uses remainingTimeLeft as an argument.
        /// </summary>
        /// <param name="sender">The object that raised the event</param>
        /// <param name="remainingTimeLeft">The Alarm Time remainingTimeLeft on each Tick Event</param>
        private void OnAlarmCountdownTick(object sender, TimeSpan remainingTimeLeft)
        {
            _view.ViewCountdownEventTimeLeft(remainingTimeLeft);
            _clockPresenter.ClockViewCountdownEventTimeLeft(remainingTimeLeft);
        }



        /// <summary>
        /// Method Eventhandler that calls the AlarmView with the Alarm Name as an argument when the OnAlarmTriggered Event is triggered.
        /// Then calls the RemoveAlarm function to remove and dispose of the completed Alarm.
        /// </summary>
        /// <param name="sender">The object that raised the event</param>
        /// <param name="AlarmName">The Name of the Alarm thats dueTime has reached Zero</param>
        private void OnAlarmTriggered(object sender, string AlarmName)
        {
            _view.ShowAlarmCompleteMessageBox(AlarmName);
            RemoveAlarm();
        }



        /// <summary>
        /// Method that takes in Alarm Name, Hour, Minute, Second as an argument from the AlarmView. Parses the string values into an
        /// integer and if not calls the AlarmView to display the dialog MessageBox with the error. Converts the parsed times into seconds then 
        /// calls the AlarmModel with the Alamr Name and new time in seconds to be Added Updates the AlarmView and ClockView with the Alarm name and Time.
        /// Throws exception error message in dialog MessageBox
        /// </summary>
        /// <param name="alarmName">The Name of the Alarm</param>
        /// <param name="priorityHour">The Hours from the numericupDown</param>
        /// <param name="priorityMinute">The Minutes from the numericupDown</param>
        /// <param name="priortiySecond">The Seconds from the numericupDown</param>
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

                ShowAlarms();                   // Update the UI with the alarm, AlarmView debugging
                HeadCountdownTime();            // Update the UI with the first alarm time to countdown from
                UpdateClockViewWithNextAlarm(); // Update the ClockView next alarm details, name & countdown timespan

            }
            catch (Exception ex)
            {
                _view.ShowError(ex.Message);
            }
        }



        /// <summary>
        /// Method to call the RemoveAlarm method in the AlarmModel. Then update the Alarms Name and Times in the AlarmView and ClockView
        /// </summary>
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
        /// Method to try get the Head of the SortedArrayPriorityQueue Name and Time and call the ClockPresenter with it, If its null, tell the ClockView UI
        /// to show that there is no Alarm and to make the Alarm time Null
        /// </summary>
        public void UpdateClockViewWithNextAlarm()
        {
            try
            {
                string clockPresenterHeadName = _model.ShowHeadName();
                TimeSpan clockPresenterHeadTime = _model.ShowHeadTimeTimeSpan();
                _clockPresenter.AlarmPresenterNextAlarmName(clockPresenterHeadName);    //  Sending the next Alarm Name and Time to the ClockView
                _clockPresenter.AlarmPresenterNextAlarmTime(clockPresenterHeadTime);
            }
            catch (Exception)
            {
                _clockPresenter.AlarmPresenterNoAlarm();    //  Clear the ClockView next Alarm Name and Time          
            }
        }



        /// <summary>
        /// Method to return the Alarms from the SortedArrayPrioirtyQueue as a string to be displayed in the AlarmView. 
        /// If the queue is empty throw an exception and display the queue is empty in the label box in the AlarmView
        /// </summary>
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



        /// <summary>
        /// Method to call the AlarmModel and start the Timer on the Head Alarm.
        /// If the queue is empty throw an exception and display the error message in the label box in the AlarmView
        /// </summary>
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



        /// <summary>
        /// Method to return the Head Alarm Time and update the AlarmView with the Time
        /// </summary>
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

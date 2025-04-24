using ClockV2.Presenter;
using PriorityQueue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace ClockV2
{
    /// <summary>
    /// Class to represent the data and business logic layer for the Alarm in the MVP design pattern.
    /// This class handles returning the Date and Time, for the AlarmView, as well as manipulating the 
    /// Alarm objects inside the SortedArrayPriorityQueue. It does not interact with the 
    /// AlarmView directly but instead is called from the AlarmPresenter that acts as the middleman to 
    /// pass data between the AlarmModel and AlarmView.
    /// </summary>
    public class AlarmModel
    {

        private readonly SortedArrayPriorityQueue<Alarm> _alarms;

        public event EventHandler<Alarm> AlarmCreatedInModel;   // Pass newAlarms to the AlarmPresenter for use


        /// <summary>
        /// Constructor that takes in no arguments. When the AlarmModel is instantiated creates a new SortedArrayPriorityQueue
        /// with 4 index positions, called _alarms, that is ready to use
        /// </summary>
        public AlarmModel()
        {
            _alarms = new SortedArrayPriorityQueue<Alarm>(4);
        }



        /// <summary>
        /// Method that returns the Alarm Time of Head of the SortedArrayPriorityQueue, converted to TimeSpan
        /// </summary>
        /// <returns>The TimeSpan of the Head Item Alarm Time</returns>
        public TimeSpan HeadCountdownTime()
        {           
            var countdownTime = _alarms.Head().AlarmTime;

            TimeSpan countdownTimeTimeSpan = TimeSpan.FromSeconds(countdownTime);

            return countdownTimeTimeSpan;

            // https://stackoverflow.com/questions/463642/how-can-i-convert-seconds-into-hourminutessecondsmilliseconds-time
        }



        /// <summary>
        /// Method to Add an Alarm to the SortedArrayPriorityQueue. Takes in an Alarm Name and Alarm Time in seconds and calculates the Priority of the Alarm,
        /// based on the Time difference between Now and Tomorrow Midnight. Priority is the seconds from Tomorrows Midnight 00:00 minus the DateTime.now.
        /// This way the Alarms with the highest priority are the ones that are created the earliest in the day and thus served first, as the time difference in
        /// seconds is larger
        /// </summary>
        /// <param name="alarmName"></param>
        /// <param name="AlarmTimeInSeconds"></param>
        public void AddAlarm(string alarmName, int AlarmTimeInSeconds)
        {
            // Calculate Priority
            DateTime timeNow = DateTime.Now;                    
            DateTime midnight = DateTime.Now.Date.AddDays(1);   // This will be for Tomorrows midnight, as midnight is the beginning of the day, 00:00
            TimeSpan timeDifferenceMidnightToNow = midnight - timeNow;  
            int timeDiffereneceInSecondsPriority = (int)timeDifferenceMidnightToNow.TotalSeconds;    

            // Create New Alarm and Add to Queue with Priority
            var newAlarm = new Alarm(alarmName, AlarmTimeInSeconds);
            _alarms.Add(newAlarm, timeDiffereneceInSecondsPriority);

            // Pass this newAlarm to the AlarmPresenter
            AlarmCreatedInModel?.Invoke(this, newAlarm);        
        }



        /// <summary>
        /// Method to Stop the Head Alarm Countdown, unsubscribe to the Tick event and Dispose of the Alarm. 
        /// Finally Removing the Head Alarm from the Head of the SortedArrayPriorityQueue
        /// </summary>
        public void ModelRemoveAlarm()
        {
            _alarms.Head().StopCountdownAndDispose();   
            _alarms.Remove();                        
        }



        /// <summary>
        /// Method to Return all Alarms and their Priority in the SortedArrayPriorityQueue
        /// </summary>
        /// <returns>The Alarms and Priorities in the SortedArrayPriorityQueue</returns>
        public string ShowAlarms()
        {
            return _alarms.ToString();
        }



        /// <summary>
        /// Method to Return the Head Items Name in the SortedArrayPriorityQueue
        /// </summary>
        /// <returns>The Head items Name</returns>
        public string ShowHeadName()
        {
            return _alarms.Head().AlarmName;
        }



        /// <summary>
        /// Method to Return the Head Items Time in the SortedArrayPriorityQueue
        /// </summary>
        /// <returns>The Head items Alarm Time, in TimeSpan format</returns>
        public TimeSpan ShowHeadTimeTimeSpan()
        {
            var headTime = _alarms.Head().AlarmTime;
            TimeSpan headTimeTimeSpan = TimeSpan.FromSeconds(headTime);
            return headTimeTimeSpan;
        }



        /// <summary>
        /// Method to Start the Alarm Tick event on the Head Item in the SortedArrayPriorityQueue
        /// </summary>
        public void StartAlarm()        
        {
            _alarms.Head().StartCountdown();    // Start the countdown for the length of the heads time
        }

    }
}

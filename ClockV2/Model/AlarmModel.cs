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
    /// 
    /// </summary>
    public class AlarmModel
    {

        private SortedArrayPriorityQueue<Alarm> _alarms;

        public event EventHandler<Alarm> AlarmCreatedInModel;   // Pass this newAlarm to the presenter for use



        /// <summary>
        /// Constructor, so that when the Model is created, there is a SAPQ ready to use
        /// </summary>
        public AlarmModel()
        {
            _alarms = new SortedArrayPriorityQueue<Alarm>(4);
        }



        // https://stackoverflow.com/questions/463642/how-can-i-convert-seconds-into-hourminutessecondsmilliseconds-time
        public TimeSpan HeadCountdownTime()
        {           
            var countdownTime = _alarms.Head().AlarmTime;

            TimeSpan countdownTimeTimeSpan = TimeSpan.FromSeconds(countdownTime);

            return countdownTimeTimeSpan;
        }



        public void AddAlarm(string alarmName, int AlarmTimeInSeconds)
        {

            // Priority is the seconds from Tomorrows Midnight 00:00 - the DateTime.now
            // This way the Alarms with the highest priority are the ones that are created the earliest in the day and thus served first


            DateTime timeNow = DateTime.Now;                    // current time 13/04/2025 15:00
            DateTime midnight = DateTime.Now.Date.AddDays(1);   // this will be for Tomorrows midnight, as midnight is the beginning of the day, 14/04/2025 00:00

            TimeSpan timeDifferenceMidnightToNow = midnight - timeNow;  
            int TimeDifferneceInSeconds = (int)timeDifferenceMidnightToNow.TotalSeconds;    // 9H x 3600 Seconds = 32400s

            // Debug
            //Console.WriteLine("Time Now:  " + timeNow);
            //Console.WriteLine("Midnight: " + midnight);
            //Console.WriteLine("Time Difference in Seconds: " + TimeDifferneceInSeconds);


            var newAlarm = new Alarm(alarmName, AlarmTimeInSeconds);
            _alarms.Add(newAlarm, TimeDifferneceInSeconds);     // using the Timespan as the priority, the earlier the alarm is made the higher the priority


            AlarmCreatedInModel?.Invoke(this, newAlarm);        // pass this newAlarm to the Presenter

        }



        public void ModelRemoveAlarm()
        {
            _alarms.Head().StopCountdownAndDispose();   
            _alarms.Remove();                        
        }



        public string ShowAlarms()
        {
            return _alarms.ToString();
        }



        public void StartAlarm()        
        {
            _alarms.Head().StartCountdown();    // Start the countdown for the length of the heads time
        }

    }
}

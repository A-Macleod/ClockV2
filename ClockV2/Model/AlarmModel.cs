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



        public int HeadCountdownTime()
        {           
            var countdownTime = _alarms.Head().AlarmTime;
            return countdownTime;
        }



        public void AddAlarm(string alarmName, int AlarmTimeInSeconds)
        {
            //int AlarmTimeInSeconds = (hours * 3600) + (minutes * 60) + seconds; // converting to seconds
            //TimeSpan currentTime = DateTime.Now.TimeOfDay;                      // current time without date
            //TimeSpan timeToAdd = new TimeSpan(hours, minutes, seconds);         // The amount of time to add to current time
            //TimeSpan alarmTime = currentTime.Add(timeToAdd);                    // add the currentTime to the timeToAdd

            var newAlarm = new Alarm(alarmName, AlarmTimeInSeconds);

            _alarms.Add(newAlarm, AlarmTimeInSeconds);

            AlarmCreatedInModel?.Invoke(this, newAlarm); // Event to pass this to the Presenter

        }



        public void RemoveAlarm()
        {
            _alarms.Head().StopCountdownAndDispose();   // stops alarm, unsubscribes from eventhandler and disposes of alarm
            _alarms.Remove();                           // removes head of the alarm queue
        }



        public string ShowAlarms()
        {
            return _alarms.ToString();
        }



        public void StartAlarm()        
        {

            //var head = _alarms.Head();
            //head.Alarm_Countdown_Tick += OnAlarmCountdownTick;


            _alarms.Head().StartCountdown();    // Start the countdown for the length of the heads time
            


            //if (_alarms.Head().AlarmTime == 0)     // if the timer has all ready been run and that alarm is at zero, delete it and then start the next
            //{

            //    RemoveAlarm();

            //}

            //_alarms.Head().StartCountdown(_alarms.Head().AlarmTime);    // Start the countdown for the length of the heads time

            //////
            // DEBUGGING 
            //////

            //_alarms.Head().StartCountdown(_alarms.Head().AlarmTime);    // Start the countdown for the length of the heads time

            //string head = _alarms.Head().ToString();
            //Console.WriteLine($"Head Name: {head}");    // Show Head of Queue Name

            //Console.WriteLine("=======");

            //int time = _alarms.Head().AlarmTime;
            //Console.WriteLine($"Head Time: {time}");    // Show Head of Queue Time

            //Console.WriteLine("=======");

            //string queue = _alarms.ToString();
            //Console.WriteLine(queue);                   // Print the Queue

            //Console.WriteLine("=======");

            //Console.WriteLine("Started Countdown:" + _alarms.Head());   // Start Countdown on Head
            //_alarms.Head().StartCountdown(time);

            //Console.WriteLine("=======");

            //var remainingAfterTimerHasTicked = _alarms.Head().AlarmTime;
            //Console.WriteLine($"Remanining After Tick: {remainingAfterTimerHasTicked}");    //  Remaining Time on Alarm. after Alarm has sounded on Alarm Object

            //Console.WriteLine("== END ==");

        }





    }
}

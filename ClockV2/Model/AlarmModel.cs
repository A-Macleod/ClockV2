using ClockV2.Presenter;
using PriorityQueue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace ClockV2
{
    /// <summary>
    /// 
    /// </summary>
    public class AlarmModel
    {

        private SortedArrayPriorityQueue<Alarm> _alarms = new SortedArrayPriorityQueue<Alarm>(8);
        //private Alarm newAlarm;


        public void AddAlarm(string alarmName, int AlarmTimeInSeconds)
        {

            //int AlarmTimeInSeconds = (hours * 3600) + (minutes * 60) + seconds; // converting to seconds
            //TimeSpan currentTime = DateTime.Now.TimeOfDay;                      // current time without date
            //TimeSpan timeToAdd = new TimeSpan(hours, minutes, seconds);         // The amount of time to add to current time
            //TimeSpan alarmTime = currentTime.Add(timeToAdd);                    // add the currentTime to the timeToAdd

             Alarm newAlarm = new Alarm(alarmName, AlarmTimeInSeconds);
            _alarms.Add(newAlarm, AlarmTimeInSeconds); // The Alarm with the longest time will be the Highest Priority and the Head of the Queue

        }


        public void RemoveAlarm()
        {
            _alarms.Head().StopCountdown();
            _alarms.Remove();               // Remove the Head of the Queue    
        }


        public string ShowAlarms()
        {

            return _alarms.ToString();
        }


        public void StartAlarm()        
        {

            // THE TIMER IS CREATING A NEW INSTANCE OF THE TIMER, AND COUNTING DOWN THE TIME FIELD TO ZERO
            // WE NEED TO REMOVE THE ALARM FROM THE QUEUE AFTER IT REACHES ZERO

            // Check if the Head Time is Zero, If so remove Alarm from the queue. If we try to run alarm
            // twice, after it has Countdown to zero, the message pop-up will alert immedately. On each
            // tick of the Countdown we are minusing that Alarms field time.

            // IT SHOULD BE REMOVED WHEN THE POPUP GOES OFF, WE SHOULD NOT HAVE TO PRESS "STARTALARM" AGAIN TO REMOVE IT 

            //if (_alarms.Head().AlarmTime == 0)     // If the timer has all ready been run and that alarm is at zero, delete it and then star the next
            //{

            //    RemoveAlarm();
                
                
            //}
            //else
            //{
            //    //ShowAlarms(); // Update the UI
            //    _alarms.Head().StartCountdown(_alarms.Head().AlarmTime);    // Start the countdown for the length of the heads time

            //}


            _alarms.Head().StartCountdown(_alarms.Head().AlarmTime);    // Start the countdown for the length of the heads time

            string head = _alarms.Head().ToString();
            Console.WriteLine($"Head Name: {head}");    // Show Head of Queue Name

            Console.WriteLine("=======");

            int time = _alarms.Head().AlarmTime;
            Console.WriteLine($"Head Time: {time}");    // Show Head of Queue Time

            Console.WriteLine("=======");

            string queue = _alarms.ToString();
            Console.WriteLine(queue);                   // Print the Queue

            Console.WriteLine("=======");

            Console.WriteLine("Started Countdown:" + _alarms.Head());   // Start Countdown on Head
            _alarms.Head().StartCountdown(time);

            Console.WriteLine("=======");

            var remainingAfterTimerHasTicked = _alarms.Head().AlarmTime;
            Console.WriteLine($"Remanining After Tick: {remainingAfterTimerHasTicked}");    //  Remaining Time on Alarm. after Alarm has sounded on Alarm Object

            Console.WriteLine("== END ==");

        }


        //// https://learn.microsoft.com/en-us/dotnet/api/system.timers.timer?redirectedfrom=msdn&view=netframework-4.8
        //public void alarmcountdowntimer(int alarmtimeinseconds)
        //{
        //    // create the timer in seconds 
        //    System.Timers.Timer timer;
        //    timer = new System.Timers.Timer(alarmtimeinseconds * 1000);

        //    // hook up the elapsed event for the timer
        //    timer.Elapsed += ontimedevent;
        //    timer.AutoReset = false;
        //    timer.Enabled = true;
        //}

        //private static void ontimedevent(object source, ElapsedEventArgs e)
        //{

        //}

    




    }
}

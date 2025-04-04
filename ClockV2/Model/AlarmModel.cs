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

        public void AddAlarm(string alarmName, int AlarmTimeInSeconds)
        {

            //int AlarmTimeInSeconds = (hours * 3600) + (minutes * 60) + seconds; // converting to seconds
            //TimeSpan currentTime = DateTime.Now.TimeOfDay;                      // current time without date
            //TimeSpan timeToAdd = new TimeSpan(hours, minutes, seconds);         // The amount of time to add to current time
            //TimeSpan alarmTime = currentTime.Add(timeToAdd);                    // add the currentTime to the timeToAdd



            Alarm newAlarm = new Alarm(alarmName, AlarmTimeInSeconds);
            _alarms.Add(newAlarm, AlarmTimeInSeconds);

            newAlarm.StartCountdown();

            //newAlarm.startCountdown();
            
            //AlarmTimer(AlarmTimeInSeconds);

        }


        public string ShowAlarms()
        {
            return _alarms.ToString();
        }




    //    public void AlarmCountdownTimer(int AlarmTimeInSeconds)
    //    {


    //        // https://learn.microsoft.com/en-us/dotnet/api/system.timers.timer?redirectedfrom=MSDN&view=netframework-4.8
    //        // Create the timer in seconds 
    //        System.Timers.Timer timer;
    //        timer = new System.Timers.Timer(AlarmTimeInSeconds * 1000);

    //        // Hook up the Elapsed event for the timer
    //        timer.Elapsed += OnTimedEvent;
    //        timer.AutoReset = false;
    //        timer.Enabled = true;
    //    }

    //    private static void OnTimedEvent(Object source, ElapsedEventArgs e)
    //    {

    //    }

    //}

            
        //}

    }
}

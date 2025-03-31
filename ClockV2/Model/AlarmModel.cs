using PriorityQueue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockV2
{
    /// <summary>
    /// 
    /// </summary>
    public class AlarmModel
    {

        //PriorityQueue<Alarm> alarms;
        //alarms = new SortedArrayPriorityQueue<Alarm>(8);
        //public SortedArrayPriorityQueue<Alarm> _alarms ;
        private SortedArrayPriorityQueue<Alarm> _alarms = new SortedArrayPriorityQueue<Alarm>(8);

        //private PriorityQueue<Alarm> alarms;


        /// <summary>
        /// 
        /// </summary>
        public AlarmModel()
        {
            //_alarms = new SortedArrayPriorityQueue<Alarm>(8);
        
        }


        public void AddAlarm(string alarmName, string priorityHours, string priorityMinutes)
        {

            int hoursToSeconds = int.Parse(priorityHours);
            hoursToSeconds = hoursToSeconds * 3600;             // converting to seconds

            int minutesToSeconds = int.Parse(priorityMinutes);
            minutesToSeconds = minutesToSeconds * 60;           // converting to seconds

            int seconds = hoursToSeconds + minutesToSeconds;

            Alarm newAlarm = new Alarm(alarmName, seconds);

            _alarms.Add(newAlarm, seconds);
            
        }


            
    }
}

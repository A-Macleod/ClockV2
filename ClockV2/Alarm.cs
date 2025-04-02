using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockV2
{
    /// <summary>
    /// A Class to represent an Alarm with a name and time
    /// </summary>
    public class Alarm
    {
        public string Name { get; set; }
        public int Time { get; set; }


        /// <summary>
        /// Constructor to instantiate an Alarm object with a name and time in seconds
        /// </summary>
        /// <param name="alarmName">The name of the alarm</param>
        /// <param name="time">The time of the alarm in seconds</param>
        public Alarm(string alarmName, int time)
        {
            Name = alarmName;
            Time = time;
        }


        /// <summary>
        /// Method to return the name of the alarm
        /// </summary>
        /// <returns></returns>
        public string GetAlarmName()
        {
            return Name;
        }


        /// <summary>
        /// Method to return the time of the alarm
        /// </summary>
        /// <returns></returns>
        public int GetAlarmTime()
        {
            return Time;
        }


        /// <summary>
        /// Method to return the name of the alarm, overriding the PriorityQueue ToString Method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}

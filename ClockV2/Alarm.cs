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
        public string AlarmName { get; set; }
        public DateTime Time { get; set; }


        /// <summary>
        /// Constructor to instantiate an Alarm object with a name and time
        /// </summary>
        /// <param name="alarmName">The name of the alarm</param>
        /// <param name="time">The time of the alarm</param>
        public Alarm(string alarmName, DateTime time)
        {
            AlarmName = alarmName;
            Time = time;
        }


        /// <summary>
        /// Method to return the name of the alarm
        /// </summary>
        /// <returns></returns>
        public string getAlarmName()
        {
            return AlarmName;
        }


        /// <summary>
        /// Method to return the time of the alarm
        /// </summary>
        /// <returns></returns>
        public DateTime getAlarmTime()
        {
            return Time;
        }
    }
}

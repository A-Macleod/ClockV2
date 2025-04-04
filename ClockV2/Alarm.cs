using PriorityQueue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClockV2
{
    /// <summary>
    /// A Class to represent an Alarm. With a Name, an Integer value representing Time (in seconds), and a Timer.
    /// Each Alarm has a Timer class instantiated in its Constructor that handles a Tick Eventhandler. At each 1 second
    /// interval the AlarmTime is decremented by 1 and when AlarmTime reaches zero a Dialog messagebox is called to alert
    /// the user
    /// </summary>
    public class Alarm
    {

        public string AlarmName { get; set; }
        public int AlarmTime { get; set; }
        static System.Windows.Forms.Timer Timer;


        /// <summary>
        /// Constructor, takes in name and time and creates the alarm object with a Timer, that has a 1 second interval.
        /// At each interval the AlarmTimer_Tick eventhandler is called, which handles the alarm countdown. 
        /// </summary>
        /// <param name="alarmName">The name of the alarm</param>
        /// <param name="alarmTime">The total time of the alarm</param>
        public Alarm(string alarmName, int alarmTime)
        {
            AlarmName = alarmName;
            AlarmTime = alarmTime;
            Timer = new System.Windows.Forms.Timer();
            Timer.Interval = 1000;
            Timer.Tick += AlarmTimer_Tick;                                                                 
        }


        /// <summary>
        /// Method to Start the Timer of the Alarm object
        /// </summary>
        public void StartCountdown()
        {
            Timer.Start();
        }


        /// <summary>
        /// Method to Stop the Timer of the Alarm object and then Dispose of the Timer
        /// </summary>
        public void StopCountdown()
        {
            Timer.Stop();
            Timer.Dispose();
        }


        /// <summary>
        /// Eventhandler that CountsDown with each TimerTick. The AlarmTime is decremented and when
        /// it reaches zero a message box will be called displaying that the alarm has now sounded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AlarmTimer_Tick(object sender, EventArgs e)
        {
            AlarmTime--;

            if (AlarmTime <= 0)
            {
                StopCountdown();
                MessageBox.Show("ALARM CLASS - Times Up!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        /// <summary>
        /// Method to override the SortedArrayPriorityQueue ToString Method and Return the AlarmName ToString
        /// </summary>
        /// <returns>Returns the AlarmName</returns>
        public override string ToString()
        {
            return AlarmName.ToString();
        }


    }
}

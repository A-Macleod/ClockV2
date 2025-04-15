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

        private int _initialAlarmTime { get; }  // For resetting the alarm, we are not using anymore
        private DateTime _alarmDueTime;
        
        public string AlarmName { get; set; }
        public int AlarmTime { get; set; }

        public System.Windows.Forms.Timer Timer;


        public event EventHandler<string> Alarm_Triggered;                // Popup Event and to Remove the Alarm
        public event EventHandler<TimeSpan> Alarm_Countdown_Tick;         // Update UI with time remaining on Countdown & When it reaches zero



        /// <summary>
        /// Constructor, takes in name and time and creates the alarm object with a Timer, that has a 1 second interval.
        /// At each interval the AlarmTimer_Tick eventhandler is called, which handles the alarm countdown. 
        /// </summary>
        /// <param name="alarmName">The name of the alarm</param>
        /// <param name="alarmCountdownTimeInSeconds">The total time of the alarm countdown in seconds</param>
        public Alarm(string alarmName, int alarmCountdownTimeInSeconds)
        {

            AlarmName = alarmName;
            AlarmTime = alarmCountdownTimeInSeconds;

            //_initialAlarmTime = AlarmTime; /For resetting the alarm which we are not using 

            _alarmDueTime = DateTime.Now.AddSeconds(AlarmTime); // Adding the Alarm time to the current time, this is when we want the alarm to go off after we start timer

            

            Timer = new System.Windows.Forms.Timer();
            Timer.Interval = 1000;
            Timer.Tick += Timer_Tick_Countdown;
            
        }



        /// <summary>
        /// Eventhandler that CountsDown with each TimerTick. The AlarmTime is decremented and when
        /// it reaches zero a message box will be called displaying that the alarm has now sounded.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Timer_Tick_Countdown(object sender, EventArgs e)
        {
            
            var remainingTimeLeft = _alarmDueTime - DateTime.Now;   

            if (remainingTimeLeft <= TimeSpan.Zero)
            {
                //ResetAlarm();  

                StopCountdownAndDispose();

                Alarm_Countdown_Tick?.Invoke(this, TimeSpan.Zero);  // Show the time has reached zero

                Alarm_Triggered?.Invoke(this, AlarmName);   // MessageBox alarm complete, Remove Alarm
            }
            else
            {
                Alarm_Countdown_Tick?.Invoke(this, remainingTimeLeft);
            }           
        }



        /// <summary>
        /// Method to Start the Timer of the Alarm object
        /// </summary>
        public void StartCountdown() //int time
        {
            _alarmDueTime = DateTime.Now.AddSeconds(AlarmTime); // Adding the Alarm time to the current time, this is when we want the alarm to go off after we start timer
            Timer.Start();
        }



        /// <summary>
        /// Method to Stop the Timer of the Alarm object, unsubscribe from the eventhandler and then Dispose of the Timer.
        /// Use this before Removing Alarm
        /// </summary>
        public void StopCountdownAndDispose()
        {
            Timer.Stop();
            Timer.Tick -= Timer_Tick_Countdown; // Unsubscribe from TickEvent, prevents memory leaks
            Timer.Dispose();
        }



        /// <summary>
        /// Method to override the SortedArrayPriorityQueue ToString Method and Return the AlarmName ToString
        /// </summary>
        /// <returns>Returns the AlarmName</returns>
        public override string ToString()
        {
            return AlarmName.ToString();
        }



        //public void ResetAlarm()
        //{
        //    AlarmTime = _initialAlarmTime;
        //}



        //public TimeSpan GetRemainingTime()
        //{
        //    return AlarmEndTime - DateTime.Now;
        //}


        // https://stackoverflow.com/questions/30008530/timespan-countdown-timer
        // https://geoffstratton.com/cnet-countdown-timer/
        // https://zerotomastery.io/blog/c-sharp-timespan/ TIMESPAN EXPLANATION 

    }
}

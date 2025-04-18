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
    /// Class to represent an Alarm. That takes in a Name and Integer value representing Time (in seconds).
    /// Each Alarm has a Timer class instantiated in its Constructor that handles a Tick Eventhandler. The duetime for the
    /// Alarm is determined by adding the current DateTime and Alarm Time together, which is done when the Timer is started. 
    /// At each 1 second interval when the Timer is started, the remaninig time is calculated by the dueTime minus the current time. 
    /// Which is then sent to the AlarmView and ClockView via Eventhandlers. When the dueTime reaches zero a MessageBox alert is displayed
    /// to alert the user the Timer has reached zero.
    /// </summary>
    public class Alarm
    {

        //private int _initialAlarmTime { get; }  // For resetting the Alarm, not using anymore
        private DateTime _alarmDueTime;
        
        public string AlarmName { get; set; }
        public int AlarmTime { get; set; }

        public System.Windows.Forms.Timer Timer;


        public event EventHandler<string> Alarm_Triggered;                // MessageBox Event and to Remove the Alarm
        public event EventHandler<TimeSpan> Alarm_Countdown_Tick;         // Update UI with Time remaining on Countdown & When it reaches zero


        /// <summary>
        /// Constructor, takes in Name and Time and creates the Alarm object with a Timer, that has a 1 second interval.
        /// At each interval the AlarmTimer_Tick eventhandler is called, which handles the Alarm countdown. 
        /// </summary>
        /// <param name="alarmName">The Name of the Alarm</param>
        /// <param name="alarmCountdownTimeInSeconds">The total Time of the Alarm countdown in seconds</param>
        public Alarm(string alarmName, int alarmCountdownTimeInSeconds)
        {           
            AlarmName = alarmName;
            AlarmTime = alarmCountdownTimeInSeconds;
            
            //_alarmDueTime = DateTime.Now.AddSeconds(AlarmTime); // Adding Alarm Time to the current time

            Timer = new System.Windows.Forms.Timer();
            Timer.Interval = 1000;
            Timer.Tick += Timer_Tick_Countdown;

            //_initialAlarmTime = AlarmTime; // For resetting the alarm, not using anymore
        }



        /// <summary>
        /// Method Eventhandler that Countsdown with each Timer Tick. When the remainingTimeLeft reaches Zero stop and dispose of the Alarm
        /// and trigger the MessageBox to alert the user. Each Tick triggers the event to update the AlarmView and ClockView with the remaining
        /// Time left on the Alarm, acting as a Countdown time.
        /// </summary>
        /// <param name="sender">The object that raised the event</param>
        /// <param name="e">The argument information</param>
        public void Timer_Tick_Countdown(object sender, EventArgs e)
        {
            
            var remainingTimeLeft = _alarmDueTime - DateTime.Now;   // When timer is started, acts as an accurate Countdown until the dueTime

            if (remainingTimeLeft <= TimeSpan.Zero)
            {
                //ResetAlarm();  

                StopCountdownAndDispose();

                Alarm_Countdown_Tick?.Invoke(this, TimeSpan.Zero);  // Show Time has reached zero. Subscribed in AlarmPresenter

                Alarm_Triggered?.Invoke(this, AlarmName);           // MessageBox Alarm complete, Remove Alarm. Subscribed in AlarmPresenter
            }
            else
            {
                Alarm_Countdown_Tick?.Invoke(this, remainingTimeLeft);  // Update the Countdown Time with each Tick event, Subscribed in AlarmPresenter
            }           
        }



        /// <summary>
        /// Method to Start the Timer of the Alarm object. The Alarm dueTime is calculated when the counter is started.
        /// </summary>
        public void StartCountdown()
        {
            _alarmDueTime = DateTime.Now.AddSeconds(AlarmTime); // Adding the Alarm Time to Current Time, this is when we want the alarm to go off
            Timer.Start();
        }



        /// <summary>
        /// Method to Stop the Timer of the Alarm object, unsubscribe from the Tick eventhandler and then Dispose of the Timer.
        /// Use this before Removing Alarm. This helps prevents memory leaks
        /// </summary>
        public void StopCountdownAndDispose()
        {
            Timer.Stop();
            Timer.Tick -= Timer_Tick_Countdown;
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

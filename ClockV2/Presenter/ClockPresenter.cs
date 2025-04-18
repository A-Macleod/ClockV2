using ClockV2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ClockV2.Presenter
{
    /// <summary>
    /// Class to represent the communication layer between the ClockModel and ClockView in the MVP design pattern.
    /// This presenter layer is responsible for getting the DateTime from the ClockModel to pass to the ClockView in
    /// order to render the clock hands at the correct time. The AlarmPresenter also passes Alarm Names, DateTimes
    /// as well as events to update the ClockView. 
    /// </summary>
    public class ClockPresenter
    {

        private readonly ClockModel model;
        private readonly ClockView view;
        private readonly Timer timer;


        /// <summary>
        /// Constructor to instantiate the ClockPresenter with a reference to the ClockModel and ClockView.
        /// Initialises the ClockPresenter with a timer that has a 1 second tick interval for the ClockView UI.
        /// </summary>
        /// <param name="model">The model containting Clock logic</param>
        /// <param name="view">The view representing the Clock UI</param>
        public ClockPresenter(ClockModel model, ClockView view)
        {
            this.model = model;
            this.view = view;

            // Link the View to this Presenter
            view.SetPresenter(this);

            // Set up the timer for regular updates
            timer = new Timer(1000); // 1-second interval
            timer.Elapsed += (s, e) => UpdateClock();
            timer.Start();
        }



        /// <summary>
        /// Method to return the current DateTime and update the ClockView using an EventHandler 
        /// </summary>
        private void UpdateClock()
        {
            // Fetch the current time from the Model
            DateTime currentTime = model.GetCurrentTime();

            // Update the View with the new time
            view.Invoke(new Action(() => view.UpdateClock(currentTime)));
        }



        /// <summary>
        /// Method to update the ClockView with the Alarm Name that is currently at the head of the queue.
        /// The method is called from the AlarmPresenter.
        /// </summary>
        /// <param name="headAlarmName">The Name of the Alarm at the head of the queue</param>
        public void AlarmPresenterNextAlarmName(string headAlarmName)
        {
            view.Invoke(new Action(() => view.ClockShowNextAlarmName(headAlarmName)));
        }



        /// <summary>
        /// Method to update the ClockView with the Alarm Time that is currently at the head of the queue.
        /// The method is called from the AlarmPresenter.
        /// </summary>
        /// <param name="headAlarmTime">The Time of the Alarm at the head of the queue</param>
        public void AlarmPresenterNextAlarmTime(TimeSpan headAlarmTime)
        {
            view.Invoke(new Action(() => view.ClockShowNextAlarmTime(headAlarmTime)));
        }



        /// <summary>
        /// Method to update the ClockView that there is no Alarm.
        /// The Method is called from AlarmPresenter, UpdateClockViewWithNextAlarm, as an exception.
        /// </summary>
        public void AlarmPresenterNoAlarm()
        {
            view.Invoke(new Action(() => view.ClockShowNoNextAlarm()));
        }



        /// <summary>
        /// Method to update the ClockView of the current Alarm Countdown as it ticks.
        /// The Method is called from AlarmPresenter.
        /// </summary>
        /// <param name="remainingTimeLeft"></param>
        public void ClockViewCountdownEventTimeLeft(TimeSpan remainingTimeLeft)
        {
            
            view.Invoke(new Action(() => view.ViewCountdownEventTimeLeft(remainingTimeLeft)));
        }

    }
}

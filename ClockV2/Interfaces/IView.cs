using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClockV2
{
    /// <summary>
    /// IView interface defines the contract for the AlarmView in the MVP design pattern. 
    /// </summary>
    public interface IView
    {
        
        /// <summary>
        /// Event button click to send the Alarm Name and Time
        /// </summary>
        event EventHandler<(string alarmName, string priorityHour, string priorityMinute, string priortiySecond)> Button_Add_Alarm_Click;

        /// <summary>
        /// Event button click to Remove an Alarm
        /// </summary>
        event EventHandler Button_Remove_Alarm_Click;

        /// <summary>
        /// Event button click to Start the Alarm Timer
        /// </summary>
        event EventHandler Button_Start_Timer_Click;

        /// <summary>
        /// Event to Hide the AlarmView form
        /// </summary>
        event FormClosingEventHandler FormClosing;  //  In ClockView, handles showing AlarmView creation button and "Hiding" AlarmView instead of "Closing" the AlarmView to save the state



        /// <summary>
        /// Sets the AlarmView presenter as the AlarmPresenter
        /// </summary>
        /// <param name="_presenter">The AlarmPresenter presenter</param>
        void SetPresenter(AlarmPresenter _presenter);

        /// <summary>
        /// Displays the AlarmView
        /// </summary>
        void ShowView();

        /// <summary>
        /// MessageBox display to alert user the Alarm has completed 
        /// </summary>
        /// <param name="AlarmName">The Name of the completed Alarm</param>
        void ShowAlarmCompleteMessageBox(string AlarmName);

        /// <summary>
        /// Output the Array of Alarms, Names and Priorities in a string format 
        /// </summary>
        /// <param name="alarms">Names and Priorities of Alarms</param>
        void ShowAlarms(string alarms);

        /// <summary>
        /// MessageBox display to show exception error messages inside
        /// </summary>
        /// <param name="message">The exception error description</param>
        void ShowError(string message);

        /// <summary>
        /// Enable the Start_Alarm button
        /// </summary>
        void EnableStartButton();

        /// <summary>
        /// Disable the Start_Alarm button
        /// </summary>
        void DisableStartButton();

        /// <summary>
        /// Clear the AlarmView Alarm Name and numericUpDown boxes
        /// </summary>
        void ClearAlarmNameAndHoursSecondsInputs();

        /// <summary>
        /// Display the Head of the queues initial Alarm length
        /// </summary>
        /// <param name="headCountdownTime"></param>
        void ViewCountdownTime(TimeSpan headCountdownTime);

        /// <summary>
        /// Method to display that there is no time to countdown, the queue is empty
        /// </summary>
        /// <param name="noItem"></param>
        void ViewCountdownNull(string noItem);

        /// <summary>
        /// Display the countdown time, dueTime, for the Alarm Tick event
        /// </summary>
        /// <param name="remainingTimeLeft"></param>
        void ViewCountdownEventTimeLeft(TimeSpan remainingTimeLeft);

    }
}

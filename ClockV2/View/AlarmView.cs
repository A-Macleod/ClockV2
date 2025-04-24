
using PriorityQueue;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;
using System.Runtime.CompilerServices;

namespace ClockV2
{
    /// <summary>
    /// Class to represent the AlarmView (UI to Add and Remove Alarms) in the MVP design pattern. 
    /// The AlarmView is responsible for capturing and displaying the information entered by the user and sent
    /// by the AlarmPresenter. The AlarmView does not directly interact with the AlarmModel. 
    /// </summary>
    public partial class AlarmView : Form, IView
    {

        public event EventHandler<(string alarmName, string hour, string minute, string second)> Button_Add_Alarm_Click;
        public event EventHandler Button_Remove_Alarm_Click;
        public event EventHandler Button_Start_Timer_Click;

        private AlarmPresenter _presenter;


        /// <summary>
        /// Constructor that instatiates the AlarmView and subscribes to the button click Eventhandler
        /// </summary>
        public AlarmView()
        {
            InitializeComponent();
            
            button_Add_Alarm.Click += Button_Add_Click;

        }



        /// <summary>
        /// Method Eventhandler that takes in the Alarm Name and Time and invokes an OnClickEvent to pass the data to the Alarm Presenter.
        /// This method is completely decoupled from the Alarm Presenter.
        /// </summary>
        /// <param name="sender">The object that raised the event</param>
        /// <param name="e">The argument information</param>
        private void Button_Add_Click(object sender, EventArgs e)
        {
            string alarmName = textBox_AlarmName.Text.ToString();
            string hour = numericUpDown_Hours.Value.ToString();
            string minute = numericUpDown_Minutes.Value.ToString();
            string second = numericUpDown_Seconds.Value.ToString();

            Button_Add_Alarm_Click?.Invoke(this, (alarmName, hour, minute, second));    // AlarmPresenter

            ClearAlarmNameAndHoursSecondsInputs();
        }



        /// <summary>
        /// Method Eventhandler that when clicked calls the RemoveAlarm method in the Alarm Presenter.
        /// This method is completely decoupled from the Alarm Presenter.
        /// </summary>
        /// <param name="sender">The object that raised the event</param>
        /// <param name="e">The argument information</param>
        private void Button_Remove_Click(object sender, EventArgs e)
        {
            Button_Remove_Alarm_Click?.Invoke(this, EventArgs.Empty);   // AlarmPresenter
        }



        /// <summary>
        /// Method Eventhandler that when clicked calls the StartTimer method in the Alarm Presenter.
        /// This method is completely decoupled from the Alarm Presenter.
        /// </summary>
        /// <param name="sender">The object that raised the event</param>
        /// <param name="e">The argument information</param>
        private void Button_StartTimer_Click(object sender, EventArgs e)
        {
            Button_Start_Timer_Click?.Invoke(this, EventArgs.Empty);    // presenter
        }



        /// <summary>
        /// Method that takes in an AlarmPresenter argument and sets the AlarmViews presenter as the incoming presenter from the AlarmPresenter 
        /// </summary>
        /// <param name="_presenter">The presenter from the AlarmPresenter</param>
        public void SetPresenter(AlarmPresenter _presenter)
        {
            this._presenter = _presenter;
        }



        /// <summary>
        /// Method to tell the AlarmView to Show when called from the ClockView button click event
        /// </summary>
        public void ShowView()
        {
            this.Show();
        }

        

        /// <summary>
        /// Method to display the Alarm has sounded and to show a MessageBox with the Alarm Name from the AlarmPresenter
        /// </summary>
        /// <param name="AlarmName">The Name of the Alarm that has sounded</param>
        public void ShowAlarmCompleteMessageBox(string AlarmName)
        {
            MessageBox.Show($"Alarm : {AlarmName}\r\nis Ready!", "Alarm", MessageBoxButtons.OK, MessageBoxIcon.Information); 
        }



        /// <summary>
        /// Method to output all the Alarms from the SortedArrayPriorityQueue into the label box
        /// </summary>
        /// <param name="alarms">The Alarm Items to be displayed in the label</param>
        public void ShowAlarms(string alarms)
        {
            label_AlarmsOutput.Text = alarms;  
        }



        /// <summary>
        /// Method to Show a MessageBox with the exception error message inside
        /// </summary>
        /// <param name="message">The exception error message</param>
        public void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            ClearAlarmNameAndHoursSecondsInputs();
        }



        /// <summary>
        /// Method to enable the Start Alarm button
        /// </summary>
        public void EnableStartButton()
        {
            button_Start_Alarm.Enabled = true;
        }



        /// <summary>
        /// Method to disable the Start Alarm button
        /// </summary>
        public void DisableStartButton()
        {
            button_Start_Alarm.Enabled = false;
        }



        /// <summary>
        /// Method to clear and reset the input values from the AlarmView UI
        /// </summary>
        public void ClearAlarmNameAndHoursSecondsInputs()
        {
            textBox_AlarmName.Text = null;
            numericUpDown_Hours.Text = "0";
            numericUpDown_Minutes.Text = "0";
            numericUpDown_Seconds.Text = "0";
        }


        /// <summary>
        /// Method to show the First Alarm Time added to the SortedArrayPriorityQueue. This just shows the time of the First Added Alarm, nothing else.
        /// It makes it look pretty for the user and the starting Countdown timer. The Alarm Time is displayed in a TimeSpan format as hh\\:mm\\:ss
        /// </summary>
        /// <param name="headCountdownTime"></param>
        public void ViewCountdownTime(TimeSpan headCountdownTime)
        {
            label_Countdown.Text = ($"{headCountdownTime.ToString("hh\\:mm\\:ss")}");
        }



        /// <summary>
        /// Method to display if there is a Head Alarm Time in the SortedArrayPriorityQueue
        /// </summary>
        /// <param name="noItem"></param>
        public void ViewCountdownNull(string NoTimeToCountdownErrorMsg)
        {
            label_Countdown.Text = NoTimeToCountdownErrorMsg;
        }



        /// <summary>
        /// Method to display an error message in the countdown label if the Remove Alarm method throws an error
        /// </summary>
        /// <param name="errMsg">The error description in the message</param>
        public void ViewCountdownStop(string errMsg)
        {
            label_Countdown.Text = errMsg;
        }



        /// <summary>
        /// Method that is called when the Tick Event ticks each second until stopped. This is the Tick event for the Alarm object Countdown. 
        /// As the dueTime gets closer the remainingTimeLeft will decrease, thus displaying a "Countdown timer" as the method is called each second.
        /// The remainingTimeLeft is in a Timespan format of hh\\:mm\\:ss
        /// </summary>
        /// <param name="remainingTimeLeft">The time left before the dueTime of the Alarm</param>
        public void ViewCountdownEventTimeLeft(TimeSpan remainingTimeLeft)
        {
            label_Countdown.Text = ($"{ remainingTimeLeft.ToString("hh\\:mm\\:ss")}" );
        }




        // https://learn.microsoft.com/en-us/dotnet/desktop/winforms/controls/how-to-add-an-event-handler?view=netdesktop-9.0
        // https://learn.microsoft.com/en-us/dotnet/desktop/winforms/event-handlers-overview-windows-forms?view=netframeworkdesktop-4.8
        //  Decoupled https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/events/
        // https://learn.microsoft.com/en-us/dotnet/api/system.timers.timer?redirectedfrom=MSDN&view=netframework-4.8
        // https://stackoverflow.com/questions/2021681/hide-form-instead-of-closing-when-close-button-clicked

    }
}

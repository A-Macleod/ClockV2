
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
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;
using System.Runtime.CompilerServices;

namespace ClockV2
{
    public partial class AlarmView : Form, IView
    {

        // Completely Decoupled https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/events/
        public event EventHandler<(string alarmName, string priorityHour, string priorityMinute, string priortiySecond)> Button_Add_Alarm_Click;
        public event EventHandler Button_Remove_Alarm_Click;
        public event EventHandler Button_Start_Timer_Click;
       
        public event FormClosedEventHandler FormClosed;

        private AlarmPresenter _presenter;



        /// <summary>
        /// Constructor that instatiates the AlarmView and subscribes to the button eventhandlers
        /// </summary>
        public AlarmView()
        {
            InitializeComponent();
            
            button_Add_Alarm.Click += Button_Add_Click;
            //button_Remove_Alarm.Click += Button_Remove_Click;     // Was removing Double the Items in the queue
            //button_Start_Alarm.Click += Button_StartTimer_Click;

        }

        

        // Completely Decoupled
        private void Button_Add_Click(object sender, EventArgs e)
        {
            string alarmName = textBox_AlarmName.Text.ToString();
            string priorityHour = numericUpDown_Hours.Value.ToString();
            string priorityMinute = numericUpDown_Minutes.Value.ToString();
            string priortiySecond = numericUpDown_Seconds.Value.ToString();

            //_presenter.StopCountdown();
            //_presenter.AddAlarm(alarmName, priorityHour, priorityMinute, priortiySecond);

            Button_Add_Alarm_Click?.Invoke(this, (alarmName, priorityHour, priorityMinute, priortiySecond));    // presenter

            ClearAlarmNameAndHoursSecondsInputs();
        }


        private void Button_Remove_Click(object sender, EventArgs e)
        {

            Button_Remove_Alarm_Click?.Invoke(this, EventArgs.Empty);   // presenter

            //Console.WriteLine("=== VIEW ALARM REMOVED ===");

            //_presenter.RemoveAlarm();
            //_presenter.HeadCountdownTime();
        }


        private void Button_StartTimer_Click(object sender, EventArgs e)
        {
            Button_Start_Timer_Click?.Invoke(this, EventArgs.Empty);    // presenter
            //_presenter.ShowAlarms();
            //_presenter.HeadCountdownTime();
            //_presenter.StartAlarm();

        }


        public void SetPresenter(AlarmPresenter _presenter)
        {
            this._presenter = _presenter;
        }


        public void ShowView()
        {
            this.Show();
        }

        
        public void ShowAlarmCompleteMessageBox(string AlarmName)
        {
            MessageBox.Show($"Alarm : {AlarmName}\r\nis Ready!", "Alarm", MessageBoxButtons.OK, MessageBoxIcon.Information); 
        }


        public void ShowAlarms(string alarms)
        {
            label_Output.Text = alarms;  
        }


        public void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            ClearAlarmNameAndHoursSecondsInputs();
        }


        public void EnableStartButton()
        {
            button_Start_Alarm.Enabled = true;
        }


        public void DisableStartButton()
        {
            button_Start_Alarm.Enabled = false;
        }


        public void ClearAlarmNameAndHoursSecondsInputs()
        {
            textBox_AlarmName.Text = null;
            numericUpDown_Hours.Text = "0";
            numericUpDown_Minutes.Text = "0";
            numericUpDown_Seconds.Text = "0";
        }


        public void ViewCountdownTime(int countdownTime)
        {
            label6.Text = countdownTime.ToString();
        }


        public void ViewCountdownNull(string noItem)
        {
            label6.Text = "No Time to Countdown";
        }


        public void ViewCountdownStop(string errMsg)
        {
            label6.Text = errMsg;
        }


        public void ViewCountdownEventTimeLeft(TimeSpan remainingTimeLeft)
        {
            label6.Text = ($"{ remainingTimeLeft.ToString("hh\\:mm\\:ss")}" );
        }


        //// https://learn.microsoft.com/en-us/dotnet/api/system.timers.timer?redirectedfrom=MSDN&view=netframework-4.8
        //public void startTimer(int AlarmTimeInSeconds)
        //{
        //    timeLeft = AlarmTimeInSeconds;
        //    timer1.Start();
        //}


        //private void timer1_Tick_1(object sender, EventArgs e)
        //{
        //    if (timeLeft > 0)
        //    {
        //        timeLeft = timeLeft - 1;
        //        label6.Text = timeLeft + " seconds";
        //    }
        //    else
        //    {
        //        timer1.Stop();
        //        label6.Text = "Times up";
        //        MessageBox.Show("Times Up!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        // Maybe show the add alarm button
        //    }
        //}














    }
}

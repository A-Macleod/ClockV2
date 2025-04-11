
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

namespace ClockV2
{
    public partial class AlarmView : Form, IView
    {

        private AlarmPresenter _presenter;


        public AlarmView()
        {
            InitializeComponent();
        }


        public void SetPresenter(AlarmPresenter _presenter)
        {
            this._presenter = _presenter;
        }



        public void ShowView()
        {
            this.Show();
        }


        public event FormClosedEventHandler FormClosed;


        private void Button_Add_Click(object sender, EventArgs e)
        {
            string alarmName = textBox_AlarmName.Text.ToString();
            string priorityHour = numericUpDown_Hours.Value.ToString(); 
            string priorityMinute = numericUpDown_Minutes.Value.ToString();
            string priortiySecond = numericUpDown_Seconds.Value.ToString();

            //_presenter.StopCountdown();
            _presenter.AddAlarm(alarmName, priorityHour, priorityMinute, priortiySecond);


            ClearAlarmNameAndHoursSecondsInputs();       
        }



        private void Button_Remove_Click(object sender, EventArgs e)
        {
            _presenter.RemoveAlarm();
            _presenter.HeadTime();
        }



        private void Button_StartTimer_Click(object sender, EventArgs e)
        {
            _presenter.ShowAlarms();
            _presenter.HeadTime();
            _presenter.StartAlarm();
            
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



        public void DisableStartButton()
        {
            button_Start.Enabled = false;
        }



        public void EnableStartButton()
        {
            button_Start.Enabled = true;
        }



        private void ClearAlarmNameAndHoursSecondsInputs()
        {
            textBox_AlarmName.Text = null;
            numericUpDown_Hours.Text = "0";
            numericUpDown_Minutes.Text = "0";
            numericUpDown_Seconds.Text = "0";
        }



        //public void UpdateTimeDisplay(TimeSpan time)
        //{
        //    label6.Text = time.TotalSeconds <= 0
        //        ? "00:00"
        //        : time.ToString(@"mm\ss");
        //}



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

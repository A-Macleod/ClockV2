using ClockV2.Helpers;
using ClockV2.Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClockV2
{
    public partial class ClockView : Form
    {
        private ClockPresenter presenter;
        private readonly ClockDrawingHelper drawingHelper = new ClockDrawingHelper();
        private DateTime currentTime;

        private IView alarmView;




        public ClockView()
        {
            InitializeComponent();

            // Enable double buffering to avoid flicker
            Panel_Clock.GetType()
                .GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                .SetValue(Panel_Clock, true, null);

            currentTime = DateTime.Now;
        }



        public void SetPresenter(ClockPresenter presenter)
        {
            this.presenter = presenter;
        }



        public void UpdateClock(DateTime currentTime)
        {
            this.currentTime = currentTime;
            Panel_Clock.Invalidate();   // Trigger a redraw of the panel
        }



        private void Panel_Clock_Paint(object sender, PaintEventArgs e)
        {
            if (presenter == null) return;

            var g = e.Graphics;
            drawingHelper.DrawClock(g, currentTime, Panel_Clock.Width, Panel_Clock.Height);
        }



        private void ButtonOpenForm2_Click(object sender, EventArgs e)
        {
            ButtonOpenForm2.Visible = false;


            if (alarmView == null || ((Form)alarmView).IsDisposed ) //  If alarmView doesn't exist or has been Closed, make a new alarmView form
            {
                //  Should be done in the presenter
                alarmView = new AlarmView();
                var alarmModel = new AlarmModel();
                var alarmPresenter = new AlarmPresenter(alarmView, alarmModel, presenter);  // WE ADDED presenter TO TEST INJECTION FOR PASSING INFO BACK TO CLOCK

                alarmView.FormClosing += OnAlarmViewFormClosing;
                alarmView.ShowView();
            }
            else
            {
                alarmView.ShowView();
            }
        }



        private void OnAlarmViewFormClosing(object sender, FormClosingEventArgs e)
        {
            ButtonOpenForm2.Visible = true;

            e.Cancel = true;            //  Instead of Closing form, Hide form, so we can keep the state of the alarmView form
            ((Form)alarmView).Hide();   //  Casting to access form methods
        }



        public void ClockShowNextAlarmName(string headAlarmName)
        {
            ClockViewNextAlarmNameLabel.Text = $"{headAlarmName}" ;
        }



        public void ClockShowNextAlarmTime(TimeSpan headAlarmTime)
        {
            ClockViewNextAlarmTimeLabel.Text = $"{headAlarmTime.ToString("hh\\:mm\\:ss")}" ;
        }



        public void ClockShowNoNextAlarm()
        {
            ClockViewNextAlarmNameLabel.Text = "No Alarm";
            ClockViewNextAlarmTimeLabel.Text = null;
        }



        public void ViewCountdownEventTimeLeft(TimeSpan remainingTimeLeft)
        {
            ClockViewNextAlarmTimeLabel.Text = $"{remainingTimeLeft.ToString("hh\\:mm\\:ss")}";
        }  
    }
}

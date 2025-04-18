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
    /// <summary>
    /// Class to represent the ClockView (face of the clock) as it ticks, each second, in the MVP design pattern. 
    /// The ClockView is responsible for displaying the information sent and by the ClockPresenter
    /// and AlarmPresenter. The ClockView does not directly interact with the ClockModel or AlarmModel. 
    /// </summary>
    public partial class ClockView : Form
    {

        private ClockPresenter presenter;
        private readonly ClockDrawingHelper drawingHelper = new ClockDrawingHelper();
        private DateTime currentTime;

        private IView alarmView;


        /// <summary>
        /// Constructor for ClockView that instantiates the Clock UI
        /// </summary>
        public ClockView()
        {
            InitializeComponent();

            // Enable double buffering to avoid flicker
            Panel_Clock.GetType()
                .GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                .SetValue(Panel_Clock, true, null);

            currentTime = DateTime.Now;
        }



        /// <summary>
        /// Method to define the Presenter for ClockView. Takes in a ClockPresenter argument
        /// and assigns the ClockViews presenter as that argument. 
        /// </summary>
        /// <param name="presenter">The presenter assigned to the this ClockView</param>
        public void SetPresenter(ClockPresenter presenter)
        {
            this.presenter = presenter;
        }



        /// <summary>
        /// Method that takes in the current DateTime as an argument and triggers a redraw of the clock panel 
        /// </summary>
        /// <param name="currentTime">The current DateTime</param>
        public void UpdateClock(DateTime currentTime)
        {
            this.currentTime = currentTime;
            Panel_Clock.Invalidate();   // Trigger a redraw of the panel
        }



        /// <summary>
        /// Method eventhandler for custom drawing
        /// </summary>
        /// <param name="sender">The object that raised the event</param>
        /// <param name="e">The argument information to perform drawing</param>
        private void Panel_Clock_Paint(object sender, PaintEventArgs e)
        {
            if (presenter == null) return;

            var g = e.Graphics;
            drawingHelper.DrawClock(g, currentTime, Panel_Clock.Width, Panel_Clock.Height);
        }



        /// <summary>
        /// Method eventhandler that when called hides the button to open the AlarmView. If the AlarmView does not exist or if it has been disposed of, 
        /// create a new AlarmModel, AlarmPresenter and AlarmView. Subscribe this AlarmView to the FormClosing Event then show the AlarmView form. If the
        /// AlarmView does exist, show the form instead. This helps us retain our AlarmView state using a modified FormClosing event.
        /// </summary>
        /// <param name="sender">The object that raised the event</param>
        /// <param name="e">The argument information</param>
        private void ButtonOpenForm2_Click(object sender, EventArgs e)
        {
            ButtonOpenForm2.Visible = false;


            if (alarmView == null || ((Form)alarmView).IsDisposed )
            {
                //  Should be done in the presenter
                alarmView = new AlarmView();
                var alarmModel = new AlarmModel();
                var alarmPresenter = new AlarmPresenter(alarmView, alarmModel, presenter);  // alarmPresenter has a reference to ClockPresenter to pass information to

                alarmView.FormClosing += OnAlarmViewFormClosing;
                alarmView.ShowView();
            }
            else
            {
                alarmView.ShowView();
            }
        }



        /// <summary>
        /// Method eventhandler that modifies the FormClosing event. Instead of closing the form, Hide it instead. This lets us retain the state of the Form when Hidden,
        /// such as keeping the Alarms in the PriorityQueue alive. They would have been disposed if the form was closed. 
        /// </summary>
        /// <param name="sender">The object that raised the event</param>
        /// <param name="e">The argument information</param>
        private void OnAlarmViewFormClosing(object sender, FormClosingEventArgs e)
        {
            ButtonOpenForm2.Visible = true; // When the AlarmView close button is pressed, show the OpenForm2 button on the ClockView

            e.Cancel = true;            
            ((Form)alarmView).Hide();       //  Casting to access form methods
        }



        /// <summary>
        /// Method to display the Name of the Alarm that is the current head of the queue
        /// </summary>
        /// <param name="headAlarmName">Name of Alarm at the head of the queue</param>
        public void ClockShowNextAlarmName(string headAlarmName)
        {
            ClockViewNextAlarmNameLabel.Text = $"{headAlarmName}" ;
        }



        /// <summary>
        /// Method to display the TimeSpan of the Alarm that is the current head of the queue displayed in :hh :mm :ss format 
        /// </summary>
        /// <param name="headAlarmTime">Time of Alarm at the head of the queue</param>
        public void ClockShowNextAlarmTime(TimeSpan headAlarmTime)
        {
            ClockViewNextAlarmTimeLabel.Text = $"{headAlarmTime.ToString("hh\\:mm\\:ss")}" ;
        }



        /// <summary>
        /// Method to display there is no Alarm in the queue and to set the Alarm Time in the ClockView UI as NULL. This is called as an exception
        /// </summary>
        public void ClockShowNoNextAlarm()
        {
            ClockViewNextAlarmNameLabel.Text = "No Alarm";
            ClockViewNextAlarmTimeLabel.Text = null;
        }



        /// <summary>
        /// Method to update the ClockView UI with the TimeSpan left on the Alarm that is Ticking. Displayed in :hh :mm :ss format  
        /// </summary>
        /// <param name="remainingTimeLeft"></param>
        public void ViewCountdownEventTimeLeft(TimeSpan remainingTimeLeft)
        {
            ClockViewNextAlarmTimeLabel.Text = $"{remainingTimeLeft.ToString("hh\\:mm\\:ss")}";
        }  
    }
}

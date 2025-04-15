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
        private AlarmModel alarmModel;
        private AlarmPresenter alarmPresenter;


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
            Panel_Clock.Invalidate(); // Trigger a redraw of the panel
        }

        private void Panel_Clock_Paint(object sender, PaintEventArgs e)
        {
            if (presenter == null) return;

            var g = e.Graphics;
            drawingHelper.DrawClock(g, currentTime, Panel_Clock.Width, Panel_Clock.Height);
        }

        private void ButtonOpenForm2_Click(object sender, EventArgs e)
        {
            ButtonOpenForm2.Visible = false;    // hide the Button to prevent other forms being created

            if (alarmView == null || ((Form)alarmView).IsDisposed);
            {
                alarmView = new AlarmView();
                alarmModel = new AlarmModel();
                alarmPresenter = new AlarmPresenter(alarmView, alarmModel);

                alarmView.ViewHidden += AlarmView_ViewHidden;


            }


            //alarmView = new AlarmView();
            //alarmModel = new AlarmModel();
            //alarmPresenter = new AlarmPresenter(alarmView, alarmModel);

            //alarmView.FormClosed += AlarmView_FormClosed;
            alarmView.ShowView();
        }

        private void AlarmView_FormClosing(object sender, FormClosedEventArgs e)
        {
            ButtonOpenForm2.Visible = true;
        }

        private void AlarmView_ViewHidden(object sender, EventArgs e)
        {
            ButtonOpenForm2.Visible = true;
        }
    }
}


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


        private void Button_Add_Click(object sender, EventArgs e)
        {
            string alarmName = textBox_AlarmName.Text.ToString();
            string priorityHour = numericUpDown_Hours.Value.ToString();      // convert numericUpDown to string from decimal
            string priorityMinute = numericUpDown_Minutes.Value.ToString();  // convert numericUpDown to string from decimal

            _presenter.AddAlarm(alarmName, priorityHour, priorityMinute);
        }


        public void ShowAlarms(string alarms)
        {
            label_Output.Text = alarms;
        }


        public void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);  // Popup to display Error
        }


        private void Button_Remove_Click(object sender, EventArgs e)
        {

        }
    }
}

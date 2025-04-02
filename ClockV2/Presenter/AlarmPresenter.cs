
using ClockV2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClockV2
{

    public class AlarmPresenter
    {
        private readonly AlarmView _view;
        private readonly AlarmModel _model;

        public AlarmPresenter(AlarmView _view, AlarmModel _model)
        {
            this._view = _view;
            this._model = _model;

            // Link the View to this Presenter
            _view.SetPresenter(this);
        }


        public void AddAlarm(string alarmName, string priorityHour, string priorityMinute)
        {
            int hours = 0;
            int minutes = 0;

            try
            {

                if (string.IsNullOrWhiteSpace(alarmName))
                {

                    _view.ShowError("Name not Valid");
                    return;
                }


                if (!int.TryParse(priorityHour, out hours))
                { 

                    _view.ShowError("Number not Valid");
                    return;

                }


                if (!int.TryParse(priorityMinute, out minutes))
                {
                    _view.ShowError("Number not Valid");
                    return;
                }


                if (hours == 0 && minutes == 0 )
                {
                    _view.ShowError("Time not Valid");
                    return;
                }

                _model.AddAlarm(alarmName, priorityHour, priorityMinute);
                ShowAlarms();

            }
            catch (Exception ex)
            {
                _view.ShowError(ex.Message);
            }

        }

        public void ShowAlarms()
        {
            string alarms = _model.ShowAlarms();
            _view.ShowAlarms(alarms);
        }

    }
}

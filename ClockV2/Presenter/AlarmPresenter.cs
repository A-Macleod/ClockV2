using ClockV2.Interface;
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


        public void AddAlarm(string alarmName,string priorityHour,string priorityMinute)
        {

            try
            {

                if (string.IsNullOrWhiteSpace(alarmName))
                {

                    _view.ShowError("Not Valid");
                }


                if (!int.TryParse(priorityHour, out _)){    // discard the output

                    _view.ShowError("Not a number");
                }


                if(!int.TryParse(priorityMinute, out _))    // discard the output
                {
                    _view.ShowError("Not a number");
                }

                _model.AddAlarm(alarmName,priorityHour,priorityMinute);

            }
            catch(Exception ex)
            {
                _view.ShowError(ex.Message); // Call the ShowError Popup function in the UI View
            }

        }



    }
}

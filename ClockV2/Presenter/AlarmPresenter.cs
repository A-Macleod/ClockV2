using ClockV2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockV2
{

    public class AlarmPresenter
    {
        private readonly AlarmView view;
        private readonly AlarmModel model; 

        public AlarmPresenter(AlarmView view, AlarmModel model)
        {
            this.view = view;
            this.model = model;
            
            // Link the View to this Presenter
            view.SetPresenter(this);
        }
    }
}

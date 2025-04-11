using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClockV2
{
    public interface IView
    {
        // Completely Decoupled
        event EventHandler<(string alarmName, string priorityHour, string priorityMinute, string priortiySecond)> Button_Add_Alarm_Click;       // passing in tuple string value
        event EventHandler Button_Remove_Alarm_Click;




        event FormClosedEventHandler FormClosed;


        void SetPresenter(AlarmPresenter _presenter);
        void ShowView();













    }
}

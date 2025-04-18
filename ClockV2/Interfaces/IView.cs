using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClockV2
{
    /// <summary>
    /// IView interface defines the contract for the AlarmView in the MVP design pattern. 
    /// </summary>
    public interface IView
    {
        
        //  Decoupled Button Click Events
        event EventHandler<(string alarmName, string priorityHour, string priorityMinute, string priortiySecond)> Button_Add_Alarm_Click;
        event EventHandler Button_Remove_Alarm_Click;
        event EventHandler Button_Start_Timer_Click;

        event FormClosingEventHandler FormClosing;  //  In ClockView, handles showing AlarmView creation button and "Hiding" AlarmView instead of "Closing" to save the state


        // Interface Methods for AlarmView
        void SetPresenter(AlarmPresenter _presenter);
        void ShowView();
        void ShowAlarmCompleteMessageBox(string AlarmName);
        void ShowAlarms(string alarms);
        void ShowError(string message);
        void EnableStartButton();
        void DisableStartButton();
        void ClearAlarmNameAndHoursSecondsInputs();
        void ViewCountdownTime(TimeSpan headCountdownTime);
        void ViewCountdownNull(string noItem);
        void ViewCountdownEventTimeLeft(TimeSpan remainingTimeLeft);

    }
}

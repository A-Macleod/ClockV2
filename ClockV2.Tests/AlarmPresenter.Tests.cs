using ClockV2.Model;
using ClockV2.Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Moq;
using System.Threading.Tasks;
using System.Threading;

namespace ClockV2.Tests
{
    public class AlarmPresenterTests
    {
        private Mock<IView> _mockView;
        private AlarmModel _model;
        private AlarmPresenter _presenter;
        //private ClockView _clockView;
        //private ClockModel _clockModel;
        //private ClockPresenter _mockClockPresenter;



        [SetUp]
        public void Setup()
        {
            _mockView = new Mock<IView>();
            _model = new AlarmModel();
            _presenter = new AlarmPresenter(_mockView.Object, _model, null); // Takes ClockPresenter as an argument
            //_mockClockPresenter = new Mock<ClockPresenter>(null, null);

        }



        [TearDown]
        public void TearDown()
        {
            _mockView = null;
            _model = null;
            _presenter = null;
        }



        [Test]
        [TestCase("","","","")]
        [TestCase(null,"","","")]
        [TestCase(null, "0", "0", "0")]
        [TestCase(null, "1", "1", "1")]
        [TestCase(null, null, null, null)]
        public void AddAlarm_EmptyNameField_ShouldDisplayErrorMessageBox(string alarmName, string hours, string minutes, string seconds)
        {
            // Arrange & Act
            _presenter.AddAlarm(alarmName, hours, minutes, seconds);

            // Assert
            _mockView.Verify(v => v.ShowError("Name not Valid"), Times.Once);
        }



        [Test]
        [TestCase("TestName","","","")]
        [TestCase("TestName", " ", " ", " ")]
        [TestCase("TestName", null, null, null)]
        public void AddAlarm_CorrectNameNullTime_ShouldDisplayErrorMessageBox(string alarmName, string hours, string minutes, string seconds)
        {
            // Arrange & Act
            _presenter.AddAlarm(alarmName, hours, minutes, seconds);

            // Assert
            _mockView.Verify(v => v.ShowError("Number not Valid"), Times.Once);
        }



        [Test]
        [TestCase("TestName", "a", "b", "c")]
        [TestCase("TestName", "!", "@", "#")]
        [TestCase("TestName", "!£$", "%^&", "!*&")]
        [TestCase("TestName", "abcd", "bcde", "cdef")]
        [TestCase("TestName", "1", "0", "abc")]
        [TestCase("TestName", "1", "abc", "0")]
        [TestCase("TestName", "abc", "1", "0")]
        public void AddAlarm_CorrectNameNumberNotValid_ShouldDisplayErrorMessageBox(string alarmName, string hours, string minutes, string seconds)
        {
            // Arrange & Act
            _presenter.AddAlarm(alarmName, hours, minutes, seconds);

            // Assert
            _mockView.Verify(v => v.ShowError("Number not Valid"), Times.Once);
        }



        [Test]
        [TestCase("TestName", "0", "0", "0")]
        public void AddAlarm_CorrectNameZeroAlarmTime_ShouldDisplayErrorMessageBox(string alarmName, string hours, string minutes, string seconds)
        {
            // Arrange & Act
            _presenter.AddAlarm(alarmName, hours, minutes, seconds);

            // Assert
            _mockView.Verify(v => v.ShowError("Time not Valid"), Times.Once);
        }



        [Test]
        [TestCase("TestName", "0", "0", "10")]
        [TestCase("TestName", "0", "10", "0")]
        [TestCase("TestName", "10", "0", "0")]
        [TestCase("TestName", "10", "10", "10")]
        public void AddAlarm_CorrectNameCorrectTime_ShouldCallShowAlarmsWithAStringValueThatUpdatesView(string alarmName, string hours, string minutes, string seconds)
        {
            // Arrange & Act
            _presenter.AddAlarm(alarmName, hours, minutes, seconds);
            
            // Assert
            _mockView.Verify(v => v.ShowAlarms(It.IsAny<string>()), Times.Once);
        }



        [Test]
        [TestCase("TestName", "0", "0", "10")]
        [TestCase("TestName", "0", "10", "0")]
        [TestCase("TestName", "10", "0", "0")]
        [TestCase("TestName", "10", "10", "10")]
        public void AddAlarm_CorrectNameCorrectTime_ShouldCallViewCountdownTimeWithATimeSpanValueThatUpdatesView(string alarmName, string hours, string minutes, string seconds)
        {
            // Arrange & Act
            _presenter.AddAlarm(alarmName, hours, minutes, seconds);

            // Assert
            _mockView.Verify(v => v.ViewCountdownTime(It.IsAny<TimeSpan>()), Times.Once);
        }



        [Test]
        [TestCase("TestName0", "0", "0", "10")]
        [TestCase("TestName1", "0", "10", "0")]
        [TestCase("TestName2", "10", "0", "0")]
        [TestCase("TestName3", "10", "10", "10")]
        public void AddAlarm_CorrectNameCorrectTime_UpdateAlarmsOutputWithCorrectAlarmName(string alarmName, string hours, string minutes, string seconds)
        {
            // Arrange & Act
            _presenter.AddAlarm(alarmName, hours, minutes, seconds);

            // Assert
            _mockView.Verify(v => v.ShowAlarms(It.Is<string>(s => s.Contains(alarmName))), Times.Once);
        }



        [Test]
        [TestCase("TestName0", "0", "0", "10")]
        [TestCase("TestName1", "0", "10", "0")]
        [TestCase("TestName2", "10", "0", "0")]
        [TestCase("TestName3", "10", "10", "10")]
        public void AddAlarm_CorrectNameCorrectTime_UpdateCountdownLabelOutputWithCorrectAlarmCountdownTime(string alarmName, string hours, string minutes, string seconds)
        {
            // Arrange & Act
            int AlarmTimeInSeconds = (int.Parse(hours) * 3600) + (int.Parse(minutes) * 60) + int.Parse(seconds);
            TimeSpan TimeSpan = TimeSpan.FromSeconds(AlarmTimeInSeconds);

            _presenter.AddAlarm(alarmName, hours, minutes, seconds);

            // Assert
            _mockView.Verify(v => v.ViewCountdownTime(TimeSpan), Times.Once);
        }



        [Test]
        [TestCase("TestName0", "0", "0", "10")]
        [TestCase("TestName1", "0", "10", "0")]
        [TestCase("TestName2", "10", "0", "0")]
        [TestCase("TestName3", "10", "10", "10")]
        public void AddAlarm_CorrectNameCorrectTime_ShowAlarmsOutputsCorrectAlarmNameAndPriority(string alarmName, string hours, string minutes, string seconds)
        {
            // Arrange & Act

            // Calculate Priority
            DateTime timeNow = DateTime.Now;
            DateTime midnight = DateTime.Now.Date.AddDays(1);   // This will be for Tomorrows midnight, as midnight is the beginning of the day, 00:00
            TimeSpan timeDifferenceMidnightToNow = midnight - timeNow;
            int TimeDifferneceInSeconds = (int)timeDifferenceMidnightToNow.TotalSeconds;

            string alarmsNameAndPriority = $"[({alarmName}, {TimeDifferneceInSeconds})]";

            _presenter.AddAlarm(alarmName, hours, minutes, seconds);

            // Assert
            _mockView.Verify(v => v.ShowAlarms(It.Is<string>(s => s.StartsWith(alarmsNameAndPriority))), Times.Once);
        }



        [Test]
        public void AddAlarm_CorrectNameCorrectTime_ShowAlarmsOutputsCorrectAlarmNameAndPriority_MultipleAlarms()
        {
            // Arrange & Act
            _presenter.AddAlarm("TestName0", "0", "0", "10");
            _presenter.AddAlarm("TestName1", "0", "10", "0");
            _presenter.AddAlarm("TestName2", "10", "0", "0");
            _presenter.AddAlarm("TestName3", "10", "10", "10");

            // Calculate Priority
            DateTime timeNow = DateTime.Now;
            DateTime midnight = DateTime.Now.Date.AddDays(1);   // This will be for Tomorrows midnight, as midnight is the beginning of the day, 00:00
            TimeSpan timeDifferenceMidnightToNow = midnight - timeNow;
            int TimeDifferneceInSeconds = (int)timeDifferenceMidnightToNow.TotalSeconds;

            string alarmsNameAndPriority = $"[(TestName0, {TimeDifferneceInSeconds}), (TestName1, {TimeDifferneceInSeconds}), (TestName2, {TimeDifferneceInSeconds}), (TestName3, {TimeDifferneceInSeconds})]";

            // Assert
            _mockView.Verify(v => v.ShowAlarms(It.Is<string>(s => s.StartsWith(alarmsNameAndPriority))), Times.Once);
        }



        [Test]
        public void AddAlarm_CorrectNameCorrectTime_AddingAlarmsAndFillingTheQueueDisplaysTheQueueIsFullErrorMessageBox()
        {
            // Arrange & Act
            _presenter.AddAlarm("TestName0", "0", "0", "10");
            _presenter.AddAlarm("TestName1", "0", "10", "0");
            _presenter.AddAlarm("TestName2", "10", "0", "0");
            _presenter.AddAlarm("TestName3", "10", "10", "10");
            _presenter.AddAlarm("QueueIsFull", "23", "59", "59");

            // Calculate Priority
            DateTime timeNow = DateTime.Now;
            DateTime midnight = DateTime.Now.Date.AddDays(1);   // This will be for Tomorrows midnight, as midnight is the beginning of the day, 00:00
            TimeSpan timeDifferenceMidnightToNow = midnight - timeNow;
            int TimeDifferneceInSeconds = (int)timeDifferenceMidnightToNow.TotalSeconds;

            string alarmsNameAndPriority = $"[(TestName0, {TimeDifferneceInSeconds}), (TestName1, {TimeDifferneceInSeconds}), (TestName2, {TimeDifferneceInSeconds}), (TestName3, {TimeDifferneceInSeconds})]";

            // Assert
            _mockView.Verify(v => v.ShowAlarms(It.Is<string>(s => s.StartsWith(alarmsNameAndPriority))), Times.Once);
            _mockView.Verify(v => v.ShowError("The Queue is Full"), Times.Once);
        }



        [Test]
        public void RemoveAlarm_WhenQueueEmpty_ShowsTheQueueIsEmptyErrorMessageBoxInAlarmsOutput()
        {
            // Arrange & Act
            _presenter.RemoveAlarm();

            // Assert
            _mockView.Verify(v => v.ShowAlarms("The Queue is Empty"), Times.Once);
        }



        [Test]
        public void RemoveAlarm_OnAlarmRemoved_ShouldCallViewCountdownTimeWithNewTimeSpanForCountdownLabelInAlarmView()
        {
            _presenter.AddAlarm("TestName0", "0", "0", "10");
            _presenter.AddAlarm("TestName1", "0", "10", "00");

            _presenter.RemoveAlarm();

            _mockView.Verify(v => v.ViewCountdownTime(It.IsAny<TimeSpan>()), Times.AtLeastOnce);
        }



        [Test]
        public void RemoveAlarm_OnAlarmRemoved_ShouldCallShowAlarmsWithUpdatedAlarmsInAlarmView()
        {
            _presenter.AddAlarm("TestName0", "0", "0", "10");
            _presenter.AddAlarm("TestName1", "0", "10", "00");

            _presenter.RemoveAlarm();

            _mockView.Verify(v => v.ShowAlarms(It.IsAny<string>()), Times.AtLeastOnce);
        }



        [Test]
        public void RemoveAlarm_AddingAlarm_RemoveTheAlarmAtTheHeadOfTheQueueAssertsTheViewIsUpdated()
        {
            // Arrange
            _presenter.AddAlarm("TestName0", "0", "0", "10");

            // Act
            _presenter.RemoveAlarm();

            // Assert
            _mockView.Verify(v => v.ShowAlarms(It.Is<string>(s => !s.Contains("TestName0"))));
            _mockView.Verify(v => v.ShowAlarms(It.Is<string>(s => s.Contains("The Queue is Empty"))), Times.Once);
            _mockView.Verify(v => v.ViewCountdownNull(It.Is<string>(s => s.Contains("No Time to Countdown"))), Times.Once);
        }



        [Test]
        public void RemoveAlarm_AfterAddingAlarm_RemovesTheCorrectAlarmAtTheHeadOfTheQueue()
        {
            _presenter.AddAlarm("TestName0", "0", "0", "10"); // Head
            _presenter.AddAlarm("TestName1", "0", "10", "00");

            _presenter.RemoveAlarm();  

            _mockView.Verify(v => v.ShowAlarms(It.Is<string>(s => s.Contains("TestName1") && !s.Contains("TestName0"))), Times.Once);
        }



        [Test]
        public void RemoveAlarm_AfterAddingAlarm_RemovesTheCorrectAlarmAtTheHeadOfTheQueue_FullQueue()
        {
            _presenter.AddAlarm("TestName0", "0", "0", "10"); // Head
            _presenter.AddAlarm("TestName1", "0", "10", "00");
            _presenter.AddAlarm("TestName2", "0", "20", "00");
            _presenter.AddAlarm("TestName3", "0", "30", "00");

            _presenter.RemoveAlarm();

            // Calculate Priority
            DateTime timeNow = DateTime.Now;
            DateTime midnight = DateTime.Now.Date.AddDays(1);   // This will be for Tomorrows midnight, as midnight is the beginning of the day, 00:00
            TimeSpan timeDifferenceMidnightToNow = midnight - timeNow;
            int TimeDifferneceInSeconds = (int)timeDifferenceMidnightToNow.TotalSeconds;

            string removedAlarmNameAndPriority = $"[(TestName0, {TimeDifferneceInSeconds})]";
            string alarmsNameAndPriority = $"[(TestName1, {TimeDifferneceInSeconds}), (TestName2, {TimeDifferneceInSeconds}), (TestName3, {TimeDifferneceInSeconds})]";

            _mockView.Verify(v => v.ShowAlarms(It.Is<string>(s => s.Contains(alarmsNameAndPriority) && !s.Contains(removedAlarmNameAndPriority))));
        }



        [Test]
        public void StartAlarm_OnButtonClick_UpdatesTheAlarmOutputWithAStringAndCountdownLabelWithATimeSpan()
        {
            // Arrange
            _presenter.AddAlarm("TestName0", "0", "0", "10");

            // Act
            _mockView.Raise(v => v.ButtonStartTimerClickEvent += null, EventArgs.Empty);

            // Assert
            _mockView.Verify(v => v.ShowAlarms(It.IsAny<string>()), Times.AtLeastOnce);
            _mockView.Verify(v => v.ViewCountdownTime(It.IsAny<TimeSpan>()), Times.AtLeastOnce);
        }







        // Moq and Unit tests
        //https://grantwinney.com/its-possible-to-test-a-winforms-app-using-mvp/
        // https://www.codemag.com/Article/2305041/Using-Moq-A-Simple-Guide-to-Mocking-for-.NET
        // https://dev.to/zrebhi/the-ultimate-guide-to-unit-testing-in-net-c-using-xunit-and-moq-without-the-boring-examples-28ad
        // https://github.com/devlooped/moq/wiki/Quickstart
        // https://gist.github.com/nthdeveloper/13ded7fdd9dabc80b973c49df081f987
    }
}

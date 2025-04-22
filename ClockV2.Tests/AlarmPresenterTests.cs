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



        //// string alarmName, string priorityHour, string priorityMinute, string priortiySecond
        //[Test]
        //public void OnAddAlarmClick_TestingNewAlarmIsShownInTheAlarmView()
        //{
        //    // ARRANGE
        //    var clockModel = new ClockModel();
        //    var clockView = new ClockView();
        //    var clockPresenter = new ClockPresenter(clockModel, clockView);

        //    var model = new AlarmModel();
        //    var mockView = new Mock<IView>();
        //    var presenter = new AlarmPresenter(mockView.Object, new AlarmModel(), clockPresenter);


        //    // Calculate Priority
        //    DateTime timeNow = DateTime.Now;
        //    DateTime midnight = DateTime.Now.Date.AddDays(1);   // This will be for Tomorrows midnight, as midnight is the beginning of the day, 00:00
        //    TimeSpan timeDifferenceMidnightToNow = midnight - timeNow;
        //    int TimeDifferneceInSeconds = (int)timeDifferenceMidnightToNow.TotalSeconds;


        //    // ACT
        //    mockView.Raise(v => v.Button_Add_Alarm_Click += null, "Name", "1", "1", "1");


        //    // ASSERT
        //    // 1h = 3600  1m=60
        //    //($"{headCountdownTime.ToString("hh\\:mm\\:ss")}");
        //    mockView.Verify(v => v.ViewCountdownTime());

        //    var alarms = model.ShowAlarms();

        //    var result = $"[(Name, {TimeDifferneceInSeconds}])";
        //    Assert.That(alarms.Count, Is.EqualTo(1));
        //    //Assert.That(alarms[0], Is.EqualTo(result));

        //}


        [Test]
        public void AddAlarm_EmptyFields_ShouldDisplayErrorMessageBox()
        {
            // Arrange
            string alarmName = "";
            string hours = "";
            string minutes = "";
            string seconds = "";

            // Act
            _presenter.AddAlarm(alarmName, hours, minutes, seconds);

            // Assert
            _mockView.Verify(v => v.ShowError("Name not Valid"), Times.Once);
        }



        [Test]
        public void AddAlarm_EmptyFieldsNullName_ShouldDisplayErrorMessageBox()
        {
            // Arrange
            string alarmName = null;
            string hours = "0";
            string minutes = "0";
            string seconds = "0";

            // Act
            _presenter.AddAlarm(alarmName, hours, minutes, seconds);

            // Assert
            _mockView.Verify(v => v.ShowError("Name not Valid"), Times.Once);
        }



        [Test]
        public void AddAlarm_EmptyFieldsNullNameNullTime_ShouldDisplayErrorMessageBox()
        {
            // Arrange
            string alarmName = null;
            string hours = null;
            string minutes = null;
            string seconds = null;

            // Act
            _presenter.AddAlarm(alarmName, hours, minutes, seconds);

            // Assert
            _mockView.Verify(v => v.ShowError("Name not Valid"), Times.Once);
        }




        [Test]
        public void AddingAlarm_CorrectNameNoTime_ShouldDisplayErrorMessageBox()
        {
            // Arrange



            // Act

            // Assert
        }














        // Moq and Unit tests
        //https://grantwinney.com/its-possible-to-test-a-winforms-app-using-mvp/
        // https://www.codemag.com/Article/2305041/Using-Moq-A-Simple-Guide-to-Mocking-for-.NET
        // https://dev.to/zrebhi/the-ultimate-guide-to-unit-testing-in-net-c-using-xunit-and-moq-without-the-boring-examples-28ad
        // https://github.com/devlooped/moq/wiki/Quickstart
    }
}

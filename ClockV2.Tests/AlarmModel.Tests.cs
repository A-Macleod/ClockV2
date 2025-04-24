using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace ClockV2.Tests
{
    class AlarmModelTests
    {
        private Mock<IView> _mockView;
        private AlarmModel _model;
        private AlarmPresenter _presenter;
        //private ClockView _clockView;
        //private ClockModel _clockModel;
        //private ClockPresenter _mockClockPresenter;



        [SetUp]
        public void SetUp()
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
        public void HeadCountdownTime_ReturnsHeadAlarmTimeInCorrectFormat_TimeSpan()
        {
            // Arrange
            _model.AddAlarm("TestName0", 120);

            // Act
            var headCountdownTimeTimeSpan = _model.HeadCountdownTime();

            // Assert
            Assert.That(TimeSpan.FromSeconds(120), Is.EqualTo(headCountdownTimeTimeSpan), "The Correct TimeSpan should be 00:02:00");
        }



        [Test]
        [TestCase("TestName0", 01)]     // 01 second
        [TestCase("TestName1", 59)]     // 59 seconds
        [TestCase("TestName2", 3540)]   // 59 minutes
        [TestCase("TestName3", 86399)]  // 23 hours, 59 minutes, 59 seconds 
        public void HeadCountdownTime_ReturnsHeadAlarmTimeInCorrectFormat_TimeSpan_TestCase(string testName, int testTimeInSeconds)
        {
            // Arrange
            _model.AddAlarm($"{testName}", testTimeInSeconds);

            // Act
            var headCountdownTimeTimeSpan = _model.HeadCountdownTime();

            // Assert
            Assert.That(TimeSpan.FromSeconds(testTimeInSeconds), Is.EqualTo(headCountdownTimeTimeSpan), $"The Correct TimeSpan should be {headCountdownTimeTimeSpan}");
        }
























    }
}

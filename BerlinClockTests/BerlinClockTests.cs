using System;
using BerlinClock;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BerlinClockTests
{
    [TestClass]
    public class BerlinClockTests
    {
        private BerlinClock.BerlinClock _berlinClockMoq;

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        [DataRow("123")]
        [DataRow("32:30:15")]
        [DataRow("12:10")]
        public void SetTime_WrongFormat_ExceptionThrown(string time)
        {
            var unit = new BerlinClock.BerlinClock();

            unit.SetTime(time);
        }

        [TestMethod]
        public void SetTime_CorrectFormat_InternalTimeIsSet()
        {
            var unit = new BerlinClock.BerlinClock();

            unit.SetTime("12:30:15");

            Assert.IsNotNull(unit.Time);
        }

        [TestMethod]
        [DataRow("04:00:00", "OOOO", "1111")]
        [DataRow("08:00:00", "1OOO", "111O")]
        [DataRow("12:00:00", "11OO", "11OO")]
        [DataRow("16:00:00", "111O", "1OOO")]
        [DataRow("20:00:00", "1111", "OOOO")]
        public void SetTime_HourSegments_SetCorrect(string time, string fiveMinuteSegment, string oneMinuteSegment)
        {
            SetupCustomMaskedClockSegments();
            var unit = _berlinClockMoq;

            unit.SetTime(time);

            Assert.AreEqual(unit.FiveHourSegment.Display, fiveMinuteSegment);
            Assert.AreEqual(unit.OneHourSegment.Display, oneMinuteSegment);
        }

        [TestMethod]
        [DataRow("04:04:00", "OOOOOOOOOOO", "1111")]
        [DataRow("08:08:00", "1OOOOOOOOOO", "111O")]
        [DataRow("12:12:00", "11OOOOOOOOO", "11OO")]
        [DataRow("16:16:00", "111OOOOOOOO", "1OOO")]
        [DataRow("20:20:00", "1111OOOOOOO", "OOOO")]
        [DataRow("20:25:00", "11111OOOOOO")]
        [DataRow("20:30:00", "111111OOOOO")]
        [DataRow("20:35:00", "1111111OOOO")]
        [DataRow("20:40:00", "11111111OOO")]
        [DataRow("20:45:00", "111111111OO")]
        [DataRow("20:50:00", "1111111111O")]
        [DataRow("20:55:00", "11111111111")]
        public void SetTime_MinuteSegments_SetCorrect(string time, string fiveMinuteSegment, string oneMinuteSegment = null)
        {
            SetupCustomMaskedClockSegments();
            var unit = _berlinClockMoq;

            unit.SetTime(time);

            Assert.AreEqual(unit.FiveMinuteSegment.Display, fiveMinuteSegment);
            if (oneMinuteSegment != null)
            {
                Assert.AreEqual(unit.OneMinuteSegment.Display, oneMinuteSegment);
            }
        }

        [TestMethod]
        [DataRow("00:00:00", "O")]
        [DataRow("00:00:01", "1")]
        [DataRow("00:00:10", "O")]
        [DataRow("00:00:59", "1")]
        public void SetTime_SecondSegments_SetCorrect(string time, string secondSegment)
        {
            SetupCustomMaskedClockSegments();
            var unit = _berlinClockMoq;

            unit.SetTime(time);

            Assert.AreEqual(unit.SecondSegment.Display, secondSegment);
        }

        private void SetupCustomMaskedClockSegments()
        {
            _berlinClockMoq = new BerlinClock.BerlinClock();
            _berlinClockMoq.FiveHourSegment = new ClockSegment("1111");
            _berlinClockMoq.OneHourSegment = new ClockSegment("1111");
            _berlinClockMoq.FiveMinuteSegment = new ClockSegment("11111111111");
            _berlinClockMoq.OneMinuteSegment = new ClockSegment("1111");
            _berlinClockMoq.SecondSegment = new ClockSegment("1");
        }
    }
}

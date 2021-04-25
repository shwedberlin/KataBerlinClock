﻿using BerlinClock;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BerlinClockTests
{
    [TestClass]
    public class ClockSegmentTests
    {
        private const char OFF = 'O';

        [TestMethod]
        [DataRow("Y", 5)]
        [DataRow("YYYYYYYY", 5)]
        [DataRow("YYYYYYYY", 0)]
        public void SetDisplay_All(string segmentMask, int lampsOn)
        {
            var unit = new ClockSegment(segmentMask);
            
            unit.SetDisplay(lampsOn);

            int lampsOffCnt = lampsOn >= segmentMask.Length ? 0 : segmentMask.Length - lampsOn;
            if (lampsOffCnt == 0)
            {
                Assert.AreEqual(unit.Display, segmentMask);
                Assert.IsFalse(unit.Display.Contains(OFF));
            }
            else
            {
                Assert.IsTrue(segmentMask.Contains(unit.Display.Substring(0, lampsOn)));
                Assert.IsTrue(unit.Display.Contains(string.Empty.PadRight(lampsOffCnt, OFF)));
            }
        }
    }
}

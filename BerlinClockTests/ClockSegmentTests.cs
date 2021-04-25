using BerlinClock;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BerlinClockTests
{
    [TestClass]
    public class ClockSegmentTests
    {
        [TestMethod]
        [DataRow("Y", 5)]
        [DataRow("YYY", 3)]
        public void SetDisplay_AllLampsOn(string segmentMask, int lampsOn)
        {
            SetDisplay_GenericTest(segmentMask, lampsOn);
        }

        [TestMethod]
        [DataRow("YYYYYYYY", 0)]
        public void SetDisplay_AllLampsOff(string segmentMask, int lampsOn)
        {
            SetDisplay_GenericTest(segmentMask, lampsOn);
        }

        [TestMethod]
        [DataRow("YYYYYYYY", 5)]
        public void SetDisplay_CorrectLampsOn(string segmentMask, int lampsOn)
        {
            SetDisplay_GenericTest(segmentMask, lampsOn);
        }
        
        private void SetDisplay_GenericTest(string segmentMask, int lampsOn)
        {
            var unit = new ClockSegment(segmentMask);
            
            unit.SetDisplay(lampsOn);

            int lampsOffCnt = lampsOn >= segmentMask.Length ? 0 : segmentMask.Length - lampsOn;
            if (lampsOffCnt == 0)
            {
                Assert.AreEqual(unit.Display, segmentMask);
                Assert.IsFalse(unit.Display.Contains(ClockSegment.OFF));
            }
            else
            {
                Assert.IsTrue(segmentMask.Contains(unit.Display.Substring(0, lampsOn)));
                Assert.IsTrue(unit.Display.Contains(string.Empty.PadRight(lampsOffCnt, ClockSegment.OFF)));
            }
        }
    }
}

using System;
using System.Globalization;

namespace BerlinClock
{
    public class BerlinClock
    {
        public ClockSegment FiveHourSegment { get; internal set; } = new ClockSegment("RRRR");
        public ClockSegment OneHourSegment { get; internal set; } = new ClockSegment("RRRR");
        public ClockSegment FiveMinuteSegment { get; internal set; } = new ClockSegment("YYRYYRYYRYY");
        public ClockSegment OneMinuteSegment { get; internal set; } = new ClockSegment("YYYY");
        public ClockSegment SecondSegment { get; internal set; } = new ClockSegment("Y");

        internal TimeSpan Time;

        public override string ToString()
        {
            return $"{SecondSegment.Display}{Environment.NewLine}"+
                   $"{FiveHourSegment.Display}{Environment.NewLine}" +
                   $"{OneHourSegment.Display}{Environment.NewLine}" +
                   $"{FiveMinuteSegment.Display}{Environment.NewLine}" +
                   $"{OneMinuteSegment.Display}{Environment.NewLine}";
        }

        public void SetTime(string time)
        {
            if (!TimeSpan.TryParseExact(time, @"hh\:mm\:ss", CultureInfo.InvariantCulture,
                TimeSpanStyles.None, out Time))
            {
                throw new FormatException("Time format is wrong. Use hh:mm:ss");
            }
            
            SetHourSegments(Time.Hours);
            SetMinuteSegments(Time.Minutes);
            SetSecondSegment(Time.Seconds);
        }

        private void SetHourSegments(int hour)
        {
            FiveHourSegment.SetDisplay(hour / 5);
            OneHourSegment.SetDisplay(hour % 5);
        }

        private void SetMinuteSegments(int minute)
        {
            FiveMinuteSegment.SetDisplay(minute / 5);
            OneMinuteSegment.SetDisplay(minute % 5);
        }

        private void SetSecondSegment(int second)
        {
            SecondSegment.SetDisplay(second % 2);
        }
    }
}

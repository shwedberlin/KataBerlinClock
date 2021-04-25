using System;

namespace BerlinClock
{
    public class BerlinClock
    {
        public ClockSegment FiveHourSegment {  get; }
        public ClockSegment OneHourSegment { get; }
        public ClockSegment FiveMinuteSegment { get; }
        public ClockSegment OneMinuteSegment { get; }
        public ClockSegment SecondSegment { get; }

        public BerlinClock()
        {
            FiveHourSegment = new ClockSegment("RRRR");
            OneHourSegment = new ClockSegment("RRRR");
            FiveMinuteSegment =  new ClockSegment("YYRYYRYYRYY");
            OneMinuteSegment = new ClockSegment("YYYY");
            SecondSegment = new ClockSegment("Y");
        }

        public string ToString()
        {
            return $"{SecondSegment.Display}{Environment.NewLine}"+
                   $"{FiveHourSegment.Display}{Environment.NewLine}" +
                   $"{OneHourSegment.Display}{Environment.NewLine}" +
                   $"{FiveMinuteSegment.Display}{Environment.NewLine}" +
                   $"{OneMinuteSegment.Display}{Environment.NewLine}" +;
        }

        public void SetTime(string time)
        {
            throw new NotImplementedException();
        }
    }
}

using System;

namespace BerlinClock
{
    public class ClockSegment
    {
        public string Mask { get; }
        public string Display { get; }

        private const char OFF = 'O';

        public ClockSegment(string mask)
        {
            Mask = mask;
        }

        public void SetDisplay(int places)
        {
            throw new NotImplementedException();
        }
    }
}

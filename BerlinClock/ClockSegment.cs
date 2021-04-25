namespace BerlinClock
{
    public class ClockSegment
    {
        public string Mask { get; }
        public string Display { get; private set; }

        internal const char OFF = 'O';
        private int SegmentLength;

        public ClockSegment(string mask)
        {
            Mask = mask;
            SegmentLength = Mask.Length;
        }

        public void SetDisplay(int places)
        {
            if (places >= SegmentLength)
            {
                Display = Mask;
            }
            else if (places == 0)
            {
                Display = string.Empty.PadRight(SegmentLength, OFF);
            }
            else
            {
                Display = Mask.Substring(0, places).PadRight(SegmentLength, OFF);
            }
        }
    }
}

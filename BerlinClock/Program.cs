using System;

namespace BerlinClock
{
    class Program
    {
        static void Main(string[] args)
        {
            var berlinClock = new BerlinClock();
            Console.WriteLine("Please enter time in hh:mm:ss...");
            var time = Console.ReadLine();

            berlinClock.SetTime(time);
            Console.WriteLine($"Your time in Berlin Clock format is: {Environment.NewLine}{berlinClock.ToString()}");
        }
    }
}

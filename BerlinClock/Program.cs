using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("BerlinClockTests")]
namespace BerlinClock
{
    class Program
    {
        static void Main(string[] args)
        {
            var berlinClock = new BerlinClock();
            Console.WriteLine("Please enter time in hh:mm:ss");

            var input = Console.ReadLine();
            try
            {
                berlinClock.SetTime(input);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            Console.WriteLine($"Your time in Berlin Clock format is: {Environment.NewLine}{berlinClock.ToString()}");
        }
    }
}

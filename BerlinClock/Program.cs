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

            while (true)
            {
                berlinClock = new BerlinClock();
                Console.WriteLine("Please enter time in hh:mm:ss or type 'exit'");
                
                var input = Console.ReadLine();
                Console.WriteLine();

                if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    return;
                }

                try
                {
                    berlinClock.SetTime(input);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e);
                    continue;
                }
                Console.WriteLine($"Your time in Berlin Clock format is: {Environment.NewLine}{berlinClock.ToString()}");
            }
        }
    }
}

using System;
using System.Diagnostics;

namespace PrimeNumbersAgain
{
    class Program
    {
        static void Main(string[] args)
        {
            int n, prime;
            Stopwatch timer = new Stopwatch();

            PrintBanner();
            n = GetNumber();

            timer.Start();
            prime = FindNthPrime(n);
            timer.Stop();
            
            
            Console.WriteLine($"\nToo easy.. {prime} is the nth prime when n is {n}. I found that answer in {timer.Elapsed.Seconds} seconds.");

            EvaluatePassingTime(timer.Elapsed.Seconds);
        }

        static int FindNthPrime(int n)
        {
            if (n == 1) return 2; // The first prime is 2

            int count = 1; // We already found the first prime (2)
            int candidate = 3; // Start checking from 3

            while (count < n)
            {
                if (IsPrime(candidate))
                {
                    count++;
                }

                if (count < n)
                {
                    candidate += 2; // Check only odd numbers after 2
                }
            }

            return candidate;
        }

        static bool IsPrime(int num)
        {
            if (num < 2) return false;
            if (num == 2) return true;
            if (num % 2 == 0) return false;

            int limit = (int)Math.Sqrt(num); // Only check up to the square root of num
            for (int i = 3; i <= limit; i += 2)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }
            return true;
        }


        static int GetNumber()
        {
            int n = 0;
            while (true)
            {
                Console.Write("Which nth prime should I find?: ");
                
                string num = Console.ReadLine();
                if (Int32.TryParse(num, out n))
                {
                    return n;
                }

                Console.WriteLine($"{num} is not a valid number.  Please try again.\n");
            }
        }

        static void PrintBanner()
        {
            Console.WriteLine(".................................................");
            Console.WriteLine(".#####...#####...######..##...##..######...####..");
            Console.WriteLine(".##..##..##..##....##....###.###..##......##.....");
            Console.WriteLine(".#####...#####.....##....##.#.##..####.....####..");
            Console.WriteLine(".##......##..##....##....##...##..##..........##.");
            Console.WriteLine(".##......##..##..######..##...##..######...####..");
            Console.WriteLine(".................................................\n\n");
            Console.WriteLine("Nth Prime Solver O-Matic Online..\nGuaranteed to find primes up to 2 million in under 3 seconds!\n\n");
            
        }

        static void EvaluatePassingTime(int time)
        {
            Console.WriteLine("\n");
            Console.Write("Time Check: ");

            if (time <= 3)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Pass");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Fail");
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            
        }
    }
}

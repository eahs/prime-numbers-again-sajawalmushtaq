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
            // Use an approximate limit based on the Prime Number Theorem
            // nth prime is approximately n * log(n)
            int limit = (int)(n * Math.Log(n) * 1.2); // 1.2 to ensure we cover all cases
            bool[] isPrime = new bool[limit + 1];

            // Initialize the array
            for (int i = 2; i <= limit; i++)
                isPrime[i] = true;

            // Sieve of Eratosthenes
            for (int p = 2; p * p <= limit; p++)
            {
                if (isPrime[p])
                {
                    for (int multiple = p * p; multiple <= limit; multiple += p)
                        isPrime[multiple] = false;
                }
            }

            // Collecting the primes
            int count = 0;
            for (int i = 2; i <= limit; i++)
            {
                if (isPrime[i])
                {
                    count++;
                    if (count == n)
                        return i; // Return the nth prime
                }
            }

            return -1; // If no prime is found (shouldn't happen)
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

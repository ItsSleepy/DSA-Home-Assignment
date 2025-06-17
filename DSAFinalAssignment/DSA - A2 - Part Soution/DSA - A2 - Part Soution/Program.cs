using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace DSA___A2___Part_Soution
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // PART 1: PROVE CORRECTNESS
            var prng = new SplitMix64();
            List<ulong> numbers = new List<ulong>();
            ulong min = 1, max = 1000;
            for (int i = 0; i < 100; i++)
            {
                numbers.Add(prng.Next(min, max));
            }

            // Check all numbers in range
            bool allInRange = true;
            foreach (var n in numbers)
            {
                if (n < min || n > max)
                {
                    allInRange = false;
                    break;
                }
            }

            // Check not sorted ascending
            bool isAscending = true;
            for (int i = 1; i < numbers.Count; i++)
            {
                if (numbers[i] < numbers[i - 1])
                {
                    isAscending = false;
                    break;
                }
            }

            // Check not sorted descending
            bool isDescending = true;
            for (int i = 1; i < numbers.Count; i++)
            {
                if (numbers[i] > numbers[i - 1])
                {
                    isDescending = false;
                    break;
                }
            }

            Console.WriteLine("All numbers in range 1-1000: " + allInRange);
            Console.WriteLine("Numbers not sorted ascending: " + !isAscending);
            Console.WriteLine("Numbers not sorted descending: " + !isDescending);

            // PART 2: INTRACTABILITY TESTS
            ulong[] sizes = { 1000, 10000, 100000, 1000000 };
            List<string> timingResults = new List<string>();
            foreach (var size in sizes)
            {
                prng = new SplitMix64(); // Reset for fairness
                var sw = Stopwatch.StartNew();
                for (ulong i = 0; i < size; i++)
                {
                    prng.Next(min, max);
                }
                sw.Stop();
                string result = $"Generated {size} numbers in {sw.Elapsed.TotalMilliseconds:F4} ms";
                Console.WriteLine(result);
                timingResults.Add($"{size},{sw.Elapsed.TotalMilliseconds:F4}");
            }

            // Optionally write timings to CSV for Excel plotting
            File.WriteAllLines("SplitMix64_timings.csv", timingResults);
            Console.WriteLine("Timing results saved to SplitMix64_timings.csv");

            Console.WriteLine("\nPress Enter to exit...");
            Console.ReadLine();
        }
    }
}

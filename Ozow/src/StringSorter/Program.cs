using System;
using System.Collections.Generic;
using System.Linq;

namespace StringSorter
{
    class Program
    {

        /*
            --- TASK
            Write a program that takes any arbitrary piece of text as input, and returns as
            output a sorted list of letters. Punctuation should be ignored, and uppercase
            letters should be mapped to lowercase. For example, given the following input:
            Contrary to popular belief, the pink unicorn flies east. Your program should
            output: aaabcceeeeeffhiiiiklllnnnnooooppprrrrssttttuuy
            Are there ways to perform a sort of this kind cheaply and without using the
            built-in libraries or a generic sort algorithm (i.e. Quicksort, Bubble sort, . . . )?
        */

        /*
            --- CONCLUSION
            The cheapest sorting algorithm in this solution would appear to be the Selection sorter
            for the input string "Contrary to popular belief, the pink unicorn flies east.". This sorting algorithm 
            is for the most part almost 4 times slower than that of the built in Array.Sort functionlity so from my
            perspective I will not call it cheap

            As for the built in libraries Linq lags quite considerably behind the Array Library sorter Array.Sort<char>()
            and this is also the fastest sorting algorithm found.
        */

        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("Please enter a string or Ctrl+C to quit");

                string inputValue = Console.ReadLine();

                var normalisedValue = StringParser.ParseString(inputValue);

                // Uncomment this line to run the performance tests
                // RunPerformanceTests(normalisedValue);

                Console.WriteLine(new SelectionSorter().ApplySort(normalisedValue));
            }
        }

        private static void RunPerformanceTests(string inputValue)
        {

            var numberOfIterations = 100;

            var baseLineLinqStats = ApplySorter(new LinqLibrarySorter(), inputValue, numberOfIterations);
            var baseLineArrayStats = ApplySorter(new ArrayLibrarySorter(), inputValue, numberOfIterations);

            List<Interfaces.ISortingAlgorithm> testSorters = new List<Interfaces.ISortingAlgorithm>()
            {
                new BubbleSorter(), new InsertSorter(), new QuickSorter(), new SelectionSorter()
            };

            List<SorterStats> sutTestResults = new List<SorterStats>();
            testSorters.ForEach(sut => 
            {
                var stats = ApplySorter(sut, inputValue, numberOfIterations);
                sutTestResults.Add(stats);
            });

            var fastestSorters = sutTestResults.OrderBy(x => x.AvgDuration).ToList();

            Console.WriteLine($"Baseline - {baseLineLinqStats.ToString()}");
            Console.WriteLine($"Baseline - {baseLineArrayStats.ToString()}");

            int place = 1;
            fastestSorters.ForEach(stat => 
            {
                Console.WriteLine($"Position {place} - {stat.ToString()}");
                place += 1;
            });

        }

        private static SorterStats ApplySorter(Interfaces.ISortingAlgorithm sortingAlgo, string input, int iterations)
        {

            long totalDuration = 0, ticksStart = 0, ticksEnd = 0;
            
            for (int iIteration = 0; iIteration < iterations; iIteration++)
            {
                ticksStart = DateTime.Now.Ticks;
                string result = sortingAlgo.ApplySort(input);
                ticksEnd = DateTime.Now.Ticks;

                totalDuration = ticksEnd - ticksStart;
            }

            var stats = new SorterStats()
            {
                SortingAlgoName = sortingAlgo.SortingName,
                TotalDuration = totalDuration,
                AvgDuration = (double)totalDuration / (double)iterations
            };

            return stats;
        }

        private class SorterStats
        {
            public long TotalDuration { get; set; }
            public double AvgDuration { get; set; }
            public string SortingAlgoName { get; set; }

            public override string ToString()
            {
                return $"{SortingAlgoName} took Avg {AvgDuration} ticks and a total of {TotalDuration} ticks";
            }
        }


    }
}

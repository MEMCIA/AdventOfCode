using System;
using System.Collections.Generic;
using System.IO;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"AdventDay4.txt";
            int rangesThatFullyCoversOtherRanges = 0;
            int overlappedRanges = 0;

            using (StreamReader sr = File.OpenText(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    List<Range> ranges = new List<Range>();
                    var rangesString = line.Split(",");
                    foreach (var item in rangesString)
                    {
                        ranges.Add(Range.CreateRange(item));
                    }
                    Range biggerRange = Range.FindLargestRange(ranges[0], ranges[1]);
                    Range smallerRange = biggerRange == ranges[0] ? ranges[1] : ranges[0];
                    if (biggerRange.FullyContains(smallerRange)) rangesThatFullyCoversOtherRanges++;
                    if (biggerRange.Overlaps(smallerRange)) overlappedRanges++;
                }
            }
            // Answer part1 
            Console.WriteLine("Number of range pairs where at least one range is fully overlapped by the second range: " + rangesThatFullyCoversOtherRanges);

            // Answer part2
            Console.WriteLine("Number of range pairs where at least one range overlaps the second range: " + overlappedRanges);
        }
    }
}

using System;

namespace Day4
{
    class Range
    {
        public Range(int start, int end)
        {
            Start = start;
            End = end;
        }

        int Start;
        int End;

        public static Range CreateRange(string rangeString)
        {
            var rangeStringList = rangeString.Split("-");
            Range range = new Range(Int32.Parse(rangeStringList[0]), Int32.Parse(rangeStringList[1]));
            return range;
        }

        public bool Overlaps(Range smallerRange)
        {
            return this.Start <= smallerRange.Start && this.End >= smallerRange.Start || this.End >= smallerRange.End && this.Start <= smallerRange.End;
        }

        public bool FullyContains(Range smallerRange)
        {
            return this.Start <= smallerRange.Start && this.End >= smallerRange.End;
        }

        public static Range FindLargestRange(Range range1, Range range2)
        {
            int range1Size = range1.End - range1.Start;
            int range2Size = range2.End - range2.Start;

            if (range1Size > range2Size)
            {
                return range1;
            }
            else
            {
                return range2;
            }
        }
    }
}

using System;

namespace Day5
{
    class Move
    {
        public Move(int cratesToMove, int fromList, int toList)
        {
            CratesToMove = cratesToMove;
            FromList = fromList;
            ToList = toList;
        }

        public int CratesToMove { get; private set; }
        public int FromList { get; private set; }
        public int ToList { get; private set; }

        public static Move CreateMove(string line)
        {
            var lineSplit = line.Split(" ");
            int cratesToMove = Int32.Parse(lineSplit[1]);
            int fromList = Int32.Parse(lineSplit[3]) - 1;
            int toList = Int32.Parse(lineSplit[5]) - 1;
            return new Move(cratesToMove, fromList, toList);
        }
    }
}

using System;
using System.IO;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            int rockNumber = 1;
            int scissorsNumber = 3;
            int paperNumber = 2;

            //Exercise 1
            string path = @"../../../adventDay2.txt";
            string line;
            int points = 0;
            using (StreamReader sr = File.OpenText(path))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    int myMove = FindMoveNumber(line[2].ToString());
                    int otherElfMove = FindMoveNumber(line[0].ToString());
                    points += PointsForMove(otherElfMove, myMove);
                }
            }
            // answer day2 part 1
            Console.WriteLine("points: " + points);

            //Exercise 2
            int pointsPart2 = 0;
            using (StreamReader sr = File.OpenText(path))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    string myMove = line[2].ToString();
                    string otherElfMove = line[0].ToString();
                    pointsPart2 += PointsForMovePart2(otherElfMove, myMove);
                }
            }
            // answer day2 part 2
            Console.WriteLine("points part 2: " + pointsPart2);

            int FindMoveNumber(string move)
            {
                int moveNumber = 0;
                switch (move)
                {
                    case "A":
                    case "X":
                        moveNumber = rockNumber;
                        break;
                    case "Y":
                    case "B":
                        moveNumber = paperNumber;
                        break;
                    case "Z":
                    case "C":
                        moveNumber = scissorsNumber;
                        break;
                }
                return moveNumber;
            }

            int PointsForMove(int otherElfMove, int myMove)
            {
                int points = 0;
                points += myMove;

                if (myMove == scissorsNumber && otherElfMove == rockNumber) myMove = -3;
                if (myMove == rockNumber && otherElfMove == scissorsNumber) otherElfMove = -3;

                if (myMove == otherElfMove) points += 3;
                if (myMove > otherElfMove) points += 6;
                return points;
            }

            int PointsForMovePart2(string otherElfMove, string myMove)
            {
                string win = "Z";
                string lose = "X";
                string draw = "Y";
                string scissors = "C";
                string paper = "B";
                string rock = "A";

                int points = 0;
                if (myMove == draw)
                {
                    points += 3;
                    points += FindMoveNumber(otherElfMove);
                }

                if (myMove == win)
                {
                    points += 6;
                    if (otherElfMove == rock) points += paperNumber;
                    if (otherElfMove == paper) points += scissorsNumber;
                    if (otherElfMove == scissors) points += rockNumber;
                }

                if (myMove == lose)
                {
                    if (otherElfMove == rock) points += scissorsNumber;
                    if (otherElfMove == paper) points += rockNumber;
                    if (otherElfMove == scissors) points += paperNumber;
                }

                return points;
            }
        }
    }
}

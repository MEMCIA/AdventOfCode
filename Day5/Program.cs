using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day5
{
    class Program
    {
        static void Main(string[] args)
        {
            var oneCrateLength = 4;
            int cratesListsNumber = 0;
            List<List<char>> crates = new List<List<char>>();
            List<List<char>> cratesExercise2 = new List<List<char>>();
            string path = @"../../../AdventDay5.txt";

            using (StreamReader sr = File.OpenText(path))
            {
                double a = 7;
                double result = checked(15 / (double)a);
                string line;
                bool firstStage = true;
                while ((line = sr.ReadLine()) != null)
                {
                    if (crates.Count == 0)
                    {
                        crates = CreateCratesList(line);
                        cratesExercise2 = CreateCratesList(line);
                    }
                    if (line == "")
                    {
                        firstStage = false;
                        continue;
                    }

                    if (firstStage)
                    {
                        AddCrates(line, crates);
                        AddCrates(line, cratesExercise2);
                    }
                    else
                    {
                        Move move = Move.CreateMove(line);
                        MoveCrates(move);
                        MoveCrates2(move);
                    }
                }
            }

            //Answer ecxercise 1
            string topcratesLetters = FindTopCratesLetters(crates);
            Console.WriteLine("Top crates chars in exercise 1: " + topcratesLetters);

            //Answer ecxercise 2
            string topcratesLettersExercise2 = FindTopCratesLetters(cratesExercise2);
            Console.WriteLine("Top crates chars in exercise 2: " + topcratesLettersExercise2);

            string FindTopCratesLetters(List<List<char>> cratesList)
            {
                string topCratersLetters = "";
                foreach (var list in cratesList)
                {
                    topCratersLetters += list[0];
                }
                return topCratersLetters;
            }

            void MoveCrates(Move move)
            {
                for (int i = 0; i < move.CratesToMove; i++)
                {
                    crates[move.ToList].Insert(0, (crates[move.FromList][0]));
                    crates[move.FromList].RemoveAt(0);
                }
            }

            void MoveCrates2(Move move)
            {
                var cratesToMove = cratesExercise2[move.FromList].Take(move.CratesToMove);
                cratesExercise2[move.ToList].InsertRange(0, cratesToMove);
                cratesExercise2[move.FromList].RemoveRange(0, move.CratesToMove);
            }

            void AddCrates(string line, List<List<char>> cratesList)
            {
                int currentCrate = 1;
                for (int i = 0; i < cratesListsNumber; i++)
                {
                    char crate = line[currentCrate];
                    if (Int32.TryParse(crate.ToString(), out int number)) continue;
                    if (crate != Char.Parse(" "))
                    {
                        cratesList[i].Add(crate);
                    }
                    currentCrate += oneCrateLength;
                }
            }

            List<List<char>> CreateCratesList(string line)
            {
                cratesListsNumber = (line.Length + 1) / oneCrateLength;
                List<List<char>> cratesList = new List<List<char>>(cratesListsNumber);

                for (int i = 0; i < cratesListsNumber; i++)
                {
                    cratesList.Add(new List<char>());
                }
                return cratesList;
            }
        }
    }
}

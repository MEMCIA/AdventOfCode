using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day8
{
    class Program
    {
        static void Main(string[] args)
        {
            //Exercise 1
            string path = @"../../../Day8.txt";
            List<List<Tree>> treesColumns = new List<List<Tree>>();
            List<List<Tree>> treesRows2 = new List<List<Tree>>();
            int treesColumnsCount = treesColumns.Count();

            using (StreamReader sr = File.OpenText(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    int treesInRowNumber = line.Count();
                    var treesInRow = CreateTreesInRowList(line);
                    CheckIfTreesAreVisibleFromBothSides(treesInRow);
                    if (treesColumns.Count() == 0) treesColumns = Tree.CreateListOfListTree(treesInRowNumber);
                    AddTreesToTreesColumns(treesInRow, treesColumns);
                }
            }
            CheckIfTreesAreVisibleInColumns();
            // Answer day 8 part 1
            Console.WriteLine("Visible trees: " + Tree.visibleTreesCounter);

            //Exercise 2
            using (StreamReader sr = File.OpenText(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    int treesInRowNumber = line.Count();
                    var treesInRow = CreateTreesInRowList(line);
                    treesRows2.Add(treesInRow);
                }
            }
            List<int> secenicScores = new List<int>();
            FindTotalScenicScore();
            int maxScenicScore = secenicScores.Max();
            // Answer day 8 part 1
            Console.WriteLine("Max scenic score: " + maxScenicScore);

            void FindTotalScenicScore()
            {
                int treesCount = treesRows2.Count();
                for (int i = 0; i < treesCount; i++)
                {
                    if (i == 0 || i == treesCount - 1) continue;
                    int columnLength = treesRows2[i].Count();

                    for (int j = 0; j < columnLength; j++)
                    {
                        if (j == 0 || j == columnLength - 1) continue;
                        int treesVisibleFromLeft = FindTreesVisiblesFromDirection(j, i, -1, 0);
                        int treesVisibleFromRight = FindTreesVisiblesFromDirection(j, i, 1, 0);
                        int treesVisibleFromDown = FindTreesVisiblesFromDirection(j, i, 0, 1);
                        int treesVisibleFromUp = FindTreesVisiblesFromDirection(j, i, 0, -1);
                        int scenicScore = treesVisibleFromLeft * treesVisibleFromRight * treesVisibleFromDown * treesVisibleFromUp;
                        secenicScores.Add(scenicScore);
                    }
                }
            }

            bool IsOutside(int x, int y)
            {
                return x < 0 || y < 0 || x >= treesRows2[0].Count() || y >= treesRows2.Count();
            }

            int FindTreesVisiblesFromDirection(int startX, int startY, int directionX, int directionY)
            {
                int treesVisibleOnOneSide = 0;
                int treeHeight = treesRows2[startY][startX].Height;

                while (true)
                {
                    startX += directionX;
                    startY += directionY;
                    if (IsOutside(startX, startY)) break;
                    int nextTreeHeight = treesRows2[startY][startX].Height;
                    treesVisibleOnOneSide++;
                    if (treeHeight <= nextTreeHeight) break;
                }

                return treesVisibleOnOneSide;
            }

            void CheckIfTreesAreVisibleInColumns()
            {
                foreach (var column in treesColumns)
                {
                    CheckIfTreesAreVisibleFromBothSides(column);
                }
            }

            void CheckIfTreesAreVisibleFromBothSides(List<Tree> trees)
            {
                Tree.CheckIfTreesAreVisible(trees);
                trees.Reverse();
                Tree.CheckIfTreesAreVisible(trees);
            }

            void AddTreesToTreesColumns(List<Tree> treesInRow, List<List<Tree>> treesInColumns)
            {
                for (int i = 0; i < treesInColumns.Count(); i++)
                {
                    treesInColumns[i].Add(treesInRow[i]);
                }
            }

            List<Tree> CreateTreesInRowList(string line)
            {
                var treesInRow = line
                        .Select(x => new Tree(Int32.Parse(x.ToString())))
                        .ToList();
                return treesInRow;
            }
        }
    }
}

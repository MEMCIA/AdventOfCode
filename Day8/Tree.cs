using System;
using System.Collections.Generic;
using System.Linq;

namespace Day8
{
    class Tree
    {
        public Tree(int number)
        {
            Height = number;
        }

        public int Height { get; private set; }
        public bool IsVisible { get; private set; } = false;
        public static int visibleTreesCounter { get; private set; } = 0;
        public int ScenicScore = 1;

        public static void CheckIfTreesAreVisible(List<Tree> trees)
        {
            int biggestTree = -1;
            for (int i = 0; i < trees.Count(); i++)
            {
                if (biggestTree == 9) continue;
                if (biggestTree < trees[i].Height)
                {
                    biggestTree = trees[i].Height;
                    if (trees[i].IsVisible) continue;
                    trees[i].IsVisible = true;
                    visibleTreesCounter++;
                }
            }
        }

        public static List<List<Tree>> CreateListOfListTree(int length)
        {
            List<List<Tree>> trees = new List<List<Tree>>(length);
            for (int i = 0; i < length; i++)
            {
                trees.Add(new List<Tree>());
            }
            return trees;
        }
    }
}

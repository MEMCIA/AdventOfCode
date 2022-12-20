using System;
using System.IO;

namespace Day7
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"Day7.txt";
            string contentFolderSymbol = "ls";
            string goToDirectorySign = "cd";
            string subdirectorySymbol = "dir";
            string goToPreviousDirectorySign = "..";
            string mainFolderSymbol = "/";
            Folder firstFolder = new Folder();
            Folder currentFolder = firstFolder;

            using (StreamReader sr = File.OpenText(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var lineContentList = line.Split(" ");

                    if (lineContentList[0] == subdirectorySymbol)
                    {
                        currentFolder.CreateSubdirectory(lineContentList[1]);
                        continue;
                    }

                    if (lineContentList[1] == goToDirectorySign)
                    {
                        string name = lineContentList[2];
                        if (firstFolder.Name == null) firstFolder.Name = name;
                        else if (name == goToPreviousDirectorySign) currentFolder = currentFolder.Parent;
                        else if (name == mainFolderSymbol) currentFolder = firstFolder;
                        else
                        {
                            currentFolder = currentFolder.GetNextDirectory(name);
                        }
                        continue;
                    }

                    if (lineContentList[1] == contentFolderSymbol) continue;

                    int size = Int32.Parse(lineContentList[0]);
                    currentFolder.IncreaseSizeInThisDirectory(size);
                    currentFolder.AddSizeToParents(size);

                }
            }
            int sum = firstFolder.FindSumOfDirectoriesSizeNoLargerThan100000();
            // Answer day 7 part 1
            Console.WriteLine(sum);
            int theBestFolderToRemove = firstFolder.FindTheBestDirectoryToBeDeleted();
            // Answer day 7 part 2
            Console.WriteLine(theBestFolderToRemove);
        }
    }
}

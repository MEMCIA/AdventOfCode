using System;
using System.IO;
using System.Linq;

namespace Day6
{
    class Program
    {
        static void Main(string[] args)
        {
            //Exercise 1
            string path = @"../../../Day6.txt";
            int markerLength = 4;
            string characters = GetAllCaracters();
            int markerStartIndex = FindStartIndexOfSequenceWithoutDuplicatesLong(markerLength);
            int charactersNumberNeededToFindMarker = markerStartIndex + markerLength;
            // Answer day 6 part 1
            Console.WriteLine("Characters needed to find a marker: " + charactersNumberNeededToFindMarker);

            //Exercise 2
            int messageLength = 14;
            int messageStartIndex = FindStartIndexOfSequenceWithoutDuplicatesLong(messageLength);
            int charactersNumberNeededToFindMessage = messageStartIndex + messageLength;
            Console.WriteLine("Characters needed to find a marker a message: " + charactersNumberNeededToFindMessage);

            int FindStartIndexOfSequenceWithoutDuplicatesLong(int length)
            {
                int markerStartIndex = 0;
                for (int i = 0; i < characters.Length; i++)
                {
                    char[] fourCharacters = new char[length];
                    characters.CopyTo(i, fourCharacters, 0, length);
                    int lengthWithoutDuplicates = fourCharacters.Distinct().Count();
                    if (lengthWithoutDuplicates == length)
                    {
                        markerStartIndex = i;
                        break;
                    }
                }
                return markerStartIndex;
            }

            string GetAllCaracters()
            {
                using StreamReader sr = File.OpenText(path);
                string characters = "";
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    characters += line;
                }
                return characters;
            }
        }
    }
}

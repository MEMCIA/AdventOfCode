using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Exercise 1

            var path = @"caloriesNumber.txt";
            var caloriesSums = GetElfCalories(path);
            int maxCalories = caloriesSums.Max();
            Console.WriteLine(maxCalories);

            //Exercise 2
            var first3ElvesCaloriesSum = caloriesSums
                .OrderByDescending(x => x)
                .Take(3)
                .Sum();

            Console.WriteLine(first3ElvesCaloriesSum);


            List<int> GetElfCalories(string path)
            {
                List<int> caloriesSums = new List<int>();
                using (StreamReader sr = File.OpenText(path))
                {
                    int elfCaloriesSum = 0;
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (!Int32.TryParse(line, out int parsedNumber))
                        {
                            caloriesSums.Add(elfCaloriesSum);
                            elfCaloriesSum = 0;
                            continue;
                        }
                        elfCaloriesSum += parsedNumber;
                    }
                }
                return caloriesSums;
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Path to the numbers.txt file
        string filePath = Path.Combine(Environment.CurrentDirectory, "numbers.txt");

        if (!File.Exists(filePath))
            return;

        // Read all lines from the file
        string[] lines = File.ReadAllLines(filePath);

        // Initialize a dictionary to store the count of each number
        Dictionary<int, int> numberCount = new Dictionary<int, int>();

        // Iterate through each line and count the occurrences of each number
        foreach (string line in lines)
        {
            // Parse each number from the line
            string[] numbers = line.Split(' ');
            foreach (string numStr in numbers)
            {
                if (string.IsNullOrWhiteSpace(numStr)) continue;

                int num = int.Parse(numStr);

                // Increment the count of the number in the dictionary
                if (numberCount.ContainsKey(num))
                    numberCount[num]++;
                else
                    numberCount[num] = 1;
            }
        }

        // Sort the dictionary by value (occurrences) in descending order
        var sortedNumbers = numberCount.OrderByDescending(kv => kv.Value);

        // Retrieve the first five numbers with the highest occurrences
        var topFiveNumbers = sortedNumbers.Take(5);

        // Print the top five numbers and their occurrences
        Console.WriteLine("Top five numbers and their occurrences:");
        foreach (var pair in topFiveNumbers)
        {
            Console.WriteLine($"Number: {pair.Key}, Occurrences: {pair.Value}");
        }

        Console.WriteLine("***********Finish*********");
        Console.ReadLine();
    }
}
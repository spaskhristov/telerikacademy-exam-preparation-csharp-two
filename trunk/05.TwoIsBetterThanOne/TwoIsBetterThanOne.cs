using System;
using System.Collections.Generic;

class TwoIsBetterThanOne
{
    static void Main()
    {
        //first task
        string fisrtStr = Console.ReadLine();
        var firstInputParse = fisrtStr.Split(' ');
        long start = long.Parse(firstInputParse[0]);
        long end = long.Parse(firstInputParse[1]);
        var numbers = new List<long> { 3, 5 };
        int i = 0;
        while (true)
        {
            numbers.Add((numbers[i] * 10) + 3);
            numbers.Add((numbers[i] * 10) + 5);
            i++;
            if (numbers[i] > end)
                break;
        }
        long count = 0;
        foreach (var number in numbers)
        {
            if (number >= start && number <= end && IsPalindromeNumber(number))
            {
                count++;
            }
        }
        //second task
        string secondStr = Console.ReadLine();
        var secondInputParse = secondStr.Split(',');
        var listOfNumber = new List<int>();
        foreach (var numberAsString in secondInputParse)
        {
            listOfNumber.Add(int.Parse(numberAsString));
        }
        int percentile = int.Parse(Console.ReadLine());
        // answer fisrt task
        Console.WriteLine(count);
        // answer second task
        Console.WriteLine(FindElement(listOfNumber, percentile));
    }
    //first task
    static bool IsPalindromeNumber(long number)
    {
        string numberAsString = number.ToString();
        for (int i = 0; i < numberAsString.Length / 2; i++)
        {
            if (numberAsString[i] != numberAsString[numberAsString.Length - i - 1])
            {
                return false;
            }
        }
        return true;
    }
    //second task
    static int FindElement(List<int> numbers, int percentile)
    {
        numbers.Sort();
        for (int i = 0; i < numbers.Count; i++)
        {
            // int countOfSmallerOrEqualNumber = numbers.Count(t => numbers[i] >= t);
            int countOfSmallerOrEqualNumber = 0;
            for (int j = 0; j < numbers.Count; j++)
            {
                if (numbers[i] >= numbers[j])
                {
                    countOfSmallerOrEqualNumber++;
                }
            }
            if (countOfSmallerOrEqualNumber >= numbers.Count * (percentile / 100.0))
            {
                return numbers[i];
            }
        }
        return numbers[numbers.Count - 1];
    }
}
using System;
using System.Collections.Generic;
using System.Text;

class GreedyDwarf
{
    static void Main()
    {
        string inputNumbersValley = Console.ReadLine();
        int m = int.Parse(Console.ReadLine());
        int maximumResult = int.MinValue;
        for (int i = 0; i < m; i++)
        {
            string inputNumbersPatterns = Console.ReadLine();
            int result = Result(inputNumbersValley, inputNumbersPatterns);
            if (result > maximumResult)
            {
                maximumResult = result;
            }
        }
        Console.WriteLine(maximumResult);
    }
    static int Result(string inputNumbersValley, string inputNumbersPatterns)
    {
        StringBuilder sb = new StringBuilder();
        List<int> listNumbersValley = new List<int>();
        for (int i = 0; i < inputNumbersValley.Length; i++)
        {
            char ch = inputNumbersValley[i];
            int digit = 0;
            if (char.IsDigit(ch) || ch == '-')
            {
                sb.Append(ch);
            }
            else
            {
                if (sb.Length != 0)
                {
                    digit = int.Parse(sb.ToString());
                    listNumbersValley.Add(digit);
                }
                sb.Clear();
            }
            if (i == inputNumbersValley.Length - 1)
            {
                if (sb.Length != 0)
                {
                    digit = int.Parse(sb.ToString());
                    listNumbersValley.Add(digit);
                }
                sb.Clear();
            }
        }
        sb.Clear();
        List<int> listNumbersPatterns = new List<int>();
        for (int i = 0; i < inputNumbersPatterns.Length; i++)
        {
            char ch = inputNumbersPatterns[i];
            int digit = 0;
            if (char.IsDigit(ch) || ch == '-')
            {
                sb.Append(ch);
            }
            else
            {
                if (sb.Length != 0)
                {
                    digit = int.Parse(sb.ToString());
                    listNumbersPatterns.Add(digit);
                }
                sb.Clear();
            }
            if (i == inputNumbersPatterns.Length - 1)
            {
                if (sb.Length != 0)
                {
                    digit = int.Parse(sb.ToString());
                    listNumbersPatterns.Add(digit);
                }
                sb.Clear();
            }
        }
        bool[] visitValley = new bool[listNumbersValley.Count];
        int result = 0;
        int index = 0;
        bool escape = false;
        while (!escape)
        {
            for (int patternIndex = 0; patternIndex < listNumbersPatterns.Count; patternIndex++)
            {
                if (index >= listNumbersValley.Count || index < 0 || visitValley[index])
                {
                    escape = true;
                    break;
                }
                result += listNumbersValley[index];
                visitValley[index] = true;
                index += listNumbersPatterns[patternIndex];
            }
        }
        return result;
    }
}
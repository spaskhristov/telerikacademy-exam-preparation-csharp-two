using System;
using System.Text;
using System.Collections.Generic;
using System.Numerics;

class NineGagStrNum
{
    static void Main()
    {
        string number = Console.ReadLine();
        string[] numbers = { "-!", "**", "!!!", "&&", "&-", "!-", "*!!!", "&*!", "!!**!-" };
        StringBuilder sb = new StringBuilder();
        List<int> digits = new List<int>();
        foreach (char ch in number)
        {
            sb.Append(ch);
            for (int i = 0; i < numbers.Length; i++)
			{
                if (sb.ToString() == numbers[i])
                {
                    digits.Add(i);
                    sb.Clear();
                }
			}
        }
        digits.Reverse();
        BigInteger result = 0;
        for (int i = 0; i < digits.Count; i++)
        {
            result += (digits[i] * CalculatePower(i));
        }
        Console.WriteLine(result);
    }
    static BigInteger CalculatePower(int index)
    {
        BigInteger pow = 1;
        for (int i = 0; i < index; index--)
        {
            pow *= 9;
        }
        return pow;
    }
}
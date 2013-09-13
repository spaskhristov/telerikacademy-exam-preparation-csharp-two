using System;
using System.Collections.Generic;
using System.Numerics;

class DurankulakStrNum
{
    static void Main()
    {
        string number = Console.ReadLine();
        List<int> digits = new List<int>();
        int bigLetter = 0;
        int smallLetter = 0;
        foreach (char ch in number)
        {
            if (ch >= 'a' && ch <= 'z')
            {
                smallLetter = (ch - '`') * 26;
            }
            if (ch >= 'A' && ch <= 'Z')
            {
                bigLetter = ch - 'A' + smallLetter;
                digits.Add(bigLetter);
                smallLetter = 0;
                bigLetter = 0;
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
            pow *= 168;
        }
        return pow;
    }
}
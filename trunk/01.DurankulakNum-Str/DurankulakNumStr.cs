using System;

class DurankulakNumStr
{
    static void Main()
    {
        ulong n = ulong.Parse(Console.ReadLine());
        string[] digits = new string[168];
        int counter = 0;
        for (char i = 'A'; i <= 'Z'; i++)
        {
            digits[counter] = Convert.ToString(i);
            counter++;
        }
        for (char i = 'a'; i <= 'f'; i++)
        {
            for (char j = 'A'; j <= 'Z'; j++)
            {
                digits[counter] = i.ToString() + j.ToString();
                counter++;
                if (counter == 168)
                    break;
            }
        }
        if (n == 0)
        {
            Console.WriteLine("A");
        }
        else
        {
            Console.WriteLine(Num(digits, n));
        }
    }
    static string Num(string[] digits, ulong n)
    {
        string number = "";
        while (n != 0)
        {
            number = digits[n % 168] + number;
            n = n / 168;
        }
        return number;
    }
}
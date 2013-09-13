using System;

class KaspichanNumStr
{
    static void Main()
    {
        ulong n = ulong.Parse(Console.ReadLine());
        string[] digits = new string[256];
        int counter = 0;
        for (char i = 'A'; i <= 'Z'; i++)
        {
            digits[counter] = Convert.ToString(i);
            counter++;
        }
        for (char i = 'a'; i <= 'i'; i++)
        {
            for (char j = 'A'; j <= 'Z'; j++)
            {
                digits[counter] = i.ToString() + j.ToString();
                counter++;
                if (counter == 256)
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
            number = digits[n % 256] + number;
            n = n / 256;
        }
        return number;
    }
}
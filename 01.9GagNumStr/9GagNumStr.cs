using System;

class NineGagNumStr
{
    static void Main()
    {
        ulong n = ulong.Parse(Console.ReadLine());
        string[] digits = { "-!", "**", "!!!", "&&", "&-", "!-", "*!!!", "&*!", "!!**!-" };
        if (n == 0)
        {
            Console.WriteLine("-!");
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
            number = digits[n % 9] + number;
            n = n / 9;
        }
        return number;
    }
}
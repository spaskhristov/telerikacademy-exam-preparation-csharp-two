using System;

class AirplaneDrinks
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int teaCount = int.Parse(Console.ReadLine());
        int[] tea = new int[teaCount];
        for (int i = 0; i < teaCount; i++)
        {
            tea[i] = int.Parse(Console.ReadLine());
        }
        Console.WriteLine(Solve(n, tea));
    }
    static long Solve(int n, int[] tea)
    {
        long result = n * 4;
        bool[] chek = new bool[n];
        long lastTea = 0;
        long lastCoffe = 0;
        double cauntTea = 0;
        double cauntCoffe = 0;
        double machineTea = 0;
        double machineCoffe = 0;
        for (int i = 0; i < tea.Length; i++)
        {
            chek[tea[i] - 1] = true;
        }
        for (int i = n - 1; i >= 0; i--)
        {
            if (chek[i])
            {
                cauntTea++;
            }
            if (!chek[i])
            {
                cauntCoffe++;
            }
        }
        machineTea += Math.Ceiling(cauntTea / 7);
        Array.Sort(tea);
        int maxpossTea = tea[tea.Length - 1];
        machineCoffe += Math.Ceiling(cauntCoffe / 7);
        cauntTea = 0;
        cauntCoffe = 0;
        for (int i = n - 1; i >= 0; i--)
        {
            if (chek[i])
            {
                cauntTea++;
                lastTea = Math.Max(lastTea, i + 1);
            }
            if (!chek[i])
            {
                cauntCoffe++;
                lastCoffe = Math.Max(lastCoffe, i + 1);
            }
            if (cauntTea == 7)
            {
                cauntTea = 0; result += lastTea * 2; lastTea = 0;
            }
            if (cauntCoffe == 7)
            {
                cauntCoffe = 0; result += lastCoffe * 2; lastCoffe = 0;
            }
        }
        if (cauntTea != 0)
        {
            result += lastTea * 2;
        }
        if (cauntCoffe != 0)
        {
            result += lastCoffe * 2;
        }
        result += (long)((machineTea + machineCoffe) * 47);
        return result;
    }
}
using System;

class Tubes
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int m = int.Parse(Console.ReadLine());
        int[] tube = new int[n];
        int left = 0;
        int right = 0;
        int mid = 0;
        for (int i = 0; i < n; i++)
        {
            tube[i] = int.Parse(Console.ReadLine());
            if (right < tube[i])
                right = tube[i];
        }
        mid = (left + right) / 2;
        int maxTube = -1;
        int eventualTubes = 0;
        while (left <= right)
        {
            eventualTubes = 0;
            for (int i = 0; i < n; i++)
            {
                eventualTubes += tube[i] / mid;
            }
            if (eventualTubes >= m)
            {
                left = mid + 1;
                maxTube = mid;
            }
            else
            {
                right = mid - 1;
            }
            mid = (left + right) / 2;
        }
        Console.WriteLine(maxTube);
    }
}
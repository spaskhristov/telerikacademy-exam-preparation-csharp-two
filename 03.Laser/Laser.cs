using System;
using System.Linq;
using System.IO;

class Laser
{
    static void Main()
    {
        if (File.Exists("input.txt"))
        {
            Console.SetIn(new StreamReader("input.txt"));
        }
        int[] dims = GetTreeNumbersFromConsole();
        int[] pos = GetTreeNumbersFromConsole();
        int[] vect = GetTreeNumbersFromConsole();
        bool[, ,] visited = new bool[dims[0]+1, dims[1]+1, dims[2]+1];
        while (true)
        {
            visited[pos[0], pos[1], pos[2]] = true;
            int[] newPos = new int[3];
            for (int i = 0; i < 3; i++)
            {
                newPos[i] = pos[i] + vect[i];
            }
            if (visited[newPos[0], newPos[1], newPos[2]] || HowManyAreLimit(newPos, dims) == 2)
            {
                Console.WriteLine("{0} {1} {2}", pos[0], pos[1], pos[2]);
                return;
            }
            if (HowManyAreLimit(newPos, dims) == 1)
            {
                ReversComponent(newPos, vect, dims);
            }
            for (int i = 0; i < 3; i++)
            {
                pos[i] = newPos[i];
            }
        }
    }
    static void ReversComponent(int[] newPos, int[] vect, int[] dims)
    {
        for (int i = 0; i < 3; i++)
        {
            if (newPos[i] == 1 && vect[i] == -1)
            {
                vect[i] *= -1;
            }
            else if (newPos[i] == dims[i] && vect[i] == 1)
            {
                vect[i] *= -1;
            }
        }
    }
    static int HowManyAreLimit(int[] pos, int[] dims)
    {
        int count = 0;
        for (int i = 0; i < 3; i++)
        {
            if (pos[i] == 1 || pos[i] == dims[i])
            {
                count++;
            }
        }
        return count;
    }
    static int[] GetTreeNumbersFromConsole()
    {
        string input = Console.ReadLine();
        string[] split = input.Split(' ');
        /*int[] array = new int[3];
        for (int i = 0; i < 3; i++)
        {
            array[i] = int.Parse(split[i]);
        }
        return array;*/
        return split.Select(s => int.Parse(s)).ToArray();
    }
}
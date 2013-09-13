using System;
using System.Collections.Generic;

class OneTaskIsNotEnough
{
    static void Main()
    {
        // First task
        int n = int.Parse(Console.ReadLine());
        // Second task
        string commands = Console.ReadLine();
        // Second task again
        string secondCommands = Console.ReadLine();
        //result
        FindLastOpenedLamp(n);
        Console.WriteLine(FindBoundedMoves(commands));
        Console.WriteLine(FindBoundedMoves(secondCommands));
    }
    private static string FindBoundedMoves(string commands)
    {
        int[] movesX = { 1, 0, -1, 0 };
        int[] movesY = { 0, 1, 0, -1 };
        // Starting from (0,0)
        int currentX = 0, currentY = 0, direction = 0;
        for (int i = 1; i <= 4; i++)
        {
            for (int j = 0; j < commands.Length; j++)
            {
                switch (commands[j])
                {
                    case 'S':
                        currentX += movesX[direction];
                        currentY += movesY[direction];
                        break;
                    case 'L':
                        direction = (direction + 3) % 4; // +270 degrees, turns left
                        break;
                    case 'R':
                        direction = (direction + 1) % 4; // +90 degrees, turns right
                        break;
                }
            }
        }
        if (currentX == 0 && currentY == 0)
        {
            // After 4 commands execution he is back on the starting place
            return "bounded";
        }
        else
        {
            // He moved after 4 commands execution
            // He will move again and again in the same direction after every next commands execution
            return "unbounded";
        }
    }
    private static void FindLastOpenedLamp(int n)
    {
        int lastLamp = 0;
        bool[] turnOnNaw = new bool[n + 1];
        int[] turnOffLamp = new int[n + 1];
        for (int i = 1; i < n + 1; i++)
        {
            turnOffLamp[i] = i;
        }
        int jump = 1;
        while (n > 0)
        {
            jump++;
            Array.Clear(turnOnNaw, 1, n);
            for (int i = 1; i <= n; i += jump)
            {
                turnOnNaw[i] = true;
            }
            int newCountOff = 0;
            for (int i = 1; i <= n; i++)
            {
                if (!turnOnNaw[i])
                {
                    newCountOff++;
                    turnOffLamp[newCountOff] = turnOffLamp[i];
                    lastLamp = turnOffLamp[i];
                }
            }
            n = newCountOff;
        }
        Console.WriteLine(lastLamp);
    }
}
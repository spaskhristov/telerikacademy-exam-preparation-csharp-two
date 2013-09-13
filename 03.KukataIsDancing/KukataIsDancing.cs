using System;

class KukataIsDancing
{
    static void Main()
    {
        string[,] danceFloor =
        {
            {"RED", "BLUE", "RED"},
            {"BLUE", "GREEN", "BLUE"},
            {"RED", "BLUE", "RED"}
        };
        int dances = int.Parse(Console.ReadLine());
        string[] current = new string[dances];
        for (int i = 0; i < dances; i++)
        {
            string dance = Console.ReadLine();
            string direction = "up";
            int row = 1;
            int col = 1;
            for (int j = 0; j < dance.Length; j++)
            {
                switch (dance[j])
                {
                    case 'W':
                        {
                            if (direction == "up")
                            {
                                if (row > 0)
                                    row--;
                                else
                                    row = 2;
                            }
                            if (direction == "left")
                            {
                                if (col > 0)
                                    col--;
                                else
                                    col = 2;
                            }
                            if (direction == "right")
                            {
                                if (col < 2)
                                    col++;
                                else
                                    col = 0;
                            }
                            if (direction == "down")
                            {
                                if (row < 2)
                                    row++;
                                else
                                    row = 0;
                            }
                            break;
                        }
                    case 'R':
                        {
                            if (direction == "up")
                            {
                                direction = "right";
                                break;
                            }
                            if (direction == "left")
                            {
                                direction = "up";
                                break;
                            }
                            if (direction == "right")
                            {
                                direction = "down";
                                break;
                            }
                            if (direction == "down")
                            {
                                direction = "left";
                                break;
                            }
                            break;
                        }
                    case 'L':
                        {
                            if (direction == "up")
                            {
                                direction = "left";
                                break;
                            }
                            if (direction == "left")
                            {
                                direction = "down";
                                break;
                            }
                            if (direction == "right")
                            {
                                direction = "up";
                                break;
                            }
                            if (direction == "down")
                            {
                                direction = "right";
                                break;
                            }
                            break;
                        }
                }
            }
            current[i] = danceFloor[row, col];
        }
        for (int i = 0; i < dances; i++)
            Console.WriteLine(current[i]);
    }
}
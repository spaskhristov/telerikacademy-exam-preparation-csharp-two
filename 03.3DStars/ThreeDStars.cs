using System;
using System.Collections.Generic;
using System.Linq;

class ThreeDStars
{
    private static int width, height, depth, starCount;
    private static char[, ,] cube;
    private static Dictionary<char, int> starType = new Dictionary<char, int>();
    static void Main()
    {
        ReadInput();
        FindStars();
        PrintMessage();
    }
    private static void PrintMessage()
    {
        Console.WriteLine(starCount);
        foreach (var item in starType.OrderBy(i => i.Key))
        {
            Console.WriteLine("{0} {1}", item.Key, item.Value);
        }
    }
    private static void FindStars()
    {
        for (int w = 1; w < width - 1; w++)
        {
            for (int h = 1; h < height - 1; h++)
            {
                for (int d = 1; d < depth - 1; d++)
                {
                    FindSingleStar(w, h, d);
                }
            }
        }
    }
    private static void FindSingleStar(int currWidth, int currHeight, int currDepth)
    {
        char currChar = cube[currWidth, currHeight, currDepth];
        bool isStar =
            currChar == cube[currWidth - 1, currHeight, currDepth] &&
            currChar == cube[currWidth + 1, currHeight, currDepth] &&
            currChar == cube[currWidth, currHeight - 1, currDepth] &&
            currChar == cube[currWidth, currHeight + 1, currDepth] &&
            currChar == cube[currWidth, currHeight, currDepth - 1] &&
            currChar == cube[currWidth, currHeight, currDepth + 1];
        if (isStar)
        {
            starCount++;
            if (starType.ContainsKey(currChar))
            {
                starType[currChar]++;
            }
            else
            {
                starType[currChar] = 1;
            }
        }
    }
    private static void ReadInput()
    {
        string cuboidSize = Console.ReadLine();
        string[] sizes = cuboidSize.Split();
        width = int.Parse(sizes[0]);
        height = int.Parse(sizes[1]);
        depth = int.Parse(sizes[2]);
        cube = new char[width, height, depth];
        for (int h = 0; h < height; h++)
        {
            string[] lineFragment = Console.ReadLine().Split();
            for (int d = 0; d < depth; d++)
            {
                string cubeContent = lineFragment[d];
                for (int w = 0; w < width; w++)
                {
                    cube[w, h, d] = (cubeContent[w]);
                }
            }
        }
    }
}
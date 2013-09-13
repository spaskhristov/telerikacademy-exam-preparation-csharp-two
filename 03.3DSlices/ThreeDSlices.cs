using System;

class ThreeDSlices
{
    static void Main()
    {
        string[] line = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int cubeSum = 0;
        int width = int.Parse(line[0]);
        int heigth = int.Parse(line[1]);
        int depth = int.Parse(line[2]);
        int[, ,] cube = new int[width, heigth, depth];
        for (int h = 0; h < heigth; h++)
        {
            string[] currLine = Console.ReadLine().Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            for (int d = 0; d < depth; d++)
            {
                string[] rawNumbers = currLine[d].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int w = 0; w < width; w++)
                {
                    int currNum = int.Parse(rawNumbers[w]);
                    cube[w, h, d] = currNum;
                    cubeSum += currNum;
                }
            }
        }
        int allSlices = 0;
        allSlices += FindSlicesByWidth(cube, cubeSum);
        allSlices += FindSlicesByHeigth(cube, cubeSum);
        allSlices += FindSlicesByDepth(cube, cubeSum);
        Console.WriteLine(allSlices);
    }
    private static int FindSlicesByWidth(int[, ,] cube, int cubeSum)
    {
        int sliceSum = 0;
        int numOfSlices = 0;
        for (int w = 0; w < cube.GetLength(0) - 1; w++)
        {
            for (int h = 0; h < cube.GetLength(1); h++)
            {
                for (int d = 0; d < cube.GetLength(2); d++)
                {
                    sliceSum += cube[w, h, d];
                }
            }
            if (sliceSum == cubeSum / 2)
            {
                numOfSlices++;
            }
        }
        return numOfSlices;
    }
    private static int FindSlicesByHeigth(int[, ,] cube, int cubeSum)
    {
        int sliceSum = 0;
        int numOfSlices = 0;
        for (int h = 0; h < cube.GetLength(1) - 1; h++)
        {
            for (int w = 0; w < cube.GetLength(0); w++)
            {
                for (int d = 0; d < cube.GetLength(2); d++)
                {
                    sliceSum += cube[w, h, d];
                }
            }
            if (sliceSum == cubeSum / 2)
            {
                numOfSlices++;
            }
        }
        return numOfSlices;
    }
    private static int FindSlicesByDepth(int[, ,] cube, int cubeSum)
    {
        int sliceSum = 0;
        int numOfSlices = 0;
        for (int d = 0; d < cube.GetLength(2) - 1; d++)
        {
            for (int h = 0; h < cube.GetLength(1); h++)
            {
                for (int w = 0; w < cube.GetLength(0); w++)
                {
                    sliceSum += cube[w, h, d];
                }
            }
            if (sliceSum == cubeSum / 2)
            {
                numOfSlices++;
            }
        }
        return numOfSlices;
    }
}
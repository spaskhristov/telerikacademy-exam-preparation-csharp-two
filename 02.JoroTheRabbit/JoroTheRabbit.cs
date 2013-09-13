using System;

class JoroTheRabbit
{
    static void Main()
    {
        int[] numbers = ParseInput();
        int bestPath = int.MinValue;
        for (int startIndex = 0; startIndex < numbers.Length; startIndex++)
        {
            for (int step = 1; step < numbers.Length; step++)
            {
                int index = startIndex;
                int curentPath = 1;
                int next = index + step;
                if (next >= numbers.Length)
                {
                    next = next - numbers.Length;
                }
                while (numbers[index] < numbers[next])
                {
                    curentPath++;
                    index = next;
                    next = index + step;
                    if (next >= numbers.Length)
                    {
                        next = next - numbers.Length;
                    }
                }
                if (bestPath < curentPath)
                {
                    bestPath = curentPath;
                }
            }
        }
        Console.WriteLine(bestPath);
    }
    private static int[] ParseInput()
    {
        string[] inputs = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
        int[] numbers = new int[inputs.Length];
        for (int i = 0; i < inputs.Length; i++)
        {
            numbers[i] = int.Parse(inputs[i]);
        }
        return numbers;
    }
}
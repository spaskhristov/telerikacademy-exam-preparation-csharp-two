using System;
using System.Linq;

class ThreeInOne
{
    static void Main()
    {
        //task 1
        string pointsStr = Console.ReadLine();
        int[] points = ParseNumbersString(pointsStr);
        int[] pointsSort = new int[points.Length];
        for (int i = 0; i < points.Length; i++)
        {
            pointsSort[i] = points[i];
        }
        Array.Sort(pointsSort);
        Array.Reverse(pointsSort);
        int indexWinPlayer = 0;
        int winPlayer = 0;
        for (int i = 1; i < pointsSort.Length; i++)
        {
            if (pointsSort[i - 1] == pointsSort[i] && pointsSort[i - 1] <= 21)
            {
                indexWinPlayer = -1;
                break;
            }
            if (pointsSort[i - 1] > pointsSort[i])
            {
                if (pointsSort[i - 1] <= 21)
                {
                    winPlayer = pointsSort[i - 1];
                    break;
                }
                if (pointsSort[i] <= 21)
                {
                    if (pointsSort[i] == pointsSort[i + 1])
                    {
                        indexWinPlayer = -1;
                        break;
                    }
                    winPlayer = pointsSort[i];
                    break;
                }
            }
        }
        //end task 1
        //task 2
        string cakesStr = Console.ReadLine();
        int[] cakes = ParseNumbersString(cakesStr);
        Array.Sort(cakes);
        Array.Reverse(cakes);
        int numberOfFriend = int.Parse(Console.ReadLine());
        int numberOfAllFriend = numberOfFriend + 1;
        int myCakesBites = 0;
        int count = 0;
        for (int i = 0; i < cakes.Length; i++)
        {
            myCakesBites += cakes[count];
            count += numberOfAllFriend;
            if (count >= cakes.Length)
                break;
        }
        //end task 2
        //task 3
        string inputStr = Console.ReadLine();
        int[] intArray = ParseNumbersString(inputStr);
        int G1 = intArray[0];
        int S1 = intArray[1];
        int B1 = intArray[2];
        int G2 = intArray[3];
        int S2 = intArray[4];
        int B2 = intArray[5];
        //end task 3
        //task 1 answer
        if (indexWinPlayer == -1)
            Console.WriteLine(indexWinPlayer);
        else
        {
            for (int i = 0; i < points.Length; i++)
            {
                if (winPlayer == points[i])
                {
                    indexWinPlayer = i;
                    Console.WriteLine(indexWinPlayer);
                    break;
                }
            }
        }
        //task 2 answer
        Console.WriteLine(myCakesBites);
        //task 3 answer
        Console.WriteLine(BuyBeer(G1, S1, B1, G2, S2, B2));
    }
    static int[] ParseNumbersString(string numbersString)
    {
        string[] numberStrings = numbersString.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int[] numbers = numberStrings.Select(ns => int.Parse(ns)).ToArray();
        return numbers;
    }
    static int BuyBeer(int G1, int S1, int B1, int G2, int S2, int B2)
    {
        int exchangeOperations = 0;
        while (G2 > G1)
        {
            --G2;
            S2 += 11;
            exchangeOperations++;
        }
        while (S2 > S1)
        {
            if (G1 > G2)
            {
                --G1;
                S1 += 9;
                exchangeOperations++;
            }
            else
            {
                --S2;
                B2 += 11;
                exchangeOperations++;
            }
        }

        while (B2 > B1)
        {
            if (S1 > S2)
            {
                --S1;
                B1 += 9;
                exchangeOperations++;
            }
            else if (G1 > G2)
            {
                --G1;
                S1 += 9;
                exchangeOperations++;
            }
            else
            {
                return -1;
            }
        }
        return exchangeOperations;
    }
}
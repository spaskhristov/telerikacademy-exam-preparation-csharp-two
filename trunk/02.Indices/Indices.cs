using System;
using System.Collections.Generic;
using System.Text;

class Indices
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string line = Console.ReadLine();
        string[] arrStr = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int[] arr = new int[n];
        for (int i = 0; i < arrStr.Length; i++)
        {
            arr[i] = int.Parse(arrStr[i]);
        }
        List<string> result = GetListResult(arr);
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < result.Count - 1; i++)
        {
            if (result[i] != "(" && result[i + 1] != "(" && result[i + 1] != ")")
                sb.Append(result[i] + " ");
            if ((result[i] != "(" && result[i + 1] == "(") || result[i + 1] == ")")
                sb.Append(result[i]);
            if (result[i] == "(")
                sb.Append(result[i]);
        }
        sb.Append(result[result.Count - 1]);
        Console.WriteLine(sb.ToString());
    }
    private static List<string> GetListResult(int[] arr)
    {
        List<string> result = new List<string>();
        bool[] used = new bool[arr.Length];
        int firstElementInCycle = 0;
        int lastElementInCycle = 0;
        bool hasCycle = false;
        while (firstElementInCycle >= 0 && firstElementInCycle < arr.Length)
        {
            if (used[firstElementInCycle])
            {
                hasCycle = true;
                break;
            }
            used[firstElementInCycle] = true;
            lastElementInCycle = firstElementInCycle;
            firstElementInCycle = arr[lastElementInCycle];
        }
        int index = 0;
        while (index >= 0 && index < arr.Length)
        {
            if (used[index])
            {
                result.Add(index.ToString());
                if (index == firstElementInCycle && hasCycle)
                {
                    result.Remove(firstElementInCycle.ToString());
                    result.Add("(");
                    result.Add(index.ToString());
                }
            }
            if (hasCycle && index == lastElementInCycle)
            {
                result.Add(")");
                break;
            }
            index = arr[index];
        }
        return result;
    }
}
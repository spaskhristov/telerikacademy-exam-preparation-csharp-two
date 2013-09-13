using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class GenomeDecoder
{
    static void Main()
    {
        string[] strNM = Console.ReadLine().Split(' ');
        int n = int.Parse(strNM[0]);
        int m = int.Parse(strNM[1]);
        string str = Console.ReadLine();
        StringBuilder sb = new StringBuilder();
        List<char> listCh = new List<char>();
        List<int> listInt = new List<int>();
        for (int i = 0; i < str.Length; i++)
        {
            int digit = 0;
            if (!Char.IsLetter(str[i]))
                sb.Append(str[i]);
            if (Char.IsLetter(str[i]))
            {
                listCh.Add(str[i]);
                if (sb.Length == 0)
                {
                    listInt.Add(1);
                }
                else
                {
                    digit = int.Parse(sb.ToString());
                    listInt.Add(digit);
                }
                sb.Clear();
            }
        }
        List<char> listRes = new List<char>();
        for (int i = 0; i < listCh.Count; i++)
        {
            for (int j = 0; j < listInt[i]; j++)
            {
                listRes.Add(listCh[i]);
            }
        }
        sb.Clear();
        int count = 0;
        int countRow = 1;
        int lastRow = 0;
        if (listRes.Count % n == 0)
            lastRow = listRes.Count / n;
        if (listRes.Count % n != 0)
            lastRow = (listRes.Count / n) + 1;
        int padSize = lastRow.ToString().Length;
        for (int i = 0; i < listRes.Count; i++)
        {
            if (count == 0)
                sb.Append(countRow.ToString().PadLeft(padSize, ' ') + " ");
            count++;
            sb.Append(listRes[i]);
            if (count % m == 0 && count != n)
                sb.Append(" ");
            if ((i + 1) % n == 0)
            {
                count = 0;
                countRow++;
                Console.WriteLine(sb);
                sb.Clear();
            }
            if (countRow == lastRow && i == listRes.Count - 1)
            {
                Console.WriteLine(sb);
            }
        }
    }
}
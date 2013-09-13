using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

class Justification
{
    static void Main()
    {
        int inputLines = int.Parse(Console.ReadLine());
        int lineLenght = int.Parse(Console.ReadLine());
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < inputLines; i++)
        {
            sb.Append(string.Format(" {0} ", Console.ReadLine()));
        }
        string[] words = sb.ToString().Split(new char[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        sb.Clear();
        int wordIndex = 0;
        while (wordIndex < words.Length)
        {
            sb.Append(words[wordIndex]);
            string strLine = sb.ToString();
            int wordsLength = strLine.Length;
            sb.Append(" ");
            if (lineLenght == wordsLength)
            {
                Console.WriteLine(strLine);
                sb.Clear();
                strLine = "";
            }
            if (lineLenght < wordsLength)
            {
                string word = words[wordIndex];
                int countIndexWord = words[wordIndex].Length;
                sb.Replace(word, " ", wordsLength - countIndexWord, countIndexWord);
                strLine = sb.ToString();
                Print(strLine, lineLenght);
                sb.Clear();
                strLine = "";
                wordIndex--;
            }
            if (wordIndex == words.Length - 1 && lineLenght > wordsLength)
            {
                Print(strLine, lineLenght);
                sb.Clear();
                strLine = "";
                break;
            }
            wordIndex++;
        }
    }
    static void Print(string strLine, int lineLenght)
    {
        string[] words = strLine.Split(new char[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        int wordsLenght = 0;
        if (words.Length == 1)
        {
            Console.WriteLine(words[0]);
            return;
        }
        for (int i = 0; i < words.Length; i++)
        {
            wordsLenght += words[i].Length;
        }
        int countSpace = words.Length - 1;
        int strSpace = lineLenght - wordsLenght;
        int initialGap = strSpace / countSpace;
        int gap = strSpace % countSpace;
        for (int i = 0; i < words.Length; i++)
        {
            if (i == 0)
            {
                Console.Write(words[i]);
            }
            else if (i <= gap)
            {
                Console.Write("{0}{1}", new String(' ', initialGap + 1), words[i]);
            }
            else
            {
                Console.Write("{0}{1}", new String(' ', initialGap), words[i]);
            }
        }
        Console.WriteLine();
    }
}
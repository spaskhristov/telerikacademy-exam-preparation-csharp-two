using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.FTML
{
    class Program
    {
        private const string revTagOpen = "<rev>";
        private const string upperTagOpen = "<upper>";
        private const string lowerTagOpen = "<lower>";
        private const string toggleTagOpen = "<toggle>";
        private const string delTagOpen = "<del>";
        private const string revTagClose = "</rev>";
        private const string upperTagClose = "</upper>";
        private const string lowerTagClose = "</lower>";
        private const string toggleTagClose = "</toggle>";
        private const string delTagClose = "</del>";
        private static int openedDelTags = 0;
        private static StringBuilder output = new StringBuilder();
        private static List<string> currentOpenTag = new List<string>();
        private static List<int> revTagStarts = new List<int>();
        private static void Main()
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfLines; i++)
            {
                string currentLine = Console.ReadLine();
                int currentSymbolIndex = 0;
                while (currentSymbolIndex < currentLine.Length)
                {
                    if (currentLine[currentSymbolIndex] == '<')
                    {
                        string tag = GetTag(currentLine, currentSymbolIndex);
                        ProcessTag(tag);
                        currentSymbolIndex += tag.Length - 1;
                    }
                    else
                    {
                        if (openedDelTags == 0)
                        {
                            char symbolToAdd = currentLine[currentSymbolIndex];
                            for (int j = currentOpenTag.Count - 1; j >= 0; j--)
                            {
                                symbolToAdd = ApplayEffects(symbolToAdd, currentOpenTag[j]);
                            }
                            output.Append(symbolToAdd);
                        }
                    }
                    currentSymbolIndex++;
                }
                output.Append('\n');
            }
            Console.WriteLine(output.ToString().Trim());
        }
        private static char ApplayEffects(char symbolToAdd, string currentOpenTag)
        {
            if (char.IsLetter(symbolToAdd))
            {
                if (currentOpenTag == upperTagOpen)
                {
                    symbolToAdd = char.ToUpper(symbolToAdd);
                }
                else if (currentOpenTag == lowerTagOpen)
                {
                    symbolToAdd = char.ToLower(symbolToAdd);
                }
                else if (currentOpenTag == toggleTagOpen)
                {
                    if (char.IsLower(symbolToAdd))
                    {
                        symbolToAdd = char.ToUpper(symbolToAdd);
                    }
                    else
                    {
                        symbolToAdd = char.ToLower(symbolToAdd);
                    }
                }
            }
            return symbolToAdd;
        }
        private static void ProcessTag(string tag)
        {
            if (tag == delTagOpen)
            {
                openedDelTags++;
            }
            else if (tag == delTagClose)
            {
                openedDelTags--;
            }
            else
            {
                if (openedDelTags == 0)
                {

                    if (tag == revTagOpen)
                    {
                        revTagStarts.Add(output.Length);
                    }
                    if (tag == revTagClose)
                    {
                        int currentRevStart = revTagStarts[revTagStarts.Count - 1];
                        int revEnd = output.Length - 1;
                        Revers(currentRevStart, revEnd);
                        revTagStarts.RemoveAt(revTagStarts.Count - 1);
                    }
                    if (tag[1] == '/')
                    {
                        currentOpenTag.RemoveAt(currentOpenTag.Count - 1);
                    }
                    else
                    {
                        currentOpenTag.Add(tag);
                    }
                }
            }
        }
        private static void Revers(int currentRevStart, int revEnd)
        {
            int start = currentRevStart;
            int end = revEnd;
            while (start < end)
            {
                char bufferChar = output[start];
                output[start] = output[end];
                output[end] = bufferChar;
                end--;
                start++;
            }
        }
        private static string GetTag(string currentLine, int symbolIndex)
        {
            int tagsStart = symbolIndex;
            int tagsEnd = currentLine.IndexOf('>', tagsStart + 1);
            string tag = currentLine.Substring(tagsStart, tagsEnd - tagsStart + 1);
            return tag;
        }
    }
}
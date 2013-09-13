using System;
using System.Collections.Generic;
using System.Text;

class BasicLanguage
{
    static void Main()
    {
        List<string> textList = new List<string>();
        List<char> commandList = new List<char>();
        StringBuilder sb = new StringBuilder();
        while (true)
        {
            string line = Console.ReadLine();
            sb.AppendLine(line);
            if (line.EndsWith("EXIT;")) break;
        }
        string text = sb.ToString();
        sb.Clear();
        bool isComments = false;
        for (int i = 0; i < text.Length; i++)
        {
            char ch = text[i];
            if (ch == 'F' && !isComments)
            {
                sb.Clear();
                commandList.Add('1');
            }
            if (ch == 'P' && !isComments)
            {
                sb.Clear();
                commandList.Add('2');
            }
            if (ch == '(' && !isComments)
            {
                isComments = true;
                continue;
            }
            if (isComments && ch != ')')
            {
                sb.Append(ch);
            }
            if (ch == ')' && sb.ToString().Length > 0)
            {
                isComments = false;
                textList.Add(sb.ToString());
                sb.Clear();
            }
        }
        int tagCount = 1;
        sb.Clear();
        for (int i = 0; i < commandList.Count; i++)
        {
            if (commandList[i] == '1')
            {
                tagCount *= GetTag(textList[i]);
            }
            if (commandList[i] == '2')
            {
                for (int j = 0; j < tagCount; j++)
                {
                    sb.Append(textList[i]);
                }
                tagCount = 1;
            }
        }
        Console.WriteLine(sb);
    }
    static int GetTag(string tag)
    {
        string[] tags = tag.Split(',');
        int tagCount = 0;
        if (tags.Length == 1)
        {
            tagCount = int.Parse(tags[0]);
        }
        else
        {
            int a = int.Parse(tags[0]);
            int b = int.Parse(tags[1]);
            tagCount = b - a + 1;
        }
        return tagCount;
    }
}
using System;
using System.Text;
using System.Text.RegularExpressions;

class CSharpBrackets
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string pad = Console.ReadLine();
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < n; i++)
        {
            sb.Append(Console.ReadLine().Trim());
            sb.Append("\0");
        }
        string line = sb.ToString().Replace("{", "\0{\0").Replace("}", "\0}\0").Trim();
        line = Regex.Replace(line, @"\s+", " ");
        string[] lines = line.Split(new string[] { "\r\n", "\0" }, StringSplitOptions.RemoveEmptyEntries);
        sb.Clear();
        int count = 0;
        for (int i = 0; i < lines.Length; i++)
        {
            string textLine = lines[i].Trim();
            if (textLine == "")
                continue;
            if (textLine == "}")
                count--;
            for (int ii = 0; ii < count; ii++)
            {
                sb.Append(pad);
            }
            sb.Append(textLine);
            foreach (char ch in textLine)
            {
                if (ch == '{')
                    count++;
            }
            sb.AppendLine();
        }
        string result = sb.ToString();
        Console.Write(result);
    }
}
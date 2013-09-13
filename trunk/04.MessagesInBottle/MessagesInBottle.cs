using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class MessagesInBottle
{
    static List<string> decodedMessages = new List<string>();
    static Dictionary<string, string> ciphers;
    static string secretMessage;
    static void Main()
    {
        secretMessage = Console.ReadLine();
        string cipher = Console.ReadLine();
        List<string> listCh = new List<string>();
        List<string> listInt = new List<string>();
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < cipher.Length; i++)
        {
            string digit = "";
            if (Char.IsLetter(cipher[i]))
            {
                listCh.Add(cipher[i].ToString());
                if (sb.Length != 0)
                {
                    digit = sb.ToString();
                    listInt.Add(digit);
                }
                sb.Clear();
            }
            if (!Char.IsLetter(cipher[i]))
            {
                sb.Append(cipher[i]);
            }
            if (!Char.IsLetter(cipher[i]) && i == cipher.Length - 1)
            {
                digit = sb.ToString();
                listInt.Add(digit);
            }
        }
        sb.Clear();
        ciphers = listCh.ToDictionary(x => x, x => listInt[listCh.IndexOf(x)]);
        Decode(secretMessage, String.Empty);
        decodedMessages.Sort();
        Print();
    }
    static void Decode(string encoded, string decoded)
    {
        if (encoded.Length == 0)
            decodedMessages.Add(decoded);
        else foreach (var cipher in ciphers)
                if (encoded.StartsWith(cipher.Value))
                    Decode(encoded.Substring(cipher.Value.Length), decoded + cipher.Key);
    }
    static void Print()
    {
        Console.WriteLine(decodedMessages.Count);
        foreach (string msg in decodedMessages)
            Console.WriteLine(msg);
    }
}
using System.Text;
using System.Text.RegularExpressions;

namespace Shared.Util.Extensions;

public static class StringExtensions
{
    public static string AppendRight(this string str, char chr, int count = 1)
    {
        string result = str;
        for (int i = 0; i < count; i++)
        {
            result += chr;
        }
        return result;
    }

    public static string AppendLeft(this string str, char chr, int count = 1)
    {
        string result = string.Empty;
        for (int i = 0; i < count; i++)
        {
            result += chr;
        }
        return result + str;
    }

    public static string CapitalizeFirstLetter(this string str)
    {
        if (string.IsNullOrWhiteSpace(str))
            return string.Empty;
        if (str.Length == 1)
            return char.ToUpper(str[0]).ToString();
        else
            return char.ToUpper(str[0]) + str.Substring(1);
    }

    public static string Protect(this string str)
    {
        return $"\"{str}\"";
    }

    public static string FormatRoute(this string str)
    {
        str = "/" + str.Trim().Trim('/');
        return str.RemoveDuplicates('/');
    }

    public static string RemoveDuplicates(this string str, char chr)
    {

        return Regex.Replace(str, chr + "{2,}", chr.ToString());
    }


    public static string ReplaceAccentLetters(this string str)
    {
        return str
            .Replace('á', 'a')
            .Replace('Á', 'A')
            .Replace('é', 'e')
            .Replace('É', 'E')
            .Replace('í', 'i')
            .Replace('Í', 'I')
            .Replace('ó', 'o')
            .Replace('Ó', 'O')
            .Replace('ú', 'u')
            .Replace('Ú', 'U');
    }

    public static string ReplaceRegex(this string str, string pattern, string replacement)
    {
        return Regex.Replace(str, pattern, replacement);
    }

    public static string ToCamelCase(this string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;

        var words = SplitWords(input);

        for (int i = 0; i < words.Length; i++)
        {
            if (i == 0)
            {
                words[i] = char.ToLower(words[i][0]) + words[i].Substring(1);
            }
            else
            {
                words[i] = char.ToLower(words[i][0]) + words[i].Substring(1);
            }
        }

        return string.Join("", words);
    }

    public static string Padding(this string str, int paddingSize = 1)
    {        

        string[] lines = str.Split('\n');
        for (int i = 0; i < lines.Length; i++)
        {
            lines[i] = lines[i].PadLeft(lines[i].Length + paddingSize);
        }
        
        return string.Join("\n", lines);
    }

    private static string[] SplitWords(string input)
    {
        var words = new List<string>();
        var currentWord = new StringBuilder();

        for (int i = 0; i < input.Length; i++)
        {
            if (char.IsUpper(input[i]) && i > 0)
            {
                words.Add(currentWord.ToString());
                currentWord.Clear();
            }

            currentWord.Append(input[i]);
        }

        words.Add(currentWord.ToString());

        return words.ToArray();
    }

    public static bool TryParseToBoolean(this string str, Exception exception)
    {
        string Value = str.ToUpper();
        if(Value == "SI") return true;
        else if(Value == "NO") return false;

        throw exception;
    }

    public static DateTime TryParseToDate(this string str, Exception exception)
    {
        DateTime date = default!;

        if(DateTime.TryParse(str, out date)) return date;

        throw exception;
    }
    
}

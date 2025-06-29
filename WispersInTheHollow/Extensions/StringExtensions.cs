using System.Text.RegularExpressions;

namespace WispersInTheHollow.Extensions;

internal static class StringExtensions
{
    public static string[] SplitTrimToLower(this string str, string separator)
    {
        string[] split = str.Split(separator, StringSplitOptions.RemoveEmptyEntries);
        return [.. split.Select(s => s.ToLower())];
    }

    public static string RemoveEmptyLines(this string str)
    {
        return Regex.Replace(str, @"^\s*$[\r\n]*", string.Empty, RegexOptions.Multiline);
    }
}
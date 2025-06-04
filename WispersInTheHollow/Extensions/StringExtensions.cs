namespace WispersInTheHollow.Extensions;

internal static class StringExtensions {
    public static string[] SplitToLower(this string str, string separator)
    {
        string[] split = str.Split(separator, StringSplitOptions.RemoveEmptyEntries);
        return [.. split.Select(s => s.ToLower())];
    }
}
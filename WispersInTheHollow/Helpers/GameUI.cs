namespace WispersInTheHollow.Helpers;

internal static class GameUI
{
    public static void PrintPrefix(string prefix = "---> ")
    {
        Console.Write(prefix);
    }

    public static void Print(string? output = "")
    {
        Console.WriteLine(output);
    }

    public static void FormattedPrint(string output)
    {
        PrintPrefix();
        Print(output);
    }

    public static string Read()
    {
        return Console.ReadLine()?.Trim() ?? string.Empty;
    }

    public static string FormattedRead()
    {
        PrintPrefix();
        return Read();
    }
}
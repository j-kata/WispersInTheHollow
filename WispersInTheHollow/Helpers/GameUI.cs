namespace WispersInTheHollow.Helpers;

internal static class GameUI
{
    public static void Print(string output)
    {
        Console.WriteLine(output);
    }

    public static string Read()
    {
        return Console.ReadLine()?.Trim() ?? string.Empty;
    }
}
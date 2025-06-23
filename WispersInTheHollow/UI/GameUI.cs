namespace WispersInTheHollow.UI;

internal class GameUI : IUI
{
    public void PrintPrefix(string prefix = "> ")
    {
        Console.Write(prefix);
    }

    public void Print(string? output = "")
    {
        Console.WriteLine(output);
    }

    public void FormattedPrint(string output)
    {
        PrintPrefix();
        Print(output);
    }

    public string Read()
    {
        return Console.ReadLine()?.Trim() ?? string.Empty;
    }

    public string FormattedRead()
    {
        PrintPrefix();
        return Read();
    }
}
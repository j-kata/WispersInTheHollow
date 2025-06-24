namespace WispersInTheHollow.Abstractions;

internal interface IUI
{
    void FormattedPrint(string output);
    string FormattedRead();
    void Print(string? output = "");
    void PrintPrefix(string prefix = "> ");
    string Read();
}
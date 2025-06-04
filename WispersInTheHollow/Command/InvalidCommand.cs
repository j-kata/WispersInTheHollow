namespace WispersInTheHollow.Command;

internal class InvalidCommand : ICommand
{
    public string Execute(Player player)
    {
        return "Unknown command";
    }
}
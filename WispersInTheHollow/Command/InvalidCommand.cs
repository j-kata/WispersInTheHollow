namespace WispersInTheHollow.Command;

internal class InvalidCommand : ICommand
{
    public string Execute(GameContext _context)
    {
        return "Unknown command";
    }
}
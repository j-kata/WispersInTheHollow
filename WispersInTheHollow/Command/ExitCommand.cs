namespace WispersInTheHollow.Command;

internal class ExitCommand : ICommand
{
    public string Execute(GameContext _context)
    {
        return "You are now exiting the game.";
    }
}

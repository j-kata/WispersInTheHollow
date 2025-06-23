using WispersInTheHollow.Game;

namespace WispersInTheHollow.Command;

internal class ExitCommand : ICommand
{
    public string Execute(IContext _context)
    {
        return "You are now exiting the game.";
    }
}

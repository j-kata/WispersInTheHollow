using WispersInTheHollow.Game;

namespace WispersInTheHollow.Commands;

internal class InvalidCommand : ICommand
{
    public string Execute(IContext _context)
    {
        return "Unknown command";
    }
}
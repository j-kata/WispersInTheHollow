using WispersInTheHollow.Context;

namespace WispersInTheHollow.Command;

internal class InvalidCommand : ICommand
{
    public string Execute(IContext _context)
    {
        return "Unknown command";
    }
}
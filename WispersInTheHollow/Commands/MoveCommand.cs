using WispersInTheHollow.Abstractions;

namespace WispersInTheHollow.Commands;

internal class MoveCommand(string direction) : ICommand
{
    public string Direction { get; private set; } = direction;

    public string Execute(IContext context)
    {
        var exit = context.FindExit(Direction);
        if (exit == null) return $"You can't move {Direction}";

        context.CurrentLocation = exit;

        return $"You are moving {Direction}";
    }
}

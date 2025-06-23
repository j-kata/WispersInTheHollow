using WispersInTheHollow.Game;

namespace WispersInTheHollow.Command;

internal interface ICommand
{
    string Execute(IContext context);
}

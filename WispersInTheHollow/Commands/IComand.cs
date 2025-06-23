using WispersInTheHollow.Game;

namespace WispersInTheHollow.Commands;

internal interface ICommand
{
    string Execute(IContext context);
}

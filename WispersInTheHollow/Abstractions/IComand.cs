using WispersInTheHollow.Game;

namespace WispersInTheHollow.Abstractions;

internal interface ICommand
{
    string Execute(IContext context);
}

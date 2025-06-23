using WispersInTheHollow.Context;

namespace WispersInTheHollow.Command;

internal interface ICommand
{
    string Execute(IContext context);
}

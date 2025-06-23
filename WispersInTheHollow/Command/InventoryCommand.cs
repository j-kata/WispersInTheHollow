using WispersInTheHollow.Game;

namespace WispersInTheHollow.Command;

internal class InventoryCommand() : ICommand
{
    public string Execute(IContext context)
    {
        return context.Player.Inventory.ToString();
    }
}

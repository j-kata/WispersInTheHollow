using WispersInTheHollow.World;

namespace WispersInTheHollow.Command;

internal class InventoryCommand() : ICommand
{
    public string Execute(GameContext context)
    {
        return context.Player.Inventory.ToString();
    }
}

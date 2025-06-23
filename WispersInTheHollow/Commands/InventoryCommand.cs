using WispersInTheHollow.Game;

namespace WispersInTheHollow.Commands;

internal class InventoryCommand() : ICommand
{
    public string Execute(IContext context)
    {
        var inventory = context.Inventory.ToString();
        return $"You are carrying:\n{inventory}";
    }
}

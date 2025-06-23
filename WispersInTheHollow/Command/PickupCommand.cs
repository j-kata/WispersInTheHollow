using WispersInTheHollow.World;
using WispersInTheHollow.Context;

namespace WispersInTheHollow.Command;

internal class PickupCommand(string itemName) : ICommand
{
    private string? ItemName { get; set; } = itemName;

    public string Execute(IContext context)
    {
        Item? item = context.FindVisibleItem(ItemName);

        if (item == null) return $"You can't pickup {ItemName}";

        context.Player.Inventory.AddItem(item);
        context.Player.Location.RemoveItem(item);

        return $"You've picked up {item.Name}";
    }
}

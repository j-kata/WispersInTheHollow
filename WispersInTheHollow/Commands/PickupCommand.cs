using WispersInTheHollow.World;
using WispersInTheHollow.Abstractions;

namespace WispersInTheHollow.Commands;

internal class PickupCommand(string itemName) : ICommand
{
    private string? ItemName { get; set; } = itemName;

    public string Execute(IContext context)
    {
        Item? item = context.FindVisibleItem(ItemName);

        if (item == null) return $"You can't pickup {ItemName}";

        context.Inventory.AddItem(item);
        context.CurrentLocation.RemoveItem(item);

        return $"You've picked up {item.Name}";
    }
}

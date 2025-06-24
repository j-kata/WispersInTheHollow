using WispersInTheHollow.World;
using WispersInTheHollow.Abstractions;

namespace WispersInTheHollow.Commands;

internal class ThrowCommand(string itemName) : ICommand
{
    private string ItemName { get; set; } = itemName;

    public string Execute(IContext context)
    {
        Item? item = context.FindOwnItem(ItemName);

        if (item == null) return $"You don't have {ItemName} to throw";

        context.Inventory.RemoveItem(item);
        context.CurrentLocation.AddItem(item);

        return $"You've trown {item.Name}";
    }
}

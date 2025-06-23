using WispersInTheHollow.World;
using WispersInTheHollow.Game;

namespace WispersInTheHollow.Command;

internal class ThrowCommand(string itemName) : ICommand
{
    private string ItemName { get; set; } = itemName;

    public string Execute(IContext context)
    {
        Item? item = context.FindOwnItem(ItemName);

        if (item == null) return $"You don't have {ItemName} to throw";

        context.Player.Inventory.RemoveItem(item);
        context.Player.Location.AddItem(item);

        return $"You've trown {item.Name}";
    }
}

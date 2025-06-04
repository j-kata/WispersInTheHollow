using WispersInTheHollow.World;

namespace WispersInTheHollow.Command;

internal class PickupCommand(string itemName) : ICommand
{
    private string? ItemName { get; set; } = itemName;

    public string Execute(GameContext context)
    {
        Item? item = context.FindVisibleItem(ItemName);

        if (item == null) return $"You can't pickup {ItemName}";

        context.Player.PickUp(item);
        context.Player.Location.RemoveItem(item);
        
        return $"You've picked up {item.Name}";
    }
}

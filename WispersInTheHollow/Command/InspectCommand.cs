using WispersInTheHollow.World;

namespace WispersInTheHollow.Command;

internal class InspectCommand(string? itemName) : ICommand
{
    private string? ItemName { get; set; } = itemName;

    public string Execute(GameContext context)
    {
        Item? item = context.FindHiddenItem(ItemName);

        if (item == null)
            return "There is nothing to look at";
        
        item.IsDiscovered = true;
        return $"It is {item}";
    }
}

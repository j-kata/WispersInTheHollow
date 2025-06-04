using WispersInTheHollow.World;

namespace WispersInTheHollow.Command;

internal class InspectCommand : ICommand
{
  private string? ItemName { get; set; }

  public InspectCommand(string? itemName)
  {
    ItemName = itemName;
  }

  public string Execute(Player player)
  {
    Item? item = player.Inspect(ItemName);
    
    return item != null
      ? $"It is {item}"
      : "There is nothing to look at";
  }
}

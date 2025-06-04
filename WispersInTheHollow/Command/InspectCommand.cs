using WispersInTheHollow.World;

namespace WispersInTheHollow.Command;

internal class InspectCommand : ICommand
{
  private string? ItemName { get; set; }

  public InspectCommand(string? itemName)
  {
    ItemName = itemName;
  }

  public bool Execute(Player player, out string message)
  {
    Item? item = player.Inspect(ItemName);
    var success = item != null;
    message = success ? $"It is {item}" : "There is nothing to look at";

    return success;
  }
}

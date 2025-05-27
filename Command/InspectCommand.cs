namespace WispersInTheHollow.Command
{
  internal class InspectCommand : ICommand
  {
    private string ItemName { get; set; }

    public InspectCommand(string? itemName)
    {
      ItemName = itemName ?? string.Empty;
    }
    public bool Execute(Player player, out string message)
    {
      Item? item = player.Location.Inspect(ItemName);
      message = item == null ? "There is nothing to look at" : $"It is {item.Name}. {item.Description}";
      return item != null;
    }
  }
}
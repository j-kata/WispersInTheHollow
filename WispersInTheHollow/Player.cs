using WispersInTheHollow.World;
using WispersInTheHollow.World.Helpers;

namespace WispersInTheHollow
{
  internal class Player
  {
    public IReadOnlyLocation Location { get; private set; }
    private readonly List<Item> inventory = [];

    public Player(IReadOnlyLocation location)
    {
      Location = location;
    }

    public IReadOnlyLocation? Move(string direction)
    {
      var exit = Location.GetExit(direction);
      if (exit != null)
        Location = exit;

      return exit;
    }

    public Item? Inspect(string? itemName)
    {
      var hiddenItem = Location.GetHiddenItem(itemName);

      if (hiddenItem != null)
        hiddenItem.IsDiscovered = true;

      return hiddenItem;
    }

    public void PickUp(Item item)
    {
      inventory.Add(item);
    }

    public void ThrowAway(Item item)
    {
      inventory.Remove(item);
    }

    public IEnumerable<string?> Inventory()
    {
      return inventory.Select(x => x.ToString());
    }
  }
}
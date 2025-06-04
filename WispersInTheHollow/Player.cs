using WispersInTheHollow.World;
using WispersInTheHollow.World.Helpers;

namespace WispersInTheHollow
{
  internal class Player
  {
    public Location Location { get; set; }
    private readonly List<Item> inventory = [];

    public Player(Location location)
    {
      Location = location;
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
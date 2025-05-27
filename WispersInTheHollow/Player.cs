using WispersInTheHollow.World;
namespace WispersInTheHollow
{
  internal class Player
  {
    public Location Location { get; private set; }
    private readonly List<Item> inventory = [];

    public Player(Location location)
    {
      Location = location;
    }

    public bool Move(string direction)
    {
      var exit = Location.GetExit(direction);
      if (exit == null)
        return false;

      Location = exit;
      return true;
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
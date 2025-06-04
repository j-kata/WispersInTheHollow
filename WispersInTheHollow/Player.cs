using WispersInTheHollow.World;

namespace WispersInTheHollow;

internal class Player(Location location)
{
    public Location Location { get; set; } = location;
    public Inventory<Item> Inventory { get; set; } = [];
}

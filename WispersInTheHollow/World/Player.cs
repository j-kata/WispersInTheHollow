namespace WispersInTheHollow.World;

internal class Player(Location location)
{
    public Location Location { get; set; } = location;
    public Inventory Inventory { get; set; } = [];
}

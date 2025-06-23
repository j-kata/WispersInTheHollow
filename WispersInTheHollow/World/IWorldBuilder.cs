using WispersInTheHollow.World.Data;

namespace WispersInTheHollow.World;

internal interface IWorldBuilder
{
    IReadOnlyDictionary<string, Location> Locations { get; }
    IReadOnlyDictionary<string, Item> Items { get; }

    Location StartLocation();
}
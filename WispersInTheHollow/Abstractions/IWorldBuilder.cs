using WispersInTheHollow.World;

namespace WispersInTheHollow.Abstractions;

internal interface IWorldBuilder
{
    IReadOnlyDictionary<string, Location> Locations { get; }
    IReadOnlyDictionary<string, Item> Items { get; }

    Location StartLocation();
}
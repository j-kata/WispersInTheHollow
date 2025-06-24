using WispersInTheHollow.World;

namespace WispersInTheHollow.Abstractions;

internal interface ILog<T>
{
    void Add(T entry);
    bool HasPickedUpItem(Item item);
    bool HasVisitedLocation(Location location);
}

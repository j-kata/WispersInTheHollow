using WispersInTheHollow.World;
using WispersInTheHollow.Abstractions;

namespace WispersInTheHollow.Logger;

internal class GameLog : ILog
{
    private readonly List<ILoggable> _entries = [];

    public void LogState(ILoggable source) => _entries.Add(source);

    public bool HasVisitedLocation(Location location) =>
        _entries.OfType<Location>().Any(entry => entry == location);

    public bool HasPickedUpItem(Item item) =>
        _entries.OfType<Item>().Any(entry => entry == item);
}
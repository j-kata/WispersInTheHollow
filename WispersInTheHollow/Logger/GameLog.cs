using WispersInTheHollow.World;
using WispersInTheHollow.Abstractions;

namespace WispersInTheHollow.Logger;

internal class GameLog : ILog<LogEntry>
{
    private readonly List<LogEntry> _entries = [];

    public void Add(LogEntry entry) => _entries.Add(entry);

    public bool HasVisitedLocation(Location location) =>
        _entries.OfType<LogEntryMove>().Any(entry => entry.Location == location);

    public bool HasPickedUpItem(Item item) =>
        _entries.OfType<LogEntryItem>().Any(entry => entry.Item == item);
}
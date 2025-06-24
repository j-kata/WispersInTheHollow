using WispersInTheHollow.Abstractions;
using WispersInTheHollow.World;

namespace WispersInTheHollow.Logger;

internal class LogEntry(LogEntryType type)
{
    public LogEntryType Type { get; } = type;
}

internal class LogEntryMove(Location location) : LogEntry(LogEntryType.Move)
{
    public Location Location { get; } = location;
}

internal class LogEntryItem(Item item) : LogEntry(LogEntryType.Item)
{
    public Item Item { get; } = item;
}
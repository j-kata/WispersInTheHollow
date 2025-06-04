using WispersInTheHollow.World;
using WispersInTheHollow.World.Helpers;

namespace WispersInTheHollow;

internal class GameContext(Player player)
{
    public Player Player { get; } = player;
    public IReadOnlyLocation CurrentLocation => Player.Location;

    public Item? FindHiddenItem(string? itemName)
    {
        return itemName == null
            ? Player.Location.GetHiddenItems().FirstOrDefault()
            : Player.Location.GetHiddenItems().FirstOrDefault(item => item.Hint.Contains(itemName));
    }

    public IReadOnlyLocation? FindExit(string direction)
    {
        return Player.Location.Exits.TryGetValue(direction, out var location) ? location : null;
    }

    public Item? FindVisibleItem(string? itemName)
    {
        return itemName == null
           ? Player.Location.GetVisibleItems().FirstOrDefault()
           : Player.Location.GetVisibleItems().FirstOrDefault(item => item.Name.Contains(itemName, StringComparison.OrdinalIgnoreCase));
    }
    
}
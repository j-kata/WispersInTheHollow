using WispersInTheHollow.World;

namespace WispersInTheHollow.Game;


internal class GameContext : IContext
{
    public Player Player { get; }
    public Location CurrentLocation => Player.Location;

    public GameContext(IWorldBuilder builder)
    {
        var startLocation = builder.StartLocation();
        Player = new Player(startLocation);
    }


    public Item? FindHiddenItem(string? itemName)
    {
        return itemName == null
            ? Player.Location.GetHiddenItems().FirstOrDefault()
            : Player.Location.GetHiddenItems().FirstOrDefault(item => item.Hint.Contains(itemName));
    }

    public Location? FindExit(string direction)
    {
        return Player.Location.Exits.TryGetValue(direction, out var location) ? location : null;
    }

    public Item? FindVisibleItem(string? itemName)
    {
        return itemName == null
           ? Player.Location.GetVisibleItems().FirstOrDefault()
           : Player.Location.GetVisibleItems().FirstOrDefault(item => item.Name.Contains(itemName, StringComparison.OrdinalIgnoreCase));
    }

    public Item? FindOwnItem(string itemName)
    {
        return Player.Inventory.FirstOrDefault(item => item.Name.Contains(itemName, StringComparison.OrdinalIgnoreCase));
    }
}
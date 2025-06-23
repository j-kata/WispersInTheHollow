using WispersInTheHollow.World;

namespace WispersInTheHollow.Game;


internal class GameContext : IContext
{
    private readonly Player _player;
    public Inventory Inventory => _player.Inventory;

    public Location CurrentLocation
    {
        get => _player.Location;
        set => _player.Location = value; // TODO validation
    }

    public GameContext(IWorldBuilder builder)
    {
        var startLocation = builder.StartLocation();
        _player = new Player(startLocation);
    }

    public Item? FindHiddenItem(string? itemName)
    {
        return itemName == null
            ? _player.Location.GetHiddenItems().FirstOrDefault()
            : _player.Location.GetHiddenItems().FirstOrDefault(item => item.Hint.Contains(itemName));
    }

    public Location? FindExit(string direction)
    {
        return _player.Location.Exits.TryGetValue(direction, out var location) ? location : null;
    }

    public Item? FindVisibleItem(string? itemName)
    {
        return itemName == null
           ? _player.Location.GetVisibleItems().FirstOrDefault()
           : _player.Location.GetVisibleItems().FirstOrDefault(item => item.Name.Contains(itemName, StringComparison.OrdinalIgnoreCase));
    }

    public Item? FindOwnItem(string itemName)
    {
        return _player.Inventory.FirstOrDefault(item => item.Name.Contains(itemName, StringComparison.OrdinalIgnoreCase));
    }
}
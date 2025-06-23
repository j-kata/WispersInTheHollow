using WispersInTheHollow.World;

namespace WispersInTheHollow.Context;

internal interface IContext
{
    public Location CurrentLocation { get; }
    public Player Player { get; }
    public Location? FindExit(string direction);
    public Item? FindHiddenItem(string? itemName);
    public Item? FindOwnItem(string itemName);
    public Item? FindVisibleItem(string? itemName);
}
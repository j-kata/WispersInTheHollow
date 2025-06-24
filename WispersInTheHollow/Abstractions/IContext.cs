using WispersInTheHollow.World;

namespace WispersInTheHollow.Abstractions;

internal interface IContext
{
    public Location CurrentLocation { get; set; }
    public Inventory Inventory { get; }
    public Location? FindExit(string direction);
    public Item? FindHiddenItem(string? itemName);
    public Item? FindOwnItem(string itemName);
    public Item? FindVisibleItem(string? itemName);
}
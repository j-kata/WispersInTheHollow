namespace WispersInTheHollow.World.Helpers;

internal interface IReadOnlyLocation
{
    public string Name { get; }
    public string Description { get; }
    public IReadOnlyList<Item> Items { get; }
    public IReadOnlyDictionary<string, IReadOnlyLocation> Exits { get; }

    public string[] AvailableDirections();
    public IEnumerable<Item> AvailableItems();
    public IEnumerable<Item> GetHiddenItems();
    public IEnumerable<Item> GetVisibleItems();
}

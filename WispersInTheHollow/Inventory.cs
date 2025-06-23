using System.Collections;
using WispersInTheHollow.World;

namespace WispersInTheHollow;

internal class Inventory : IEnumerable<Item>
{
    private readonly List<Item> _items = [];
    public IReadOnlyList<Item> Items => _items;

    public void AddItem(Item item)
    {
        ArgumentNullException.ThrowIfNull(item, nameof(item));

        _items.Add(item);
    }

    public void RemoveItem(Item item)
    {
        ArgumentNullException.ThrowIfNull(item, nameof(item));

        _items.Remove(item);
    }

    public override string ToString()
    {
        return _items.Count == 0
            ? "Inventory is empty."
            : string.Join("\n", _items.Select(item => $"- {item.Name}"));
    }

    public IEnumerator<Item> GetEnumerator() => _items.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
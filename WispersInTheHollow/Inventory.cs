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

    public IEnumerator<Item> GetEnumerator() => _items.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
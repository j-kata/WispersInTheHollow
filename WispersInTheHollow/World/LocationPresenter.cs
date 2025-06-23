using System.Text;
using WispersInTheHollow.Extensions;

namespace WispersInTheHollow.World;

internal class LocationPresenter(Location location)
{
    private readonly Location _location = location;

    public string Describe()
    {
        var builder = new StringBuilder();
        builder.AppendLine(LocationSummary());
        builder.AppendLine(LocationExits());
        builder.AppendLine(LocationItems());
        return builder.ToString().RemoveEmptyLines();
    }

    public string LocationSummary()
    {
        return $"== {_location.Name} ==\n{_location.Description}";
    }

    public string LocationExits()
    {
        var directions = _location.AvailableDirections();
        return (directions.Length > 0)
        ? $"You can go: {string.Join(" | ", directions)}"
        : String.Empty;
    }

    public string? LocationItems()
    {
        var items = _location.Items;
        return items.Any()
        ? $"You notice: {string.Join("\n", items.Select(i => i.ToString()))}"
        : String.Empty;
    }
}

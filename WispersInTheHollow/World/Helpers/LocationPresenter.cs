using System.Text;

namespace WispersInTheHollow.World.Helpers;

internal class LocationPresenter
{
  private readonly IReadOnlyLocation _location;

  public LocationPresenter(IReadOnlyLocation location)
  {
    _location = location;
  }

  public string Describe()
  {
    var builder = new StringBuilder();
    builder.AppendLine(LocationSummary());
    builder.AppendLine(LocationExits());
    builder.AppendLine(LocationItems());
    return builder.ToString();
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

  public string LocationItems()
  {
    var items = _location.AvailableItems();
    return items.Any()
      ? $"You notice: {items.Select(i => i.ToString())}"
      : String.Empty;
  }
}

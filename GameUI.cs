using System.Data;

namespace WispersInTheHollow
{
  internal static class GameUI
  {
    public static void PrintLocation(Location location)
    {
      Console.WriteLine($"== {location.Name} ==");
      Console.WriteLine(location.Description);

      var directions = location.AvailableDirections();
      if (directions.Length > 0)
        Console.WriteLine($"You can go: {string.Join(" | ", directions)}");

      if (location.AvailableItems().Any())
      {
        Console.WriteLine("You notice:");
        foreach (var item in location.AvailableItems())
        {
          Console.WriteLine(item.ToString());
        }
      }
    }
  }
}
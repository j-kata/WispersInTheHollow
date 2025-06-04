using WispersInTheHollow.Command;
using WispersInTheHollow.Extensions;

namespace WispersInTheHollow.Helpers;

internal static class CommandParser
{
  public static ICommand? Parse(string input)
  {
    string[] data = input.SplitToLower(" ");
    var command = data[0];

    switch (command)
    {
      case "go":
        var direction = data.Skip(1).Take(1).FirstOrDefault();
        // if null return invalid command
        return new MoveCommand(direction);
      case "look":
      case "search":
      case "inspect":
        var itemName = data.Skip(1);
        return new InspectCommand(string.Join(" ", itemName));
      default:
        return null;
    }
  }
}

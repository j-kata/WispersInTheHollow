using WispersInTheHollow.Command;
using WispersInTheHollow.Extensions;

namespace WispersInTheHollow.Helpers;

internal static class CommandParser
{
  public static ICommand Parse(string input)
  {
    var (command, arguments) = SplitInput(input);
    if (command == null) return new InvalidCommand();

    switch (command)
    {
      case "go":
        var direction = arguments.Take(1).FirstOrDefault();
        return direction == null ? new InvalidCommand() : new MoveCommand(direction);
      case "look":
      case "search":
      case "inspect":
        return new InspectCommand(string.Join(" ", arguments));
      case "help":
        return new HelperCommand();
      default:
        return new InvalidCommand();
    }
  }

  private static (string? command, IEnumerable<string> arguments) SplitInput(string input)
  {
    string[] data = input.SplitToLower(" ");
    return (data.Take(1).FirstOrDefault(), data.Skip(1));
  }
}

using WispersInTheHollow.Command;

namespace WispersInTheHollow
{
  internal static class CommandParser
  {
    public static ICommand? Parse(string input)
    {
      string[] data = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
      string command = data[0].ToLower();
      // TODO: if less then two; trim; remove white space

      switch (command)
      {
        case "go":
          return new MoveCommand(data[1]);
        case "look":
        case "search":
        case "inspect":
          return new InspectCommand(string.Join(" ", data[1]));
        default:
          return null;
      }
    }
  }
}
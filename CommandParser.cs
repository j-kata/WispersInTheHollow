using WispersInTheHollow.Command;

namespace WispersInTheHollow
{
  internal static class CommandParser
  {
    public static IExecutable Parse(string input)
    {
      string[] data = input.Split(" ");
      string command = data[0].ToLower();

      switch (command)
      {
        case "go":
          return new MoveCommand(data[1]);
        default:
          return null;
      }
    }
  }
}
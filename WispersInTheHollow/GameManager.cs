using WispersInTheHollow.World;

namespace WispersInTheHollow
{
  internal static class GameManager
  {
    private static Player Player { get; set; }
    private static bool IsGameOn { get; set; }
    public static void Start()
    {
      try
      {
        var startLocation = WorldCreator.Generate();
        Player = new Player(startLocation);
        IsGameOn = true;
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Failed to start the game: {ex.Message}");
      }
      GameLoop();
    }

    private static void GameLoop()
    {
      while (IsGameOn)
      {
        GameUI.PrintLocation(Player.Location);
        var input = Console.ReadLine() ?? string.Empty;

        ICommand? command = CommandParser.Parse(input);

        if (command != null)
        {
          command.Execute(Player, out string message);
          Console.WriteLine(message);
        }
        else
        {
          IsGameOn = false;
        }
      }
    }
  }
}
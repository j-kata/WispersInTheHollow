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
        var location = WorldCreator.StartLocation();
        Player = new Player(location);
        IsGameOn = true;
        GameLoop();
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Failed to start the game: {ex.Message}");
      }
    }

    private static void GameLoop()
    {
      while (IsGameOn)
      {
        GameUI.PrintLocation(Player.Location);
        var input = Console.ReadLine() ?? string.Empty;

        IExecutable command = CommandParser.Parse(input);

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
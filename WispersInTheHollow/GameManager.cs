using WispersInTheHollow.Helpers;
using WispersInTheHollow.Command;
using WispersInTheHollow.World;
using WispersInTheHollow.World.Helpers;

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
        var startLocation = new WorldBuilder().StartLocation();
        Player = new Player(startLocation);
        IsGameOn = true;
      }
      catch (Exception ex)
      {
        GameUI.Print($"Failed to start the game: {ex.Message}");
      }
      GameLoop();
    }

    private static void GameLoop()
    {
      while (IsGameOn)
      {
        var presenter = new LocationPresenter(Player.Location);
        GameUI.Print(presenter.Describe());

        var input = GameUI.Read();

        ICommand command = CommandParser.Parse(input);
        var output = command.Execute(Player);
        GameUI.Print(output);
      }
    }
  }
}
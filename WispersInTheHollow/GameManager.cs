using WispersInTheHollow.Helpers;
using WispersInTheHollow.Command;
using WispersInTheHollow.World;
using WispersInTheHollow.World.Helpers;

namespace WispersInTheHollow
{
  internal static class GameManager
  {
    private static GameContext Context { get; set; }
    private static bool IsGameOn { get; set; }

    public static void Start()
    {
      try
      {
        var startLocation = new WorldBuilder().StartLocation();
        var player = new Player(startLocation);
        Context = new GameContext(player);

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
        var presenter = new LocationPresenter(Context.CurrentLocation);
        GameUI.Print(presenter.Describe());

        var input = GameUI.Read();

        ICommand command = CommandParser.Parse(input);
        var output = command.Execute(Context);
        GameUI.Print(output);

        if (command is ExitCommand)
          IsGameOn = false;
      }
    }
  }
}
namespace WispersInTheHollow.Command;

internal class ExitCommand : ICommand
{
  public string Execute(Player player)
  {
    return "You are now exiting the game.";
  }
}

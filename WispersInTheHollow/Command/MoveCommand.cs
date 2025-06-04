namespace WispersInTheHollow.Command;

internal class MoveCommand : ICommand
{
  public string Direction { get; private set; }

  public MoveCommand(string direction)
  {
    Direction = direction;
  }

  public string Execute(Player player)
  {
    var exit = player.Move(Direction);
    return exit != null   
      ? $"You are moving {Direction}" 
      : $"You can't move {Direction}";
  }
}

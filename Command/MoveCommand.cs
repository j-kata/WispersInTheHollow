namespace WispersInTheHollow.Command
{
  internal class MoveCommand : IExecutable
  {
    public string Direction { get; private set; }
    public MoveCommand(string direction)
    {
      Direction = direction;
    }
    public bool Execute(Player player, out string message)
    {
      var success = player.Move(Direction);
      message = success ? $"You are moving {Direction}" : $"You can't move {Direction}";
      return success;
    }
  }
}
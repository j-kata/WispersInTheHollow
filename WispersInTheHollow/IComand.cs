namespace WispersInTheHollow
{
  internal interface ICommand
  {
    bool Execute(Player player, out string message);
  }
}
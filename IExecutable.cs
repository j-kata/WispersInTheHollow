namespace WispersInTheHollow
{
  internal interface IExecutable
  {
    bool Execute(Player player, out string message);
  }
}
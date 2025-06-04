namespace WispersInTheHollow.Command;

internal interface ICommand
{
    string Execute(GameContext context);
}

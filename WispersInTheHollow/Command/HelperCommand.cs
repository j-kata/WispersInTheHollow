using System.Text;

namespace WispersInTheHollow.Command;

internal class HelperCommand : ICommand
{
    public string Execute(Player player)
    {
        var builder = new StringBuilder();
        builder.AppendLine("You can interact by typing simple commands.");
        builder.AppendLine($"{"look", 18} -> to look around");
        builder.AppendLine($"{"go [north]", 18} -> to to move in the specific direction");
        builder.AppendLine($"{"inspect [object]", 18} -> to examine an object");
        builder.AppendLine($"{"take [object]", 18} -> to add the object to an inventory");
        builder.AppendLine($"{"inventory", 18} -> to check the objects you are carrying");
        builder.AppendLine($"{"help", 18} -> to list available commands");
        builder.AppendLine($"{"quit", 18} -> to exit the game");

        return builder.ToString();
    }
}
using WispersInTheHollow.Game;
using System.Text;

namespace WispersInTheHollow.Commands;

internal class HelperCommand : ICommand
{
    private const int FieldWidth = 18;

    public string Execute(IContext _context)
    {
        var builder = new StringBuilder();
        builder.AppendLine("You can interact by typing simple commands.");
        builder.AppendLine($"{"look",FieldWidth} -> to look around");
        builder.AppendLine($"{"go [north]",FieldWidth} -> to to move in the specific direction");
        builder.AppendLine($"{"inspect [object]",FieldWidth} -> to examine an object");
        builder.AppendLine($"{"take [object]",FieldWidth} -> to add the object to an inventory");
        builder.AppendLine($"{"inventory",FieldWidth} -> to check the objects you are carrying");
        builder.AppendLine($"{"help",FieldWidth} -> to list available commands");
        builder.AppendLine($"{"quit",FieldWidth} -> to exit the game");

        return builder.ToString();
    }
}
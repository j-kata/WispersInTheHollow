using WispersInTheHollow.Command;
using WispersInTheHollow.Extensions;

namespace WispersInTheHollow.Helpers;

internal static class CommandParser
{
    private static readonly Dictionary<string, Func<string[], ICommand>> CommandMap = new()
    {
        { "go", args => args.Length > 0 ? new MoveCommand(args[0]) : new InvalidCommand() },
        { "inspect", args => new InspectCommand(string.Join(" ", args)) },
        { "take", args => new PickupCommand(string.Join(" ", args)) },
        { "help", args => new HelperCommand() },
        { "exit", args => new ExitCommand() },
    };
    // TODO: add aliases
    
    public static ICommand Parse(string input)
    {
        var (command, arguments) = SplitInput(input);
        if (command == null) return new InvalidCommand();

        //command = CommandAliases.TryGetValue(command, out var realCmd) ? realCmd : command;
        return CommandMap.TryGetValue(command, out var factory) ? factory(arguments) : new InvalidCommand();
    }

    private static (string? command, string[] arguments) SplitInput(string input)
    {
        string[] data = input.SplitTrimToLower(" ");
        return (data.FirstOrDefault(), data.Skip(1).ToArray());
    }
}

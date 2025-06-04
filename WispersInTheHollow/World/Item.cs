namespace WispersInTheHollow.World;

internal class Item(string name, string desc, string hint)
{
    public string Name { get; private set; } = name;
    public string Description { get; private set; } = desc;
    public string RevealedName => $"{Name}. {Description}";
    public string Hint { get; private set; } = hint;
    public bool IsDiscovered { get; set; } = false;

    public override string ToString() => IsDiscovered ? RevealedName : Hint;
}

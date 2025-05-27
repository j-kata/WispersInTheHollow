namespace WispersInTheHollow.World;

internal class Item
{
  public string Name { get; private set; }
  public string Description { get; private set; }
  public string Hint { get; private set; }
  public bool IsDiscovered { get; set; }

  public Item(string name, string description, string hint, bool isDiscovered = false)
  {
    Name = name;
    Description = description;
    Hint = hint;
    IsDiscovered = isDiscovered;
  }

  public override string ToString()
  {
    return IsDiscovered ? Name : Hint;
  }
}

namespace WispersInTheHollow.World;

internal class LocationBuilder
{
  private Location location;
  public LocationBuilder(string name, string decription)
  {
    location = new Location(name, decription);
  }
}
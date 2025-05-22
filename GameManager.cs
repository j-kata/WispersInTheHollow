using System.Data;

namespace WispersInTheHollow
{
  internal class GameManager
  {
    private static Player Player { get; set; }
    private static Location? Location { get; set; }
    public static void Start()
    {
      Location = WorldCreator.StartLocation();
      // TODO: if Location is null then exit
      Player = new Player(Location);
    }
  }
}
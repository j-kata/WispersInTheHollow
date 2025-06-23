using WispersInTheHollow.UI;
using WispersInTheHollow.Context;
using WispersInTheHollow.World;

namespace WispersInTheHollow;

class Program
{
    static void Main(string[] args)
    {
        var ui = new GameUI();
        var context = new GameContext(new WorldBuilder());
        var manager = new GameManager(ui, context);

        manager.Start();
    }
}

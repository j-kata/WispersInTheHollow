﻿using WispersInTheHollow.UI;
using WispersInTheHollow.Game;
using WispersInTheHollow.Helpers;

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

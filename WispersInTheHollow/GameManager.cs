using WispersInTheHollow.UI;
using WispersInTheHollow.Command;
using WispersInTheHollow.World.Helpers;
using WispersInTheHollow.Context;
using WispersInTheHollow.Helpers;

namespace WispersInTheHollow;

internal class GameManager
{
    private readonly IContext _context;
    private readonly IUI _ui;
    private bool IsGameOn { get; set; } = true;

    public GameManager(IUI ui, IContext context)
    {
        _ui = ui;
        _context = context;
    }

    public void Start()
    {
        while (IsGameOn)
        {
            var presenter = new LocationPresenter(_context.CurrentLocation);
            _ui.Print(presenter.Describe());

            var input = _ui.FormattedRead();

            ICommand command = CommandParser.Parse(input);
            var output = command.Execute(_context);

            _ui.FormattedPrint(output);

            if (command is ExitCommand)
                IsGameOn = false;

            _ui.Print();
        }
    }

    private void GameLoop()
    {
        while (IsGameOn)
        {
            var presenter = new LocationPresenter(_context.CurrentLocation);
            _ui.Print(presenter.Describe());

            var input = _ui.FormattedRead();

            ICommand command = CommandParser.Parse(input);
            var output = command.Execute(_context);

            _ui.FormattedPrint(output);

            if (command is ExitCommand)
                IsGameOn = false;

            _ui.Print();
        }
    }
}

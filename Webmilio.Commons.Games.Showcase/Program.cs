using System;

namespace Webmilio.Commons.Games.Showcase;

public static class Program
{
    [STAThread]
    private static void Main()
    {
        using var game = new ShowcaseGame();
        game.Run();
    }
}
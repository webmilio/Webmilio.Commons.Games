using Webmilio.Commons.Games.UI;

namespace Webmilio.Commons.Games.Showcase.UI;

public class Dialog : Panel
{
    public Dialog()
    {
        Bounds = new(
            Dimensions.Empty, Dimensions.Empty, 
            new(0, 1), new(0, 1));
    }
}
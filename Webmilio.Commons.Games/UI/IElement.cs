using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;

namespace Webmilio.Commons.Games.UI;

public interface IElement : IUpdateable, IDrawable
{
    public void SetBounds(Bounds bounds);
    public void Calculate();

    public IElement Parent { get; set; }

    public ReadOnlyCollection<IElement> Children { get; }

    public Rectangle CalculatedBounds { get; }
}
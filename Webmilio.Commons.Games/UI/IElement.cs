using System.Collections.ObjectModel;

namespace Webmilio.Commons.Games.UI;

public interface IElement : IUpdateable, IDrawable
{
    public void SetBounds(Bounds bounds);
    public void Calculate();

    public IElement Parent { get; set; }
    public IBounded SizeReference { get; set; }

    public ReadOnlyCollection<IElement> Children { get; }
}
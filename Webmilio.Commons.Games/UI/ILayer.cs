using System.Collections.Generic;

namespace Webmilio.Commons.Games.UI;

public interface ILayer : IIdentifiable<string>, IUpdateable, IDrawable
{
    public virtual void ModifyLayers(List<ILayer> layers) { }

    public Element Root { get; }

    public bool Visible { get; }
}
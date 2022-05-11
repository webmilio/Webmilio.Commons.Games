using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Webmilio.Commons.Games.UI;

public class Element : IElement
{
    public delegate void ElementEvent(IElement sender, IElement target);

    protected IElement parent;
    protected List<IElement> children = new();

    // ReSharper disable once InconsistentNaming
    public Bounds Bounds;

    public Element()
    {
        Children = children.AsReadOnly();
    }

    #region Dimensions

    public void SetBounds(Bounds bounds)
    {
        Bounds = bounds;
    }

    public virtual void Calculate()
    {
        CalculateSelf();
        CalculateChildren();
    }

    public virtual void CalculateSelf()
    {
    }

    public virtual void CalculateChildren()
    {
        for (int i = 0; i < children.Count; i++)
        {
            children[i].Calculate();
        }
    }

    #endregion

    #region Update

    public virtual void Update(GameTime gameTime)
    {
        UpdateChildren(gameTime);
        UpdateSelf(gameTime);
    }

    protected virtual void UpdateSelf(GameTime gameTime) { }

    protected virtual void UpdateChildren(GameTime gameTime)
    {
        for (int i = 0; i < Children.Count; i++)
        {
            Children[i].Update(gameTime);
        }
    }

    #endregion

    #region Draw

    public virtual void Draw(SpriteBatch spriteBatch)
    {
        DrawSelf(spriteBatch);
        DrawChildren(spriteBatch);
    }

    protected virtual void DrawSelf(SpriteBatch spriteBatch) { }

    protected virtual void DrawChildren(SpriteBatch spriteBatch)
    {
        for (int i = 0; i < Children.Count; i++)
        {
            Children[i].Draw(spriteBatch);
        }
    }

    #endregion

    #region Hierarchy

    protected virtual void OnChildAdded(Element child) { }
    protected virtual void OnChildRemoved(Element child) { }

    public Element AddChild(Element element)
    {
        children.Add(element);
        element.Parent = this;

        ChildAdded?.Invoke(this, element);
        OnChildAdded(element);

        return this;
    }

    public bool RemoveChild(Element element)
    {
        if (element.Parent == this)
            element.Parent = null;

        if (children.Remove(element))
        {
            ChildRemoved?.Invoke(this, element);
            OnChildRemoved(element);
        }

        return false;
    }

    protected virtual void OnParentModified(IElement oldParent)
    {
        Calculate();
    }

    public virtual IElement Parent
    {
        get => parent;
        set
        {
            if (value == parent)
                return;

            var old = parent;
            parent = value;

            OnParentModified(old);
        }
    }
    public IBounded SizeReference { get; set; }

    public ReadOnlyCollection<IElement> Children { get; }

    public event ElementEvent ChildAdded, ChildRemoved;

    #endregion
}
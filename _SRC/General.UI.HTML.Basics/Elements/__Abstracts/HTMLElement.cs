namespace General.UI.HTML.Basics.Elements.Abstracts;


public abstract class HTMLElement
{
    public HTMLElement? Parent { get; set; }
    public abstract string GetAsString();

    protected HTMLElement()
    {
    }

}

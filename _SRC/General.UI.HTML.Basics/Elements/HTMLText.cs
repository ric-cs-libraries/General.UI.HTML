using General.UI.HTML.Basics.Elements.Abstracts;

namespace General.UI.HTML.Basics.Elements;

public class HTMLText : HTMLElement
{
    public string Text { get; set; } = string.Empty;

    public HTMLText(string? text = null) : base()
    {
        if (text is not null)
        {
            AddText(text);
        }
    }

    public HTMLText AddText(string text)
    {
        Text += text;
        return this;
    }

    public override string GetAsString()
    {
        return Text;
    }
}

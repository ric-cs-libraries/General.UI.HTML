using General.UI.HTML.Basics.Elements.Abstracts;

namespace General.UI.HTML.Basics.Elements;

public class HTMLLeafTag : HTMLTag
{
    public HTMLLeafTag(string tagName, string? id = null) : base(tagName, id)
    {
    }

    public override string GetAsString()
    {
        var result = $"{GetStartAsString()}{GetEndAsString()}";
        return result;
    }
    private string GetEndAsString()
    {
        return "/>";
    }
}

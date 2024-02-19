using General.UI.HTML.Basics.Attributes.Styles;

namespace General.UI.HTML.Basics.Elements;

public class HTMLStyleRule
{
    public string Selectors { get; }
    public List<StyleAttribute> StyleAttributes { get; }

    public HTMLStyleRule(string selectors, List<StyleAttribute>? styleAttributes = null)
    {
        Selectors = selectors;
        StyleAttributes = styleAttributes ?? new();
    }

    public HTMLStyleRule AddStyleAttribute(StyleAttribute styleAttribute)
    {
        StyleAttributes.Add(styleAttribute);
        return this;
    }

    public string GetAsString()
    {
        var result = $"{Selectors} {{{GetStyleAttributesAsString()}}}\n";
        return result;
    }


    private string GetStyleAttributesAsString()
    {
        List<string> styleAttributes = StyleAttributes.Select(styleAttribute => styleAttribute.GetAsString()).ToList();
        var result = string.Join("", styleAttributes);
        return result;
    }
}

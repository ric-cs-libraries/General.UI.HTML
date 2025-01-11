using General.UI.HTML.Basics.Attributes.Styles;

namespace General.UI.HTML.Basics.Attributes;

public class HTMLStyleAttribute : HTMLAttribute
{
    public const string HTML_STYLE_ATTRIBUTE_KEY = "style";

    public HTMLStyleAttribute(string value) : base(HTML_STYLE_ATTRIBUTE_KEY, value)
    {
        if (value != string.Empty && !Value.EndsWith(StyleAttribute.ENDING))
        {
            Value += StyleAttribute.ENDING;
        }
    }

    public HTMLStyleAttribute(StyleAttribute? styleAttribute = null) : this(styleAttribute?.GetAsString() ?? string.Empty)
    {
    }

    public HTMLStyleAttribute AddStyle(StyleAttribute styleAttribute)
    {
        AddStyle(styleAttribute.GetAsString());
        return this;
    }

    private HTMLStyleAttribute AddStyle(string style)
    {
        Value += style;
        return this;
    }
}

using General.UI.HTML.Basics.Attributes;

namespace General.UI.HTML.Basics.Elements;

public class HTMLATag : HTMLNodeTag
{
    private const string URL_ATTRIBUTE_KEY = "href";

    private readonly HTMLAttribute urlAttribute = new(URL_ATTRIBUTE_KEY, string.Empty);

    public HTMLATag(string? url = null, string? label = null, string? id = null) : base("A", id)
    {
        AddAttribute(urlAttribute);

        if (url is not null)
        {
            SetUrl(url);
        }
        if (label is not null)
        {
            SetLabel(label);
        }
    }

    public HTMLATag SetUrl(string url)
    {
        urlAttribute.Value = url;
        return this;
    }

    public HTMLATag SetLabel(string label)
    {
        RemoveChildren();
        AddChild(GetLabelAsNewHTMLText(label));
        return this;
    }

    private HTMLText GetLabelAsNewHTMLText(string label)
    {
        return new HTMLText(label);
    }
}

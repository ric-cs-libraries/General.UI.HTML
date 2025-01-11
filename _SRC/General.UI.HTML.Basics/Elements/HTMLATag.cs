using General.UI.HTML.Basics.Attributes;
using System.Reflection.Emit;

namespace General.UI.HTML.Basics.Elements;

public class HTMLATag : HTMLNodeTag
{
    public const string URL_ATTRIBUTE_KEY = "href";

    private readonly HTMLAttribute urlAttribute = new(URL_ATTRIBUTE_KEY, string.Empty);

    public string Url
    {
        get => urlAttribute.Value;
        set => urlAttribute.Value = value;
    }

    private string label = string.Empty;
    public string Label
    {
        get => label;
        set
        {
            RemoveChildren();
            AddChild(GetLabelAsHMLText(value));
            label = value;
        }

    }

    public HTMLATag(string? url = null, string? label = null, string? id = null) : base("A", id)
    {
        AddOrSetAttribute(urlAttribute);

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
        AddChild(GetLabelAsHMLText(label));
        return this;
    }

    private HTMLText GetLabelAsHMLText(string label)
    {
        return new HTMLText(label);
    }
}

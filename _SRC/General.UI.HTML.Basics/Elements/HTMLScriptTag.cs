using General.UI.HTML.Basics.Attributes;

namespace General.UI.HTML.Basics.Elements;

public class HTMLScriptTag : HTMLNodeTag
{
    private const string URL_ATTRIBUTE_KEY = "src";

    private HTMLAttribute urlAttribute = null!;

    public HTMLScriptTag(string? url = null, string? code = null) : base("SCRIPT")
    {

        if (url is not null)
        {
            SetUrl(url);
        }
        if (code is not null)
        {
            SetCode(code);
        }
    }

    public HTMLScriptTag SetUrl(string url)
    {
        if (urlAttribute is null)
        {
            urlAttribute = new(URL_ATTRIBUTE_KEY, string.Empty);
            AddAttribute(urlAttribute);
        }

        urlAttribute.Value = url;
        return this;
    }

    public HTMLScriptTag SetCode(string code)
    {
        RemoveChildren();
        AddChild(GetCodeAsNewHTMLText(code));
        return this;
    }

    private HTMLText GetCodeAsNewHTMLText(string code)
    {
        return new HTMLText(code);
    }
}

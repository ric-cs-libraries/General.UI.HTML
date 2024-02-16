using General.UI.HTML.Basics.Attributes;

namespace General.UI.HTML.Basics.Elements;

public class HTMLImgTag : HTMLLeafTag
{
    private const string URL_ATTRIBUTE_KEY = "src";

    private readonly HTMLAttribute urlAttribute = new(URL_ATTRIBUTE_KEY, string.Empty);

    public HTMLImgTag(string? url = null) : base("IMG")
    {
        AddAttribute(urlAttribute);

        if (url is not null)
        {
            SetUrl(url);
        }
    }

    public HTMLImgTag SetUrl(string url)
    {
        urlAttribute.Value = url;
        return this;
    }
}

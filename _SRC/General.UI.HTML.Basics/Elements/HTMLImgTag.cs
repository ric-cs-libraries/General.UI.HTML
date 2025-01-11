using General.UI.HTML.Basics.Attributes;

namespace General.UI.HTML.Basics.Elements;

public class HTMLImgTag : HTMLLeafTag
{
    public const string URL_ATTRIBUTE_KEY = "src";

    private readonly HTMLAttribute urlAttribute = new(URL_ATTRIBUTE_KEY, string.Empty);

    public string Url
    {
        get => urlAttribute.Value;
        set => urlAttribute.Value = value;
    }

    public HTMLImgTag(string? url = null) : base("IMG")
    {
        AddOrSetAttribute(urlAttribute);

        if (url is not null)
        {
            Url = url;
        }
    }
}

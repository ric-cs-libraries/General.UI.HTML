using General.UI.HTML.Basics.Attributes;

namespace General.UI.HTML.Basics.Elements;

public class HTMLMetaTag : HTMLLeafTag
{
    //<meta charset='iso-8859-1'/>
    private const string CHARSET_ATTRIBUTE_KEY = "charset";

    //<meta http-equiv='Content-Type' content='text/html; charset=iso-8859-1'/>
    private const string HTTPEQUIV_ATTRIBUTE_KEY = "http-equiv";
    private const string HTTPEQUIV_DEFAULT_VALUE = "Content-Type";
    private const string CONTENT_ATTRIBUTE_KEY = "content";


    private readonly HTMLAttribute charsetAttribute = new(CHARSET_ATTRIBUTE_KEY, string.Empty);

    private readonly HTMLAttribute httpEquivAttribute = new(HTTPEQUIV_ATTRIBUTE_KEY, HTTPEQUIV_DEFAULT_VALUE);
    private readonly HTMLAttribute contentAttribute = new(CONTENT_ATTRIBUTE_KEY, string.Empty);

    public HTMLMetaTag(string? charset = null, string? contentType = null) : base("META")
    {
        if (contentType is null)
        {
            if (charset is not null)
            {
                SetSimpleCharset(charset);
            }
        }
        else
        {
            SetContentypeAndCharset(contentType, charset);
        }

    }
    public HTMLMetaTag SetSimpleCharset(string charset)
    {
        AddAttributeIfNotExists(charsetAttribute);
        charsetAttribute.Value = charset;
        return this;
    }

    private HTMLMetaTag SetContentypeAndCharset(string contentType, string? charset = null)
    {
        AddAttributeIfNotExists(httpEquivAttribute);
        AddAttributeIfNotExists(contentAttribute);

        List<string> contentAsList = new() { contentType };
        if (charset is not null)
        {
            contentAsList.Add($"charset={charset}");
        }

        string content = string.Join("; ", contentAsList);
        contentAttribute.Value = content;

        return this;
    }

}

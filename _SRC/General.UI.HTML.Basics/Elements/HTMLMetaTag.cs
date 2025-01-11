using General.UI.HTML.Basics.Attributes;
using General.UI.HTML.Basics.Elements.ErrorHandling;

namespace General.UI.HTML.Basics.Elements;

public class HTMLMetaTag : HTMLLeafTag
{
    //<meta charset="iso-8859-1"/>
    public const string CHARSET_ATTRIBUTE_KEY = "charset";

    //<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1"/>
    public const string HTTPEQUIV_ATTRIBUTE_KEY = "http-equiv";
    public const string HTTPEQUIV_DEFAULT_VALUE = "Content-Type";
    public const string CONTENT_ATTRIBUTE_KEY = "content";

    public string? Charset { get; }
    public string? ContentType { get; }


    private readonly HTMLAttribute charsetAttribute = new(CHARSET_ATTRIBUTE_KEY, string.Empty);

    private readonly HTMLAttribute httpEquivAttribute = new(HTTPEQUIV_ATTRIBUTE_KEY, HTTPEQUIV_DEFAULT_VALUE);
    private readonly HTMLAttribute contentAttribute = new(CONTENT_ATTRIBUTE_KEY, string.Empty);

    public HTMLMetaTag(string? charset = null, string? contentType = null) : base("META")
    {
        if (string.IsNullOrWhiteSpace(charset) && string.IsNullOrWhiteSpace(contentType))
        {
            throw new HTMLMetaTagConstructorMustReceiveAtLeastOneParamException();
        }

        Charset = charset;
        ContentType = contentType;
        if (ContentType is null)
        {
            if (Charset is not null)
            {
                SetSimpleCharset();
            }
        }
        else
        {
            SetContentypeAndCharset();
        }

    }

    private void SetSimpleCharset()
    {
        AddAttributeIfNotExists(charsetAttribute);
        charsetAttribute.Value = Charset!;
    }

    private void SetContentypeAndCharset()
    {
        AddAttributeIfNotExists(httpEquivAttribute);
        AddAttributeIfNotExists(contentAttribute);

        List<string> contentAsList = new() { ContentType! };
        if (Charset is not null)
        {
            contentAsList.Add($"{CHARSET_ATTRIBUTE_KEY}={Charset}");
        }

        string content = string.Join("; ", contentAsList);
        contentAttribute.Value = content;
    }

}
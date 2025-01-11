using General.UI.HTML.Basics.Attributes;

namespace General.UI.HTML.Basics.Elements;

public class HTMLScriptTag : HTMLNodeTag
{
    public const string URL_ATTRIBUTE_KEY = "src";

    private HTMLAttribute? urlAttribute;
    private HTMLText? codeAsHTMLText;

    public string Url
    {
        get => GetUrlAttribute().Value;
        set => GetUrlAttribute().Value = value;
    }

    public string Code
    {
        get => GetCodeAsHTMLText().Text;
        set => GetCodeAsHTMLText().Text = value;
    }


    public HTMLScriptTag(string? url = null, string? code = null) : base("SCRIPT")
    {

        if (url is not null)
        {
            Url = url;
        }
        if (code is not null)
        {
            Code = code;
        }
    }

  private HTMLText GetCodeAsHTMLText() {
    if (codeAsHTMLText is null) {
      codeAsHTMLText = new HTMLText();
      AddChild(this.codeAsHTMLText);
    }
    return codeAsHTMLText;    
  }

  private HTMLAttribute GetUrlAttribute() {
    if (urlAttribute is null) {
      urlAttribute = new HTMLAttribute(URL_ATTRIBUTE_KEY, "");
      AddOrSetAttribute(urlAttribute);
    }
    return urlAttribute;
  }

//@override
public override HTMLNodeTag RemoveChildren() {
    base.RemoveChildren();
    this.codeAsHTMLText = null;
    return this;
}
}

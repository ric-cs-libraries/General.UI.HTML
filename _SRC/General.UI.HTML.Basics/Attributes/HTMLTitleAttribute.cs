namespace General.UI.HTML.Basics.Attributes;

public class HTMLTitleAttribute : HTMLAttribute
{
    public const string HTML_TITLE_ATTRIBUTE_KEY = "title";

    //protected override string ValueQuotingChar => "\"";

    public HTMLTitleAttribute(string value) : base(HTML_TITLE_ATTRIBUTE_KEY, value)
    {
    }

    public HTMLTitleAttribute() : this(string.Empty)
    {
    }

    public override string GetAsString()
    {
        if (Value.Contains(ValueQuotingChar))
        {
            Value = Value.Replace(ValueQuotingChar, "`");
        }
        var result = $"{HTML_TITLE_ATTRIBUTE_KEY}={ValueQuotingChar}{Value.Trim()}{ValueQuotingChar}";
        return result;
    }

}

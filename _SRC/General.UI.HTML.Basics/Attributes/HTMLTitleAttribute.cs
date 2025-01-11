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
        if (Value.Contains(this.ValueQuotingChar))
        {
            Value = Value.Replace(this.ValueQuotingChar, "`");
        }
        var result = $"{HTML_TITLE_ATTRIBUTE_KEY}={this.ValueQuotingChar}{Value.Trim()}{this.ValueQuotingChar}";
        return result;
    }

}

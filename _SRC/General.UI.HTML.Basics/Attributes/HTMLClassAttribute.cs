namespace General.UI.HTML.Basics.Attributes;

public class HTMLClassAttribute : HTMLAttribute
{
    public const string HTML_CLASS_ATTRIBUTE_KEY = "class";

    public HTMLClassAttribute(string value) : base(HTML_CLASS_ATTRIBUTE_KEY, value)
    {
    }

    public HTMLClassAttribute() : this(string.Empty)
    {
    }

    public HTMLClassAttribute AddClass(string className)
    {
        Value += $" {className}";
        return this;
    }

    public override string GetAsString()
    {
        return $"{HTML_CLASS_ATTRIBUTE_KEY}={ValueQuotingChar}{Value.Trim()}{ValueQuotingChar}";
    }

}

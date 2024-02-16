namespace General.UI.HTML.Basics.Attributes;

public class HTMLAttribute
{
    public string KeyName { get; }
    public string Value { get; set; }
    protected virtual string ValueQuotingChar => "\"";

    public HTMLAttribute(string keyName, string value)
    {
        KeyName = keyName;
        Value = value;
    }


    public virtual string GetAsString()
    {
        return $"{KeyName}={ValueQuotingChar}{Value}{ValueQuotingChar}";
    }

}

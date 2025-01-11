namespace General.UI.HTML.Basics.Attributes;

public class HTMLAttribute
{
    public string KeyName { get; }

    private string _value = "";
    public string Value { get => _value.Trim(); set => _value = value.Trim(); }
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

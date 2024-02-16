namespace General.UI.HTML.Basics.Attributes.Styles;

public class StyleAttribute
{
    public const string ENDING = ";";

    public string KeyName { get; }
    public string Value { get; set; }

    public StyleAttribute(string keyName, string value)
    {
        KeyName = keyName;
        Value = value;
    }

    public string GetAsString()
    {
        return $"{KeyName}:{Value}{ENDING}";
    }

}

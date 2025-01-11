namespace General.UI.HTML.Basics.Elements.ErrorHandling;


public class HTMLMetaTagConstructorMustReceiveAtLeastOneParamException : Exception
{
    public const string MESSAGE_FORMAT = "Either charset, either contentType, or both, must be passed to HTMLMetaTag constructor.";
    public override string Message { get; }

    public HTMLMetaTagConstructorMustReceiveAtLeastOneParamException()
    {
        Message = string.Format(MESSAGE_FORMAT);
    }
}

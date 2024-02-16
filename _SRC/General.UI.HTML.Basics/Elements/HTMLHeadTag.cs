namespace General.UI.HTML.Basics.Elements;

public class HTMLHeadTag : HTMLNodeTag
{
    public HTMLStyleTag StyleTag { get; private set; } = null!;

    public HTMLHeadTag() : base("HEAD")
    {

    }

    public HTMLHeadTag AddStyleRules(List<HTMLStyleRule> styleRules)
    {
        styleRules.ForEach(styleRule => AddStyleRule(styleRule));
        return this;
    }
    public HTMLHeadTag AddStyleRule(HTMLStyleRule styleRule)
    {
        AddStyleRule(styleRule.GetAsString());
        return this;
    }

    public HTMLHeadTag AddStyleRule(string styleRule)
    {
        HTMLText styleAsHTMLText = new(styleRule);
        AddStyleRule(styleAsHTMLText);
        return this;
    }

    public HTMLHeadTag AddStyleRule(HTMLText styleRuleAsHTMLText)
    {
        GetStyleTag().AddChild(styleRuleAsHTMLText);
        return this;
    }

    private HTMLStyleTag GetStyleTag()
    {
        if (StyleTag is null)
        {
            StyleTag = new();
            AddChild(StyleTag);
        }
        return StyleTag;
    }
}




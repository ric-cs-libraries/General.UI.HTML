namespace General.UI.HTML.Basics.Elements;

public class HTMLStyleTag : HTMLNodeTag
{
    public HTMLStyleTag() : base("STYLE")
    {
    }
    public HTMLStyleTag AddStyleRules(List<StyleRule> styleRules)
    {
        styleRules.ForEach(styleRule => AddStyleRule(styleRule));
        return this;
    }
    public HTMLStyleTag AddStyleRule(StyleRule styleRule)
    {
        AddStyleRule(styleRule.GetAsString());
        return this;
    }

    private HTMLStyleTag AddStyleRule(string styleRule)
    {
        HTMLText styleAsHTMLText = new(styleRule);
        AddStyleRule(styleAsHTMLText);
        return this;
    }

    private HTMLStyleTag AddStyleRule(HTMLText styleRuleAsHTMLText)
    {
        this.AddChild(styleRuleAsHTMLText);
        return this;
    }
}

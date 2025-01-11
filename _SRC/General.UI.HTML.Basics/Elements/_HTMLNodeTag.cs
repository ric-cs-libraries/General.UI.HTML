using System.Diagnostics;
using System.Text;

using General.UI.HTML.Basics.Elements.Abstracts;

namespace General.UI.HTML.Basics.Elements;


[DebuggerDisplay("{TagName} , Id='{Id}', Attributes='{GetAttributesAsString()}', Children{GetChildrenAsSimplifiedString()}")]
public class HTMLNodeTag : HTMLTag
{
    public List<HTMLElement> Children { get; } = new();

    private const int DEBUG_HTML_TEXT_MAX_LENGTH = 10;

    public HTMLNodeTag(string tagName, string? id = null) : base(tagName, id)
    {
    }

    public virtual HTMLNodeTag RemoveChildren()
    {
        Children.Clear();
        return this;
    }

    public HTMLNodeTag AddChild(HTMLElement child)
    {
        Children.Add(child);
        child.Parent = this;
        return this;
    }

    public HTMLNodeTag AddChildren(List<HTMLElement> children)
    {
        children.ForEach(child =>
        {
            AddChild(child);
        });
        return this;
    }

    public override string GetAsString()
    {
        var result = $"{GetStartAsString()}>{GetChildrenAsString()}{GetEndAsString()}";
        return result;
    }

    private string GetChildrenAsString()
    {
        StringBuilder sb = new StringBuilder();

        Children.ForEach(child =>
        {
            sb.Append($"{child.GetAsString()}");
        });

        return sb.ToString();
    }

    private string GetChildrenAsSimplifiedString()
    {
        List<string> childrenAsStringsList = Children.Select(child =>
        {
            if (child is HTMLTag childTag)
            {
                return $"{childTag.TagName}(Id={childTag.Id})";
            }
            else
            {
                return $"Text='{(child as HTMLText)!.Text.GetAsShorten_(DEBUG_HTML_TEXT_MAX_LENGTH)}'";
            }
        }).ToList();

        return $"({Children.Count})=[" + string.Join(", ", childrenAsStringsList) + "]";
    }



    private string GetEndAsString()
    {
        return $"</{TagName}>";
    }
}

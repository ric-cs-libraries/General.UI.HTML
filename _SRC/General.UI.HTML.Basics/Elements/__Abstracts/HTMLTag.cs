using System.Diagnostics;
using System.Text;

using General.UI.HTML.Basics.Attributes;
using General.UI.HTML.Basics.Attributes.Styles;

namespace General.UI.HTML.Basics.Elements.Abstracts;


[DebuggerDisplay("{TagName} , Id='{Id}', Attributes='{GetAttributesAsString()}'")]
public abstract class HTMLTag : HTMLElement
{
    public string TagName { get; }

    public string? Id => GetAttributeValue("id");

    public List<HTMLAttribute> Attributes { get; } = new();


    protected HTMLTag(string tagName, string? id = null) : base()
    {
        TagName = tagName.ToLower();
        if (id is not null)
        {
            AddOrSetAttribute(new HTMLAttribute("id", id));
        }
    }

    protected string GetStartAsString()
    {
        return $"<{TagName}{GetAttributesAsString()}";
    }

    public string? GetAttributeValue(string attributeKey)
    {
        string? result = Attributes.FirstOrDefault(attribute => attribute.KeyName == attributeKey)?.Value;
        return result;
    }

    private bool AttributeExists(string attributeKey)
    {
        bool result = GetAttributeByKey(attributeKey) is not null;
        return result;
    }

    private HTMLAttribute? GetAttributeByKey(string attributeKey)
    {
        HTMLAttribute? result = Attributes.FirstOrDefault(attribute => attribute.KeyName == attributeKey);
        return result;
    }

    public HTMLTag SetAttributeValue(string attributeKey, string attributeValue)
    {
        HTMLAttribute? attribute = GetAttributeByKey(attributeKey);
        if (attribute is not null)
        {
            attribute.Value = attributeValue;
        }
        else
        {
            throw new Exception($"L'attribut de clef '{attributeKey}' n'existe pas.");
        }
        return this;
    }

    public HTMLTag AddOrSetAttributes(List<HTMLAttribute> attributes)
    {
        attributes.ForEach(a =>
        {
            AddOrSetAttribute(a);
        });
        return this;
    }

    //Si l'attribut existe déjà, alors sa valeur est éventuellement updatée.
    public HTMLTag AddOrSetAttribute(HTMLAttribute attribute)
    {
        HTMLAttribute? attr = GetAttributeByKey(attribute.KeyName);
        if (attr is null)
        {
            Attributes.Add(attribute);
        }
        else
        {
            attr.Value = attribute.Value;
        }
        return this;
    }

    //Si un attribut existe déjà, alors on ne l'ajoute pas.
    public HTMLTag AddAttributesIfNotExists(List<HTMLAttribute> attributes)
    {
        attributes.ForEach(a =>
        {
            AddAttributeIfNotExists(a);
        });
        return this;
    }

    //Si l'attribut existe déjà, alors on ne fait rien.
    public HTMLTag AddAttributeIfNotExists(HTMLAttribute attribute)
    {
        HTMLAttribute? attr = GetAttributeByKey(attribute.KeyName);
        if (attr is null)
        {
            Attributes.Add(attribute);
        }
        return this;
    }

    public HTMLTag AddStyleAttributes(List<StyleAttribute> styleAttributes)
    {
        if (styleAttributes.Count > 0)
        {
            HTMLAttribute? htmlAttribute = GetAttributeByKey(HTMLStyleAttribute.HTML_STYLE_ATTRIBUTE_KEY);

            HTMLStyleAttribute htmlStyleAttribute;

            if (htmlAttribute is null)
            {
                htmlStyleAttribute = new();
                AddOrSetAttribute(htmlStyleAttribute);
            }
            else
            {
                htmlStyleAttribute = (htmlAttribute as HTMLStyleAttribute)!;
            }

            for (var index = 0; index < styleAttributes.Count; index++)
            {
                htmlStyleAttribute.AddStyle(styleAttributes[index]);
            }
        }
        return this;
    }

    public HTMLTag AddStyleClass(string className)
    {
        if (className.Trim() != string.Empty)
        {
            HTMLAttribute? htmlAttribute = GetAttributeByKey(HTMLClassAttribute.HTML_CLASS_ATTRIBUTE_KEY);

            HTMLClassAttribute htmlClassAttribute;

            if (htmlAttribute is null)
            {
                htmlClassAttribute = new();
                AddOrSetAttribute(htmlClassAttribute);
            }
            else
            {
                htmlClassAttribute = (htmlAttribute as HTMLClassAttribute)!;
            }

            htmlClassAttribute.AddClass(className);
        }
        return this;
    }

    public HTMLTag SetTitleAttribute(string title)
    {
        if (title.Trim() != string.Empty)
        {
            HTMLAttribute? htmlAttribute = GetAttributeByKey(HTMLTitleAttribute.HTML_TITLE_ATTRIBUTE_KEY);

            HTMLTitleAttribute htmlTitleAttribute;

            if (htmlAttribute is null)
            {
                htmlTitleAttribute = new();
                AddOrSetAttribute(htmlTitleAttribute);
            }
            else
            {
                htmlTitleAttribute = (htmlAttribute as HTMLTitleAttribute)!;
            }

            htmlTitleAttribute.Value = title;
        }
        return this;
    }


    private string GetAttributesAsString()
    {
        StringBuilder sb = new StringBuilder();

        Attributes.ForEach(attribute =>
        {
            sb.Append($" {attribute.GetAsString()}");
        });

        return sb.ToString();
    }

}

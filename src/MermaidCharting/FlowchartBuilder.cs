using System.Text;

namespace MermaidCharting;

public class FlowchartBuilder
{
    public FlowchartBuilder SetDirection(FlowchartDirection direction)
    {
        _direction = direction;
        return this;
    }

    public FlowchartBuilder AddNode(NodeModel node)
    {
        _nodes.Add(node);
        return this;
    }

    public FlowchartBuilder AddLink(LinkModel link)
    {
        _links.Add(link);
        return this;
    }

    public string Build()
    {
        StringBuilder builder = new();
        AddHeader(builder);
        RenderNodes(builder);
        builder.AppendLine();
        RenderLinks(builder);
        return builder.ToString();
    }

    private void RenderNodes(StringBuilder builder)
    {
        foreach (NodeModel node in _nodes)
        {
            switch (node.Type)
            {
                case NodeType.Default:
                    builder.AppendLine($"{node.Id}[{node.Text}]");
                    break;
                case NodeType.Rhombus:
                    builder.AppendLine($"{node.Id}{{{node.Text}}}");
                    break;
                case NodeType.Circle:
                    builder.AppendLine($"{node.Id}(({node.Text}))");
                    break;
                case NodeType.Subroutine:
                    builder.AppendLine($"{node.Id}[[{node.Text}]]");
                    break;
                case NodeType.Hexagon:
                    builder.AppendLine($"{node.Id}{{{{{node.Text}}}}}");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    private void RenderLinks(StringBuilder builder)
    {
        foreach (LinkModel link in _links)
        {
            string title = link.Title != null ? $"|{link.Title}|" : string.Empty;
            builder.AppendLine($"{link.FromId} -->{title} {link.ToId}");
        }
    }

    private void AddHeader(StringBuilder builder)
    {
        switch (_direction)
        {
            case FlowchartDirection.TopToBottom:
                builder.AppendLine("flowchart TB");
                break;
            case FlowchartDirection.LeftToRight:
                builder.AppendLine("flowchart LR");
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private readonly List<NodeModel> _nodes = new();
    private readonly List<LinkModel> _links = new();
    private FlowchartDirection _direction = FlowchartDirection.TopToBottom;
}
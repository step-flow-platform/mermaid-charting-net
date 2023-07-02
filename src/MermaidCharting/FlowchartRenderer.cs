using System.Text;
using MermaidCharting.Model;

namespace MermaidCharting;

internal class FlowchartRenderer
{
    public FlowchartRenderer(FlowchartModel model)
    {
        _model = model;
    }

    public string Render()
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
        foreach (NodeModel node in _model.Nodes)
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
        foreach (LinkModel link in _model.Links)
        {
            string title = link.Title != null ? $"|{link.Title}|" : string.Empty;
            builder.AppendLine($"{link.FromId} -->{title} {link.ToId}");
        }
    }

    private void AddHeader(StringBuilder builder)
    {
        switch (_model.Direction)
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

    private readonly FlowchartModel _model;
}
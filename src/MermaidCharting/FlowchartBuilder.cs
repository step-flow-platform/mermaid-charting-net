using MermaidCharting.Model;

namespace MermaidCharting;

public class FlowchartBuilder
{
    public FlowchartBuilder SetDirection(FlowchartDirection direction)
    {
        _flowchartModel.Direction = direction;
        return this;
    }

    public FlowchartBuilder AddNode(NodeModel node)
    {
        _flowchartModel.Nodes.Add(node);
        return this;
    }

    public FlowchartBuilder AddLink(LinkModel link)
    {
        _flowchartModel.Links.Add(link);
        return this;
    }

    public FlowchartModel Build()
    {
        return _flowchartModel;
    }

    private readonly FlowchartModel _flowchartModel = new();
}
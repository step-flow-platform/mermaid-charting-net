namespace MermaidCharting;

public class FlowchartModel
{
    public FlowchartModel()
    {
        Nodes = new List<NodeModel>();
        Links = new List<LinkModel>();
    }

    public List<NodeModel> Nodes { get; }

    public List<LinkModel> Links { get; }
}
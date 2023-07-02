namespace MermaidCharting.Model;

public class FlowchartModel
{
    public FlowchartModel()
    {
        Nodes = new List<NodeModel>();
        Links = new List<LinkModel>();
    }

    public FlowchartDirection Direction { get; set; }

    public List<NodeModel> Nodes { get; set; }

    public List<LinkModel> Links { get; set; }
}
namespace MermaidCharting;

public class NodeModel
{
    public NodeModel(string id, string text, NodeType type = NodeType.Default)
    {
        Id = id;
        Text = text;
        Type = type;
    }

    public string Id { get; set; }

    public string Text { get; set; }

    public NodeType Type { get; set; }
}
namespace MermaidCharting;

public class LinkModel
{
    public LinkModel(string fromId, string toId, string? title = null)
    {
        FromId = fromId;
        ToId = toId;
        Title = title;
    }

    public string FromId { get; set; }

    public string ToId { get; set; }

    public string? Title { get; set; }
}
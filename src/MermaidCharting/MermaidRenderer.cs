using MermaidCharting.Model;

namespace MermaidCharting;

public static class MermaidRenderer
{
    public static string RenderFlowchart(FlowchartModel model)
    {
        FlowchartRenderer renderer = new(model);
        return renderer.Render();
    }
}
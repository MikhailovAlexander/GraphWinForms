using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphWinForms
{
    public class AlgorithmsVisualisator: GraphPrinter
    {
        private Graph<VisVertex> graph;
        private Dictionary<Edge<VisVertex>, Color> edgesHighlight;
        private Dictionary<Vertex<VisVertex>, Color> verticiesHighlight;
        public AlgorithmsVisualisator(GraphPrinter printer, Graph<VisVertex> graph) : base(printer.graphArea, printer.lblState)
        {
            this.graph = graph;
            edgesHighlight = new Dictionary<Edge<VisVertex>, Color>();
            foreach (var edge in graph.Edges) edgesHighlight.Add(edge, printer.EdgeColor);
            verticiesHighlight = new Dictionary<Vertex<VisVertex>, Color>();
            foreach (var vertex in graph.Vertices) verticiesHighlight.Add(vertex, printer.VertexColor);
        }
        public void SetEdgeColor(Edge<VisVertex> edge, Color color)
        {
            edgesHighlight[edge] = color;
        }
        public void SetVertexColor(Vertex<VisVertex> vertex, Color color)
        {
            verticiesHighlight[vertex] = color;
        }

        public void SetVertexColor(int vertexID, Color color)
        {
            var vertex = graph.Vertices[vertexID];
            if (verticiesHighlight.ContainsKey(vertex)) verticiesHighlight[vertex] = color;
        }

        public void Print(string stateText)
        {
            bitmap = new Bitmap(graphArea.Width, graphArea.Height);
            graphics = Graphics.FromImage(bitmap);
            graphics.Clear(areaBackColor);
            foreach (KeyValuePair<Edge<VisVertex>, Color> record in edgesHighlight)
            {
                edgePen.Color = record.Value;
                if (record.Key.IsLoop)
                {
                    PrintLoop(record.Key);
                    PrintLoopWeight(record.Key);
                }
                else
                {
                    PrintEdge(record.Key);
                    Printweight(record.Key);
                }
            }
            foreach (KeyValuePair<Vertex<VisVertex>, Color> record in verticiesHighlight)
            {
                vertexBrush.Color = record.Value;
                PrintVertex(record.Key);
            }
            graphArea.Image = bitmap;
            lblState.Text = stateText;
        }

        public void PrintState(string stateText)
        {
            lblState.Text = stateText;
        }
    }
}

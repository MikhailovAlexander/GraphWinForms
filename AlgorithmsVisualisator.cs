using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphWinForms
{
    public class AlgorithmsVisualisator: GraphPrinter
    {
        private Graph<VisVertex> graph;
        private Dictionary<Edge<VisVertex>, Color> edgesHighlight;
        private Dictionary<Vertex<VisVertex>, Color> verticiesHighlight;
        private Label lblLog;
        private PictureBox dataStructuresArea;

        public AlgorithmsVisualisator(GraphPrinter printer, Graph<VisVertex> graph, Label lblLog, PictureBox dataStructuresArea) : base(printer.graphArea, printer.lblState)
        {
            this.graph = graph;
            this.lblLog = lblLog;
            lblLog.Text = "Старт алгоритма.";
            edgesHighlight = new Dictionary<Edge<VisVertex>, Color>();
            this.dataStructuresArea = dataStructuresArea;
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

        public void ApEndLog(string text)
        {
            lblLog.Text = lblLog.Text + "\n" + text;
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

        public void PrintDataStructuresKruskal(Edge<VisVertex>[] list, Edge<VisVertex> currentEdge, int size = 20)
        {
            bitmap = new Bitmap(dataStructuresArea.Width, dataStructuresArea.Height);
            graphics = Graphics.FromImage(bitmap);
            graphics.Clear(areaBackColor);
            PrintSortedEdgeList(list, currentEdge, new Point(3, 3), 20, 400);
            dataStructuresArea.Image = bitmap;
        }

        public void PrintDataStructuresPrim(AdjVertexSortedList[] lists, AdjVertexSortedList mstList, int inMSTSize = 12, int aslSize = 20)
        {
            int width = Max(GetMaxLenght() * aslSize + 200, dataStructuresArea.Width);
            int height = Max(lists.Length * aslSize + 100, dataStructuresArea.Height);
            bitmap = new Bitmap(width, height);
            graphics = Graphics.FromImage(bitmap);
            graphics.Clear(areaBackColor);
            Point point = new Point(3, 3);
            PrintInMSTVertices(point, inMSTSize);
            point.Offset(0, inMSTSize + 3);
            dataStructuresArea.Image = bitmap;
            PrintASL(mstList, "МОД", point, aslSize);
            point.Offset(0, aslSize + 3);
            for (int i = 0; i < lists.Length; i++)
            {
                if (lists[i].IsEmpty) continue;
                PrintASL(lists[i], i.ToString(), point, aslSize);
                point.Offset(0, aslSize + 3);
            }
            int GetMaxLenght()
            {
                int max = 0;
                foreach (var row in lists)
                    if (row.Length> max) max = row.Length;
                return max;
            }

            int Max(int a, int b)
            {
                if (a > b) return a;
                return b;
            }
        }

        private void PrintInMSTVertices(Point point, int size)
        {
            float nameSize = graphics.MeasureString("Вершины в МОД", smallFont).Width;
            graphics.DrawString("Вершины в МОД", smallFont, textBrush, point);
            point = new Point(point.X + (int)nameSize + 1, point.Y);
            foreach (KeyValuePair<Vertex<VisVertex>, Color> record in verticiesHighlight)
            {
                vertexBrush.Color = record.Value;
                var rect = new Rectangle(point.X, point.Y, size, size);
                graphics.DrawRectangle(borderPen, rect);
                graphics.FillRectangle(vertexBrush, rect);
                point.Offset(size,0);
            }
        }

        private void PrintASL(AdjVertexSortedList list, string name, Point point, int size)
        {
            float nameSize = graphics.MeasureString(name, smallFont).Width;
            graphics.DrawString(name, smallFont, textBrush, point);
            point = new Point(point.X + (int)nameSize + 1, point.Y);
            foreach(Edge<VisVertex> edge in list)
            {
                PrintEdgeRectangle(edge, point, size);
                point = new Point(point.X + size, point.Y);
            }
        }

        private void PrintEdgeRectangle(Edge<VisVertex> edge, Point point, int size)
        {
            var rect = new Rectangle(point.X, point.Y, size, size);
            vertexBrush.Color = verticiesHighlight[graph.Vertices[edge.V2Id]];
            graphics.DrawRectangle(borderPen, rect);
            graphics.FillRectangle(vertexBrush, rect);
            vertexBrush.Color = verticiesHighlight[graph.Vertices[edge.V1Id]];
            Point[] triangle = new Point[] 
            { point, new Point(point.X, point.Y + size), new Point(point.X + size, point.Y + size) };
            graphics.FillPolygon(vertexBrush, triangle);
            graphics.DrawString(edge.Weight.ToString(), smallFont, textBrush, point);
        }

        private void PrintSortedEdgeList(Edge<VisVertex>[] list, Edge<VisVertex>  currentEdge, 
            Point point, int size, int rightBorder)
        {
            Point leftBorder = point;
            float nameSize = graphics.MeasureString("Сортированные ребра", smallFont). Height;
            graphics.DrawString("Сортированные ребра", smallFont, textBrush, point);
            leftBorder.Offset(0, (int)nameSize + 3);
            point = leftBorder;
            foreach (var edge in list)
            {
                PrintEdgeRectangle(edge, point, size);
                if(edge == currentEdge)
                {
                    var rect = new Rectangle(point.X, point.Y, size-2, size);
                    Pen pen = new Pen(Color.Red, 3);
                    graphics.DrawRectangle(pen, rect);
                }
                if (point.X + size * 2 > rightBorder)
                {
                    leftBorder.Offset(0, size + 3);
                    point = leftBorder;
                }
                else point.Offset(size, 0);
            }
        }
    }
}

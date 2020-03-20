using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GraphWinForms.Geometry;

namespace GraphWinForms
{
    class GraphPrinter
    {
        private PictureBox graphArea;
        private Graphics graphics;
        private Bitmap bitmap;
        private Label lblState;
        private Pen weigthEdgePen;
        private Pen edgePen;
        //private Graph<VisVertex> graph;

        public GraphPrinter(PictureBox graphArea, Label lblState, Graph<VisVertex> graph)
        {
            this.graphArea = graphArea;
            this.lblState = lblState;
            //this.graph = graph;
            bitmap = new Bitmap(graphArea.Width, graphArea.Height);
            graphics = Graphics.FromImage(bitmap);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            weigthEdgePen = new Pen(Color.Black);
            edgePen = new Pen(Color.Red);
        }

        public void Print(Graph<VisVertex> graph, Vertex<VisVertex> currentVertex = null, int x = 0, int y = 0)
        {
            bitmap = new Bitmap(graphArea.Width, graphArea.Height);
            graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.Yellow);
            foreach (var edge in graph.Edges)
            {
                if (edge.IsLoop)
                {
                    PrintLoop(edge);
                    PrintLoopWeight(edge);
                }
                else
                {
                    PrintEdge(edge);
                    Printweight(edge);
                }
            }
            foreach (var vertex in graph.Vertices)
                PrintVertex(vertex);
            if(currentVertex != null)//режим добавления нового ребра
            {
                graphics.DrawLine(edgePen, currentVertex.Data.GetPoint, new Point(x,y));
            }
            graphArea.Image = bitmap;
            PrintGraphState(graph);
        }

        private void PrintVertex(Vertex<VisVertex> vertex)
        {
            int x = vertex.Data.PositionX - 10;
            int y = vertex.Data.PositionY - 10;
            graphics.DrawEllipse(new Pen(Color.Red, 2), new Rectangle(x, y, 20, 20));
            graphics.FillEllipse(new SolidBrush(Color.Green), new Rectangle(x, y, 20, 20));
            graphics.DrawString(vertex.Data.Name, new Font("Times New Roman", 12, FontStyle.Bold, GraphicsUnit.Pixel),
                    Brushes.Black, x + 5, y + 2);
        }

        private void PrintEdge(Edge<VisVertex> edge)
        {
            Point p1 = edge.Data1.GetPoint;
            Point p2 = edge.Data2.GetPoint;
            graphics.DrawLine(edgePen, p1, p2);
        }

        private void Printweight(Edge<VisVertex> edge)
        {
            Point p1 = edge.Data1.GetPoint;
            Point p2 = edge.Data2.GetPoint;
            Point midle = GetMidle(p1, p2);
            Pen pen = new Pen(Color.Black);
            var rect = new Rectangle(midle.X - 10, midle.Y -10, 12, 12);
            graphics.DrawRectangle(pen, rect);
            graphics.FillRectangle(Brushes.White, rect);
            graphics.DrawString(edge.Weight.ToString(), new Font("Times New Roman", 10, FontStyle.Bold, GraphicsUnit.Pixel),
                    Brushes.Black, midle.X - 10, midle.Y - 10);
        }

        private void PrintLoop(Edge<VisVertex> edge)
        {
            Point point = edge.Data1.GetPoint;
            graphics.DrawEllipse(edgePen, new Rectangle(point.X, point.Y, -30, 30));
        }

        private void PrintLoopWeight(Edge<VisVertex> edge)
        {
            Point point = edge.Data1.GetPoint;
            var rect = new Rectangle(point.X - 30, point.Y + 20, 12, 12);
            graphics.DrawRectangle(weigthEdgePen, rect);
            graphics.FillRectangle(Brushes.White, rect);
            graphics.DrawString(edge.Weight.ToString(), new Font("Times New Roman", 10, FontStyle.Bold, GraphicsUnit.Pixel),
                    Brushes.Black, point.X - 30, point.Y + 20);
        }

        private void PrintGraphState(Graph<VisVertex> graph)
        {
            string graphConn = graph.IsConnected ? "" : "не";
            lblState.Text = $"Граф {graphConn}связен, порядок: {graph.Order}, " +
                $"количество ребер: {graph.EdgesCount}, общий вес: {graph.TotalWeight}";
        }
    }
}

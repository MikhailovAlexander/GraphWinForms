﻿using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using static GraphWinForms.Geometry;

namespace GraphWinForms
{
    public class GraphPrinter
    {
        public PictureBox graphArea;
        protected Graphics graphics;
        protected Bitmap bitmap;
        public Label lblState;
        protected Pen borderPen;
        protected Pen edgePen;
        protected Font mainFont;
        protected Font smallFont;
        public Color areaBackColor { get; set; }
        protected SolidBrush vertexBrush;
        protected SolidBrush weightBrush;
        protected SolidBrush textBrush;
        public Color VertexColor => vertexBrush.Color;
        public Color EdgeColor => edgePen.Color;

        public GraphPrinter(PictureBox graphArea, Label lblState)
        {
            this.graphArea = graphArea;
            this.lblState = lblState;
            bitmap = new Bitmap(graphArea.Width, graphArea.Height);
            graphics = Graphics.FromImage(bitmap);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            borderPen = new Pen(Color.Black,2);
            edgePen = new Pen(Color.Black,2);
            mainFont = new Font("Times New Roman", 12, FontStyle.Bold, GraphicsUnit.Pixel);
            smallFont = new Font("Times New Roman", 10, FontStyle.Bold, GraphicsUnit.Pixel);
            areaBackColor = Color.FromArgb(0xBF, 0xEF, 0xAA);
            vertexBrush = new SolidBrush(Color.Green);
            weightBrush = new SolidBrush(Color.White);
            textBrush = new SolidBrush(Color.Black);
        }

        public void Print(
            Graph<VisVertex> graph, bool printId, Vertex<VisVertex> currentVertex = null, int x = 0, int y = 0)
        {
            bitmap = new Bitmap(graphArea.Width, graphArea.Height);
            graphics = Graphics.FromImage(bitmap);
            graphics.Clear(areaBackColor);
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
                PrintVertex(vertex, printId);
            if(currentVertex != null)//режим добавления нового ребра
            {
                graphics.DrawLine(edgePen, currentVertex.Data.GetPoint, new Point(x,y));
            }
            graphArea.Image = bitmap;
            PrintGraphState(graph);
        }

        protected void PrintVertex(Vertex<VisVertex> vertex, bool printId)
        {
            int x = vertex.Data.PositionX - 10;
            int y = vertex.Data.PositionY - 10;
            string vertexName = printId? vertex.Id.ToString(): vertex.Data.Name;
            graphics.DrawEllipse(borderPen, new Rectangle(x, y, 20, 20));
            graphics.FillEllipse(vertexBrush, new Rectangle(x, y, 20, 20));
            graphics.DrawString(vertexName, mainFont, textBrush, x + 5, y + 2);
        }

        protected void PrintEdge(Edge<VisVertex> edge)
        {
            Point p1 = edge.Data1.GetPoint;
            Point p2 = edge.Data2.GetPoint;
            graphics.DrawLine(edgePen, p1, p2);
        }

        protected void Printweight(Edge<VisVertex> edge)
        {
            Point p1 = edge.Data1.GetPoint;
            Point p2 = edge.Data2.GetPoint;
            Point midle = GetMidle(p1, p2);
            var rect = new Rectangle(midle.X - 10, midle.Y -10, 12, 12);
            graphics.DrawRectangle(borderPen, rect);
            graphics.FillRectangle(weightBrush, rect);
            graphics.DrawString(edge.Weight.ToString(), smallFont,
                    textBrush, midle.X - 10, midle.Y - 10);
        }

        protected void PrintLoop(Edge<VisVertex> edge)
        {
            Point point = edge.Data1.GetPoint;
            graphics.DrawEllipse(edgePen, new Rectangle(point.X, point.Y, -30, 30));
        }

        protected void PrintLoopWeight(Edge<VisVertex> edge)
        {
            Point point = edge.Data1.GetPoint;
            var rect = new Rectangle(point.X - 30, point.Y + 20, 12, 12);
            graphics.DrawRectangle(borderPen, rect);
            graphics.FillRectangle(weightBrush, rect);
            graphics.DrawString(edge.Weight.ToString(), smallFont,
                    textBrush, point.X - 30, point.Y + 20);
        }

        protected void PrintGraphState(Graph<VisVertex> graph)
        {
            string graphConn = graph.IsConnected ? "" : "не";
            lblState.Text = $"Граф {graphConn}связен, порядок: {graph.Order}, " +
                $"количество ребер: {graph.EdgesCount}, общий вес: {graph.TotalWeight}";
        }
    }
}

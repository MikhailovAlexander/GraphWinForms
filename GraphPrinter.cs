﻿using System;
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
        private Pen borderPen;
        private Pen edgePen;
        private Font mainFont;
        private Font smallFont;
        private Color areaBackColor;
        private SolidBrush vertexBrush;
        private SolidBrush weightBrush;
        private SolidBrush textBrush;

        public GraphPrinter(PictureBox graphArea, Label lblState)
        {
            this.graphArea = graphArea;
            this.lblState = lblState;
            bitmap = new Bitmap(graphArea.Width, graphArea.Height);
            graphics = Graphics.FromImage(bitmap);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            borderPen = new Pen(Color.Black,2);
            edgePen = new Pen(Color.Red,2);
            mainFont = new Font("Times New Roman", 12, FontStyle.Bold, GraphicsUnit.Pixel);
            smallFont = new Font("Times New Roman", 10, FontStyle.Bold, GraphicsUnit.Pixel);
            areaBackColor = Color.Yellow;
            vertexBrush = new SolidBrush(Color.Green);
            weightBrush = new SolidBrush(Color.White);
            textBrush = new SolidBrush(Color.Black);
        }

        public void Print(Graph<VisVertex> graph, Vertex<VisVertex> currentVertex = null, int x = 0, int y = 0)
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
            graphics.DrawEllipse(borderPen, new Rectangle(x, y, 20, 20));
            graphics.FillEllipse(vertexBrush, new Rectangle(x, y, 20, 20));
            graphics.DrawString(vertex.Data.Name, mainFont, textBrush, x + 5, y + 2);
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
            var rect = new Rectangle(midle.X - 10, midle.Y -10, 12, 12);
            graphics.DrawRectangle(borderPen, rect);
            graphics.FillRectangle(weightBrush, rect);
            graphics.DrawString(edge.Weight.ToString(), smallFont,
                    textBrush, midle.X - 10, midle.Y - 10);
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
            graphics.DrawRectangle(borderPen, rect);
            graphics.FillRectangle(weightBrush, rect);
            graphics.DrawString(edge.Weight.ToString(), smallFont,
                    textBrush, point.X - 30, point.Y + 20);
        }

        private void PrintGraphState(Graph<VisVertex> graph)
        {
            string graphConn = graph.IsConnected ? "" : "не";
            lblState.Text = $"Граф {graphConn}связен, порядок: {graph.Order}, " +
                $"количество ребер: {graph.EdgesCount}, общий вес: {graph.TotalWeight}";
        }
    }
}

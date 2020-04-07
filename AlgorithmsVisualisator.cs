using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphWinForms
{
    public class TreePointsDSU
    {
        private int id;
        private int root;
        private List<TreePointsDSU> branches;
        public int Id => id;
        public int Root => root;
        public bool IsLeaf => branches.Count == 0;
        public Point Point { get; set; }
        public bool IsEmpty => Point == Point.Empty;
        public int Levels => LevelCounter(0);
        public int BranchesCount => branches.Count;
        public IReadOnlyCollection<TreePointsDSU> BranchesReadOnly => branches;

        public TreePointsDSU(int id, int root)
        {
            this.id = id;
            this.root = root;
            branches = new List<TreePointsDSU>();
            Point = Point.Empty;
        }

        public static List<TreePointsDSU> GetTrees(IValiableDSU dsu, Point firstPoint, int size, int interval)
        {
            firstPoint.Offset(size / 2, size / 2);
            List<TreePointsDSU> trees = new List<TreePointsDSU>();
            TreePointsDSU currentTree;
            for (int i = 0; i < dsu.GetCount(); i++)
            {
                if (dsu.GetValue(i) == i)
                {
                    currentTree = new TreePointsDSU(i, i);
                    trees.Add(currentTree);
                    FindAllBranches(currentTree);
                }
            }
            ListSetPoints(trees, firstPoint, size, interval);
            return trees;
            void FindAllBranches(TreePointsDSU tree)
            {
                TreePointsDSU addedTree;
                for (int i = 0; i < dsu.GetCount(); i++)
                {
                    if(dsu.GetValue(i) == tree.id && i != tree.id)
                    {
                        addedTree = new TreePointsDSU(i, tree.root);
                        tree.branches.Add(addedTree);
                        FindAllBranches(addedTree);
                    }
                }
            }
        }

        private static void ListSetPoints(List<TreePointsDSU> list, Point firstPoint, int size, int interval)
        {
            int X = firstPoint.X;
            foreach (var tree in list)
                X = tree.SetPoints(X, firstPoint.Y, size, interval);
        }

        public int SetPoints(int X, int Y, int size, int interval)
        {
            int leftBound = X;
            if (this.IsLeaf)
            {
                Point = new Point(X, Y);
                return X + size + interval;
            }
            foreach(var branch in this.branches)
            {
                X = branch.SetPoints(X, Y + size + interval, size, interval);
            }
            this.Point = new Point((leftBound + X)/2,Y);
            return X;
        }

        private int LevelCounter(int level)
        {
            if (this.IsLeaf) return level++;
            int levelCnt = level + 1; 
            foreach (var tree in this.branches)
                levelCnt = Max(levelCnt, tree.LevelCounter(level + 1));
            return levelCnt;
        }

        int Max(int a, int b)
        {
            if (a > b) return a;
            return b;
        }
    }

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

        public void PrintDataStructuresKruskal(Edge<VisVertex>[] list, Edge<VisVertex> currentEdge, IValiableDSU dsu, Color[] colors, int size = 20)
        {
            bitmap = new Bitmap(dataStructuresArea.Width, dataStructuresArea.Height);
            graphics = Graphics.FromImage(bitmap);
            graphics.Clear(areaBackColor);
            Point leftBorder = PrintSortedEdgeList(list, currentEdge, new Point(3, 3), 20, 400);
            float nameSize = graphics.MeasureString("DSU", smallFont).Height;
            graphics.DrawString("DSU", smallFont, textBrush, leftBorder);
            leftBorder.Offset(0, (int)nameSize + 3);
            List<TreePointsDSU> dsuTrees = TreePointsDSU.GetTrees(dsu, leftBorder, size, 3);
            PrintDSU(dsuTrees, size, colors);
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

        private Point PrintSortedEdgeList(Edge<VisVertex>[] list, Edge<VisVertex>  currentEdge, 
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
            leftBorder.Offset(0, size + 3);
            return leftBorder;
        }

        private void PrintDSU(List<TreePointsDSU> trees, int size, Color[] colors)
        {
            foreach (var tree in trees) PrintTreeDSU(tree);
            void PrintTreeDSU(TreePointsDSU tree)
            {
                int x = tree.Point.X - size/2;
                int y = tree.Point.Y - size/2;
                vertexBrush.Color = colors[tree.Root];
                graphics.DrawEllipse(borderPen, new Rectangle(x, y, size, size));
                graphics.FillEllipse(vertexBrush, new Rectangle(x, y, size, size));
                graphics.DrawString(tree.Id.ToString(), smallFont, textBrush, x + 5, y + 2);
                if (tree.IsLeaf) return;
                foreach (var branch in tree.BranchesReadOnly) PrintTreeDSU(branch);
            }
        }
    }
}

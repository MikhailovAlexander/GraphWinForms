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
    public partial class Form1 : Form
    {
        private Graph<VisVertex> graph;
        private Random rnd;
        private GraphGenerator randomGraph;
        private GraphPrinter printer;
        private Vertex<VisVertex> currentVertex;
        private Edge<VisVertex> currentEdge;

        public Form1()
        {
            InitializeComponent();
            rnd = new Random();
            randomGraph = new GraphGenerator();
            graph = randomGraph.GetGraphWeight(10, 200, 200, 25, 20, true, false);
            printer = new GraphPrinter(GraphArea, lblGraphState);
            currentVertex = null;
        }

        private void btnGenerateGraph_Click(object sender, EventArgs e)
        {
            graph = randomGraph.GetGraphWeight(tBarOrder.Value, GraphArea.Width, GraphArea.Height - pnlGraphState.Height, 
                tBarProbability.Value, tBarMaxWeight.Value, chBoxWithoutLoop.Checked, chBoxDiffWheight.Checked);
            printer.Print(graph);
            ShowMatrixOrLists();
        }

        private void tBarProbability_Scroll(object sender, EventArgs e)
        {
            lblProbability.Text = $"Вероятность соединения вершин: {tBarProbability.Value}%";
        }

        private void tBarOrder_Scroll(object sender, EventArgs e)
        {
            lblOrder.Text = $"Порядок графа: {tBarOrder.Value}";
        }

        private void tBarMaxWeight_Scroll(object sender, EventArgs e)
        {
            lblMaxWeight.Text = $"Максимальный вес ребра: {tBarMaxWeight.Value}";
        }

        private int GetIndexVertex(Point point)
        {
            foreach (var vertex in graph.Vertices)
                if (GetDistanse(vertex.Data.GetPoint, point) < 20) return vertex.Id;
            return -1;
        }

        private Edge<VisVertex> GetEdge(Point point2Check)
        {
            int index = GetIndexVertex(point2Check);
            foreach (var edge in graph.Edges)
                if (index != -1 && edge.IsIncident(index) && edge.IsLoop) return edge;//Если попави в вершину -ищем петлю
                else if (index == -1 
                        && GetDistanseToLine(edge.Data1.GetPoint, edge.Data2.GetPoint, point2Check) < 3)
                        return edge;
            return null;
        }

        private void GraphArea_MouseMove(object sender, MouseEventArgs e)
        {
            if (currentVertex == null || e.Button != MouseButtons.Left) return;
            if (rbVertexMove.Checked)
            {
                if (!GraphArea.ClientRectangle.Contains(e.Location)
                    || e.Y >= GraphArea.Height - pnlGraphState.Height)
                {
                    currentVertex = null;
                    return;
                }
                currentVertex.Data.SetPoint(e.Location);
                printer.Print(graph);
            }
            else if (rbEdgeAdd.Checked) printer.Print(graph, currentVertex, e.X, e.Y);
        }

        private void GraphArea_MouseUp(object sender, MouseEventArgs e)
        {
            if (rbVertexMove.Checked) currentVertex = null;
            else if (rbEdgeAdd.Checked && currentVertex != null)
            {
                int index = GetIndexVertex(e.Location);
                if (index != -1 && !graph.IsConnectedVertices(index, currentVertex.Id))
                {
                    graph.AddEdge(currentVertex.Id, index, rnd.Next(1, tBarMaxWeight.Value));
                    ShowMatrixOrLists();
                }
                printer.Print(graph);
            }
        }

        private void GraphArea_MouseDown(object sender, MouseEventArgs e)
        {

            int index = GetIndexVertex(e.Location);
            if (rbVertexMove.Checked||rbEdgeAdd.Checked)
            {
                if (index != -1 && e.Button == MouseButtons.Left)
                    currentVertex = graph.Vertices[index];
            }
            else if(rbVertexAdd.Checked)
            {
                index = graph.Order;
                graph.AddVertex(new Vertex<VisVertex>(index,new VisVertex(index.ToString(), e.Location)));
                printer.Print(graph);
                ShowMatrixOrLists();
            }
            else if(rbVertexRemove.Checked)
            {
                if (graph.Order == 1) return;
                if (index != -1 && e.Button == MouseButtons.Left)
                    graph.RemoveVertex(graph.Vertices[index]);
                printer.Print(graph);
                ShowMatrixOrLists();
            }
            else if(rbEdgeRemove.Checked)
            {
                var edge2Remove = GetEdge(e.Location);
                if (edge2Remove != null)
                {
                    graph.RemoveEdge(edge2Remove);
                    printer.Print(graph);
                    ShowMatrixOrLists();
                }
            }
            else if(rbChangeWeight.Checked)
            {
                currentEdge = GetEdge(e.Location);
                if (currentEdge != null)
                {
                    Point p1 = currentEdge.Data1.GetPoint;
                    Point p2 = currentEdge.Data2.GetPoint;
                    Point weightPoint = GetMidle(p1, p2);
                    if(currentEdge.IsLoop)
                    {
                        weightPoint.X = weightPoint.X - 20;
                        weightPoint.Y = weightPoint.Y + 30;
                    }
                    mtbChangeWeight.Clear();
                    mtbChangeWeight.Visible = true;
                    mtbChangeWeight.Location = weightPoint;
                    mtbChangeWeight.Focus();
                }
                else
                {
                    mtbChangeWeight.Clear();
                    mtbChangeWeight.Visible = false;
                    currentEdge = null;
                }
            }
        }

        private void mtbChangeWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && !String.IsNullOrWhiteSpace(mtbChangeWeight.Text))
            {
                try { currentEdge.Weight = int.Parse(mtbChangeWeight.Text); }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                mtbChangeWeight.Clear();
                mtbChangeWeight.Visible = false;
                currentEdge = null;
                printer.Print(graph);
                ShowMatrixOrLists();
            }
        }

        private void ShowMatrixOrLists()
        {
            if (rbAdjMatrix.Checked) ShowMatrix();
            else if (rbAdjLists.Checked) ShowAdjLists();
        }

        private void ShowMatrix()
        {
            int[,] matrix = graph.GetAdjWeightMatrix();
            dgvAdjMatrix.Columns.Clear();
            dgvAdjMatrix.Rows.Clear();
            foreach(var vertex in graph.Vertices)
            {
                dgvAdjMatrix.Columns.Add(vertex.Data.Name, vertex.Data.Name);
                dgvAdjMatrix.Rows.Add(vertex.Data.Name, vertex.Data.Name);
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                dgvAdjMatrix.Columns[i].Width = 20;
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    dgvAdjMatrix.Rows[i].Height = 20;
                    if (matrix[i, j] != -1)
                        dgvAdjMatrix.Rows[i].Cells[j].Value = matrix[i, j];
                }
            }
        }

        private void ShowAdjLists()
        {
            string[][] lists = AdjVertexSortedList.GetStringAdjLists(graph);
            int maxLenght = GetMaxLenght();
            dgvAdjMatrix.Columns.Clear();
            dgvAdjMatrix.Rows.Clear();
            if (maxLenght == 0) return;
            for (int i = 0; i < maxLenght; i++)
            {
                dgvAdjMatrix.Columns.Add(i.ToString(), i.ToString());
                dgvAdjMatrix.Columns[i].Width = 60;
            }
            for (int i = 0; i < lists.Length; i++)
            {
                dgvAdjMatrix.Rows.Add();
                dgvAdjMatrix.Rows[i].Height = 18;
                dgvAdjMatrix.Rows[i].HeaderCell.Value = i;
            }
            for (int i = 0; i < lists.Length; i++)
            {
                for (int j = 0; j < lists[i].Length; j++)
                {
                    dgvAdjMatrix.Rows[i].Cells[j].Value = lists[i][j];
                }
            }

            int GetMaxLenght()
            {
                int max = 0;
                foreach (var row in lists)
                    if (row.Length > max) max = row.Length;
                return max;
            }
        }

        private void rbAdjMatrix_CheckedChanged(object sender, EventArgs e)
        {
            ShowMatrixOrLists();
        }

        private void rbAdjLists_CheckedChanged(object sender, EventArgs e)
        {
            ShowMatrixOrLists();
        }

        private void btnSetWeigthAsDiastance_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < graph.EdgesCount; i++)
                graph.Edges[i].Weight = (int)Geometry.GetDistanse(
                    graph.Edges[i].Data1.GetPoint, graph.Edges[i].Data2.GetPoint)/10;
            printer.Print(graph);
            ShowMatrixOrLists();
        }

        private void btnShowMST_Click(object sender, EventArgs e)
        {
            try
            {
                graph = MSTAlgorithms.GetMST_KrusculDSU(graph);
                printer.Print(graph);
                ShowMatrixOrLists();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnStartPrim_Click(object sender, EventArgs e)
        {
            var algVis = new MSTAlgorithms(printer, graph);
            algVis.SleepInterval = tbSpeedVis.Value*500;
            try { algVis.PrimsAlgorithmVisAsync(Color.Red); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}

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
        private const string descrPrim = "Алгоритм Прима\nВыибирается произвольная вершина и находится ребро, инцидентное ей с наименьшей стоимостью. Найденное ребро и его вершины образуют дерево. \nЗатем, рассматриваются рёбра графа, один конец которых — уже принадлежит дереву, а другой — нет; из этих рёбер выбирается ребро наименьшей стоимости. Выбираемое на каждом шаге ребро присоединяется к дереву.\n\tРост дерева происходит до тех пор, пока не будут присоединены все вершины исходного графа.";
        private const string descrKruskal = "Алгоритм Краскала\n\tСписок ребер исходного графа упорядочивается по неубыванию веса. Далее ребра перебираются от ребер с меньшим весом к большему. Очередное ребро добавляется к каркасу, если оно не образовывает цикла с ранее выбранными. Первым всегда выбирается одно из ребер минимального веса в графе.";
        private const string descrBoruvka = "Алгоритм Борувки состоит из следующих шагов:\n1. Изначально МОД содержит все вершины исходного графа и не содержит ребер(каждая вершина — отдельная компонента связности). \n2. На каждом шаге алгоритма для каждой компоненты связности находим минимальное по весу ребро, которое связывает эту компоненту с другой. В МОД добавляются выбранные ребра.\n3. Шаг 2 повторяется пока не будут объединены все компоненты.";
        private Graph<VisVertex> graph;
        private Random rnd;
        private GraphGenerator randomGraph;
        private GraphPrinter printer;
        private Vertex<VisVertex> currentVertex;
        private Edge<VisVertex> currentEdge;
        private Stack<Graph<VisVertex>> back;
        private Stack<Graph<VisVertex>> forward;
        private bool vertexMove;

        public Form1()
        {
            InitializeComponent();
            rnd = new Random();
            tBarProbability.Value = 20;
            tBarOrder.Value = 10;
            tBarMaxWeight.Value = 10;
            randomGraph = new GraphGenerator();
            graph = randomGraph.GetGraphWeight(1, 200, 200, 25, 20, true, false);
            printer = new GraphPrinter(GraphArea, lblGraphState);
            currentVertex = null;
            lblDescription.Text = descrPrim;
            back = new Stack<Graph<VisVertex>>(100);
            back.Push((Graph<VisVertex>)graph.Clone());
            forward = new Stack<Graph<VisVertex>>(100);
            vertexMove = false;
        }

        public void BlockTabControl()
        {
            pnlGraphEditor.Enabled = false;
            pnlAlgorithmsControls.Enabled = false;
        }

        public void UnBlockTabControl()
        {
            pnlGraphEditor.Enabled = true;
            pnlAlgorithmsControls.Enabled = true;
        }

        #region GraphGenerator
        private void btnGenerateGraph_Click(object sender, EventArgs e)
        {
            back.Push((Graph<VisVertex>)graph.Clone());
            graph = randomGraph.GetGraphWeight(tBarOrder.Value, GraphArea.Width, 
                GraphArea.Height - pnlGraphState.Height, tBarProbability.Value, tBarMaxWeight.Value,
                chBoxWithoutLoop.Checked, chBoxDiffWheight.Checked);
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
        #endregion GraphGenerator

        #region GraphEditor
        private void btnSetWeigthAsDiastance_Click(object sender, EventArgs e)
        {
            SaveGraph();
            for (int i = 0; i < graph.EdgesCount; i++)
                graph.Edges[i].Weight = (int)Geometry.GetDistanse(
                    graph.Edges[i].Data1.GetPoint, graph.Edges[i].Data2.GetPoint) / 10;
            printer.Print(graph);
            ShowMatrixOrLists();
        }

        private void btnShowMST_Click(object sender, EventArgs e)
        {
            try
            {
                SaveGraph();
                graph = MSTAlgorithms.GetMST_KrusculDSU(graph);
                printer.Print(graph);
                ShowMatrixOrLists();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void GraphArea_MouseMove(object sender, MouseEventArgs e)
        {
            if (currentVertex == null || e.Button != MouseButtons.Left || !tcPages.Enabled) return;
            if (rbVertexMove.Checked)
            {
                if (!GraphArea.ClientRectangle.Contains(e.Location)
                    || e.Y >= GraphArea.Height - pnlGraphState.Height)
                {
                    currentVertex = null;
                    vertexMove = false;
                    return;
                }
                SaveGraph();
                if (vertexMove) back.Pop();
                vertexMove = true;
                currentVertex.Data.SetPoint(e.Location);
                printer.Print(graph);
            }
            else if (rbEdgeAdd.Checked) printer.Print(graph, currentVertex, e.X, e.Y);
        }

        private void GraphArea_MouseUp(object sender, MouseEventArgs e)
        {
            if (!pnlGraphEditor.Enabled) return;
            if (rbVertexMove.Checked)
            {
                currentVertex = null;
                vertexMove = false;
            }
            else if (rbEdgeAdd.Checked && currentVertex != null)
            {
                int index = GetIndexVertex(e.Location);
                if (index != -1 && !graph.IsConnectedVertices(index, currentVertex.Id))
                {
                    SaveGraph();
                    graph.AddEdge(currentVertex.Id, index, rnd.Next(1, tBarMaxWeight.Value));
                    ShowMatrixOrLists();
                }
                printer.Print(graph);
            }
        }

        private void GraphArea_MouseDown(object sender, MouseEventArgs e)
        {
            if (!pnlGraphEditor.Enabled) return;
            int index = GetIndexVertex(e.Location);
            if (rbVertexMove.Checked||rbEdgeAdd.Checked)
            {
                if (index != -1 && e.Button == MouseButtons.Left)
                    currentVertex = graph.Vertices[index];
            }
            else if(rbVertexAdd.Checked)
            {

                SaveGraph();
                index = graph.Order;
                graph.AddVertex(
                    new Vertex<VisVertex>(index,new VisVertex(index.ToString(), e.Location)));
                printer.Print(graph);
                ShowMatrixOrLists();
            }
            else if(rbVertexRemove.Checked)
            {
                if (graph.Order == 1) return;
                if (index != -1 && e.Button == MouseButtons.Left)
                {
                    SaveGraph();
                    graph.RemoveVertex(graph.Vertices[index]);
                }
                printer.Print(graph);
                ShowMatrixOrLists();
            }
            else if(rbEdgeRemove.Checked)
            {
                var edge2Remove = GetEdge(e.Location);
                if (edge2Remove != null)
                {
                    SaveGraph();
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
                try
                {
                    SaveGraph();
                    currentEdge.Weight = int.Parse(mtbChangeWeight.Text);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                mtbChangeWeight.Clear();
                mtbChangeWeight.Visible = false;
                currentEdge = null;
                printer.Print(graph);
                ShowMatrixOrLists();
            }
        }

        private void SaveGraph()
        {
            back.Push((Graph<VisVertex>)graph.Clone());
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (back.Count == 0) return;
            forward.Push((Graph<VisVertex>)graph.Clone());
            graph = back.Pop();
            printer.Print(graph);
            ShowMatrixOrLists();
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            if (forward.Count == 0) return;
            back.Push((Graph<VisVertex>)graph.Clone());
            graph = forward.Pop();
            printer.Print(graph);
            ShowMatrixOrLists();
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
                if (index != -1 && edge.IsIncident(index) && edge.IsLoop)
                    return edge;//Если попали в вершину -ищем петлю
                else if (index == -1 && GetDistanseToLine(
                    edge.Data1.GetPoint, edge.Data2.GetPoint, point2Check) < 3)
                    return edge;
            return null;
        }
        #endregion GraphEditor

        #region AdjMatrixAndLists
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
            dgvAdjMatrix.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvAdjMatrix.Columns.Add("RowHeader", "");
            foreach (var vertex in graph.Vertices)
            {
                dgvAdjMatrix.Columns.Add(vertex.Data.Name, vertex.Data.Name);
                dgvAdjMatrix.Rows.Add(vertex.Data.Name);
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 1; j <= matrix.GetLength(0); j++)
                {
                    if (matrix[i, j-1] != -1)
                        dgvAdjMatrix.Rows[i].Cells[j].Value = matrix[i, j-1].ToString();
                }
            }
            for (int i = 0; i < dgvAdjMatrix.Columns.Count; i++)
                dgvAdjMatrix.Columns[i].Width = 20;
        }

        private void ShowAdjLists()
        {
            string[][] lists = AdjVertexSortedList.GetStringAdjLists(graph);
            int maxLenght = GetMaxLenght();
            dgvAdjMatrix.Columns.Clear();
            dgvAdjMatrix.Rows.Clear();
            dgvAdjMatrix.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            if (maxLenght == 0) return;
            for (int i = 0; i <= maxLenght; i++)
            {
                dgvAdjMatrix.Columns.Add(i.ToString(), "");
                dgvAdjMatrix.Columns[i].Width = 60;
            }
            for (int i = 0; i < lists.Length; i++)
            {
                dgvAdjMatrix.Rows.Add();
                dgvAdjMatrix.Rows[i].Height = 18;
            }
            for (int i = 0; i < lists.Length; i++)
            {
                for (int j = 0; j <= lists[i].Length; j++)
                {
                    if (j == 0)
                    {
                        dgvAdjMatrix.Rows[i].Cells[j].Value = i.ToString();
                        dgvAdjMatrix.Rows[i].Cells[j].Style.BackColor = printer.VertexColor;
                    }
                    else dgvAdjMatrix.Rows[i].Cells[j].Value = lists[i][j - 1];
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
        #endregion AdjMatrixAndLists

        #region Visualisator
        private void btnStartAlgorithm_Click(object sender, EventArgs e)
        {
            var algVis = new MSTAlgorithms(printer, graph, lblLog, pbDataStructures, this);
            algVis.SleepInterval = tbSpeedVis.Value * 500;
            try
            {
                if(rbPrim.Checked) algVis.PrimsAlgorithmVisAsync(Color.Red);
                else if(rbKruskal.Checked) algVis.KrusculAlgorithmVisAsync();
                else if(rbBoruvka.Checked) algVis.BoruvkaAlgorithmVisAsync();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void rbPrim_CheckedChanged(object sender, EventArgs e)
        {
            lblDescription.Text = descrPrim;
        }

        private void rbKruskal_CheckedChanged(object sender, EventArgs e)
        {
            lblDescription.Text = descrKruskal;
        }

        private void rbBoruvka_CheckedChanged(object sender, EventArgs e)
        {
            lblDescription.Text = descrBoruvka;
        }

        private void lblLog_SizeChanged(object sender, EventArgs e)
        {
            if (lblLog.Height > pnlLog.Height && rbLog.Checked)
            {
                int value = Min(pnlLog.VerticalScroll.Value + lblLog.Height - pnlLog.Height, 
                    pnlLog.VerticalScroll.Maximum);
                pnlLog.VerticalScroll.Value = value;
            }
        }

        private void rbLog_CheckedChanged(object sender, EventArgs e)
        {
            lblLog.Visible = true;
            pbDataStructures.Visible = false;
        }

        private void rbDataStructures_CheckedChanged(object sender, EventArgs e)
        {
            lblLog.Visible = false;
            pbDataStructures.Visible = true;
        }

        int Min(int a, int b)
        {
            if (a < b) return a;
            return b;
        }
        #endregion  Visualisator
    }
}

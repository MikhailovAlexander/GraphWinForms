using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphWinForms
{
    public class Graph<T> : ICloneable
    {
        private VerticesSetList<T> vertices;
        private List<Edge<T>> edges;
        public IReadOnlyList<Vertex<T>> Vertices => vertices.GetVerticesList();
        public IReadOnlyList<Edge<T>> Edges => edges;
        public int Order => Vertices.Count; 
        public int EdgesCount => edges.Count;
        public int TotalWeight => GetTotalWeight();
        public bool IsEmpty => Order == 0;
        public bool IsConnected => CheckConnection();
        public List<Vertex<T>> VerticesClone => vertices.GetVerticesClone();
        public List<Edge<T>> EdgesClone => GetEdgesClone();

        public Graph()
        {
            vertices = new VerticesSetList<T>();
            edges = new List<Edge<T>>();
        }

        public Graph(List<Vertex<T>> vertices, List<Edge<T>> edges)
        {
            this.vertices = new VerticesSetList<T>();
            foreach (Vertex<T> vertex in vertices)
                this.vertices.Add(vertex);
            this.edges = new List<Edge<T>>();
            foreach (var edge in edges)
                this.AddEdge(edge);
        }
        
        public Graph(List<Vertex<T>> vertices)
        {
            this.vertices = new VerticesSetList<T>();
            foreach (Vertex<T> vertex in vertices)
                this.vertices.Add(vertex);
            edges = new List<Edge<T>>();
        }

        public Graph(params Vertex<T>[] vertices)
        {
            this.vertices = new VerticesSetList<T>();
            foreach (Vertex<T> vertex in vertices)
                this.vertices.Add(vertex); 
            edges = new List<Edge<T>>();
        }

        public void AddEdge(Vertex<T> vertex1, Vertex<T> vertex2)
        {
            if (vertices.Contains(vertex1) && vertices.Contains(vertex2))
                edges.Add(new Edge<T>(vertex1, vertex2));
            else throw new Exception("Одна или обе вершины не входят в граф");
        }

        public void AddEdge(Vertex<T> vertex1, Vertex<T> vertex2, int weight)
        {
            if (vertices.Contains(vertex1) && vertices.Contains(vertex2))
                edges.Add(new Edge<T>(vertex1, vertex2, weight));
            else throw new Exception("Одна или обе вершины не входят в граф");
        }

        public void AddEdge(int v1Index, int v2Index)
        {
            if (v1Index < 0 || v1Index > Order - 1)
                throw new IndexOutOfRangeException(nameof(v1Index));
            if (v2Index < 0 || v2Index > Order - 1)
                throw new IndexOutOfRangeException(nameof(v2Index));
            edges.Add(new Edge<T>(vertices[v1Index], vertices[v2Index]));
        }

        public void AddEdge(int v1Index, int v2Index, int weight)
        {
            if (v1Index < 0 || v1Index > Order - 1)
                throw new IndexOutOfRangeException(nameof(v1Index));
            if (v2Index < 0 || v2Index > Order - 1)
                throw new IndexOutOfRangeException(nameof(v2Index));
            edges.Add(new Edge<T>(vertices[v1Index], vertices[v2Index], weight));
        }

        public void AddEdge(Edge<T> edge)
        {
            if (edge.V1Id < 0 || edge.V1Id > Order - 1)
                throw new IndexOutOfRangeException(nameof(edge.V1Id));
            if (edge.V2Id < 0 || edge.V2Id > Order - 1)
                throw new IndexOutOfRangeException(nameof(edge.V2Id));
            edges.Add(new Edge<T>(vertices[edge.V1Id], vertices[edge.V2Id], edge.Weight));
        }

        public void RemoveEdge(Edge<T> edge)
        {
            edges.Remove(edge);
        }

        public void AddVertex(Vertex<T> vertex)
        {
            vertices.Add(vertex);
        }

        public void RemoveVertex(Vertex<T> vertex)
        {
            for (int i = EdgesCount - 1; i >= 0; i--)//Обход с конца, чтобы удаление элемента не меняло индекс еще не просмотренных вершин
                if (edges[i].IsIncident(vertex)) edges.RemoveAt(i);
            vertices.Remove(vertex);
        }
        
        public bool[,] GetAdjacencyMatrix()
        {
            bool[,] adjacencyMatrix = new bool[Order, Order];
            foreach (var edge in edges)
            {
                adjacencyMatrix[edge.V1Id, edge.V2Id] = true;
                adjacencyMatrix[edge.V2Id, edge.V1Id] = true;
            }
            return adjacencyMatrix;
        }

        public int[,] GetAdjWeightMatrix()
        {
            int order = Order;
            int[,] adjacencyMatrix = new int[order, order];
            for (int i = 0; i < order; i++)
                for (int j = 0; j < order; j++)
                    adjacencyMatrix[i, j] = -1;
            foreach (var edge in edges)
            {
                adjacencyMatrix[edge.V1Id, edge.V2Id] = edge.Weight;
                adjacencyMatrix[edge.V2Id, edge.V1Id] = edge.Weight;
            }
            return adjacencyMatrix;
        }

        public object Clone()
        {
            var clone = new Graph<T>(VerticesClone);
            foreach (var edge in edges)
                clone.AddEdge(edge.V1Id, edge.V2Id, edge.Weight);
            return clone;

        }

        private string EdgesToString()
        {
            StringBuilder builder = new StringBuilder("Список ребер:\n");
            foreach (Edge<T> edge in Edges) builder.AppendLine(edge.ToString());
            return builder.ToString();
        }

        private string VerticesToString()
        {
            StringBuilder builder = new StringBuilder("Список вершин:\n");
            foreach (Vertex<T> vertex in Vertices) builder.AppendFormat("{0}, ", vertex.ToString());
            return builder.ToString();
        }

        public void Show()
        {
            Console.WriteLine(EdgesToString() + VerticesToString());
        }

        public override string ToString()
        {
            return EdgesToString() + VerticesToString();
        }

        public bool IsConnectedVertices(int v1Index, int v2Index)
        {
            foreach (Edge<T> edge in edges)
                if (edge.IsIncident(v1Index) && edge.IsIncident(v2Index))
                    return true;
            return false;
        }

        private bool CheckConnection()
        {
            if (EdgesCount < Order - 1) return false;
            if (Order == 1) return true; 
            bool[] isConnect = new bool[Order];
            isConnect[edges[0].V1Id] = true;
            isConnect[edges[0].V2Id] = true;
            bool hasEdgesToConnect = true;
            while (hasEdgesToConnect)
            {
                hasEdgesToConnect = false;
                foreach (Edge<T> edge in edges)
                {
                    if (isConnect[edge.V1Id] != isConnect[edge.V2Id])
                    {
                        isConnect[edge.V1Id] = true;
                        isConnect[edge.V2Id] = true;
                        hasEdgesToConnect = true;
                    }
                }
            }
            return Array.TrueForAll(isConnect, x => x == true);
        }
        
        private int GetTotalWeight()
        {
            return (from edge in edges select edge.Weight).Sum();
        }
                
        private List<Edge<T>> GetEdgesClone()
        {
            List <Edge<T>> clones = new List<Edge<T>>();
            foreach (var edge in edges)
                clones.Add((Edge<T>)edge.Clone());
            return clones;
        }
    }
}

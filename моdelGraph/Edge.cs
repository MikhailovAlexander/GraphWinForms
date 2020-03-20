using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphWinForms
{
    public class Edge<T>:IComparable, ICloneable
    {
        private readonly Vertex<T> vertex1;
        private readonly Vertex<T> vertex2;
        public int Id { get; private set; }
        public int Weight { get; set; }
        public int V1Id => vertex1.Id;
        public int V2Id => vertex2.Id;
        public T Data1 => vertex1.Data;
        public T Data2 => vertex2.Data;
        public bool IsLoop => vertex1.Equals(vertex2);

        public Edge(Vertex<T> vertex1, Vertex<T> vertex2)
        {
            this.vertex1 = vertex1;
            this.vertex2 = vertex2;
            Weight = 0;
        }

        public Edge(Vertex<T> vertex1, Vertex<T> vertex2, int weight)
        {
            this.vertex1 = vertex1;
            this.vertex2 = vertex2;
            Weight = weight;
        }

        public Edge<T> Reverse()
        {
            return new Edge<T>(vertex2, vertex1, Weight);
        }

        public bool IsIncident(Vertex<T> vertex)
        {
            return vertex1.Equals(vertex)|| vertex2.Equals(vertex);
        }

        public bool IsIncident(int vertexID)
        {
            return vertex1.Id == vertexID || vertex2.Id == vertexID;
        }

        public int CompareTo(object obj)
        {
            if (!(obj is Edge<T> edge2Compare)) throw new Exception("Сравнение возможно только с экземплром Edge");
            return Weight.CompareTo(edge2Compare.Weight);
        }

        public override string ToString()
        {
            return $"{vertex1}<{Weight}>{vertex2}";
        }

        public object Clone()
        {
            return new Edge<T>(this.vertex1, this.vertex2, this.Weight);
        }
    }
}

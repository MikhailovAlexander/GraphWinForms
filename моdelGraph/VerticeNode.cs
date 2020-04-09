using System;

namespace GraphWinForms
{
    public class VerticeNode<T> where T : ICloneable
    {
        public Vertex<T> Vertex { get;}
        public VerticeNode<T> Next { get; set; }
        public int V_ID => Vertex.Id;


        public VerticeNode(Vertex<T> vertex)
        {
            this.Vertex = vertex;
            Next = null;
        }

        public VerticeNode(Vertex<T> vertex, VerticeNode<T> next)
        {
            this.Vertex = vertex;
            Next = next;
        }

        public bool Contains(Vertex<T> vertex2check)
        {
            return this.Vertex.Equals(vertex2check);
        }

        public void SetVertexID(int id)
        {
            Vertex.Id = id;
        }

        public override string ToString()
        {
            if (Next == null) return Vertex.ToString() + "=>x";
            return Vertex.ToString() + "=>" + Next.Vertex.ToString();
        }
    }
}

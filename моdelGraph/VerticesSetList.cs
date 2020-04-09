using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphWinForms
{
    public class VerticesSetList<T> where T : ICloneable
    {
        private VerticeNode<T> head;
        public bool IsEmpty => head == null;
        public int Count => Length();

        public VerticesSetList()
        {
            head = null;
        }

        public Vertex<T> this [int index]
        {
            get { return GetVertex(index); }
        }

        public void Add(Vertex<T> vertex2Add)
        {
            if (vertex2Add == null) throw new ArgumentNullException(nameof(vertex2Add));
            if (IsEmpty)
            {
                head = new VerticeNode<T>(vertex2Add);
                head.SetVertexID(0);
                return;
            }
            var currentNode = head;
            while (!currentNode.Contains(vertex2Add) && currentNode.Next != null)
                currentNode = currentNode.Next;
            if (currentNode.Contains(vertex2Add))
                    throw new Exception("Вершина уже содержится в списке");
            currentNode.Next = new VerticeNode<T>(vertex2Add);
            currentNode.Next.SetVertexID(currentNode.V_ID + 1);
        }

        public void Remove(Vertex<T> vertex2Remove)
        {
            if (vertex2Remove == null) throw new ArgumentNullException(nameof(vertex2Remove));
            if (IsEmpty) throw new Exception("Список пуст");
            var currentNode = head;
            if (head.Contains(vertex2Remove))
            {
                head = head.Next;
                head.SetVertexID(0);
            }
            else
            {
                while (currentNode.Next != null && !currentNode.Next.Contains(vertex2Remove))
                    currentNode = currentNode.Next;
                if (currentNode.Next == null) throw new Exception("Вершина не содержится в списке");
                currentNode.Next = currentNode.Next.Next;
            }
            while (currentNode.Next != null)
            {
                currentNode.Next.SetVertexID(currentNode.V_ID + 1);
                currentNode = currentNode.Next;
            }
        }

        public bool Contains(Vertex<T> vertex2check)
        {
            if (IsEmpty) return false;
            if (head.Contains(vertex2check)) return true;
            var currentNode = head;
            while (currentNode.Next != null)
            {
                if (currentNode.Next.Contains(vertex2check)) return true;
                currentNode = currentNode.Next;
            }
            return false;
        }

        public int IndexOf(Vertex<T> vertex2check)
        {
            if (IsEmpty) return -1;
            var currentNode = head;
            while (currentNode.Next != null)
            {
                if (currentNode.Contains(vertex2check)) break;
                currentNode = currentNode.Next;
            }
            return currentNode.V_ID;
        }

        private int Length()
        {
            if (IsEmpty) return 0;
            var currentNode = head;
            while (currentNode.Next != null)
                currentNode = currentNode.Next;
            return currentNode.V_ID;
        }

        private Vertex<T> GetVertex(int index)
        {
            if (index < 0) throw new IndexOutOfRangeException();
            if (IsEmpty) throw new Exception("Список пуст");
            if (index == 0) return head.Vertex;
            var currentNode = head;
            while (currentNode.Next != null)
            {
                if (currentNode.Next.V_ID == index)
                    return currentNode.Next.Vertex;
                currentNode = currentNode.Next;
            }
            throw new IndexOutOfRangeException();
        }

        public List<Vertex<T>> GetVerticesList()
        {
            List<Vertex<T>> list = new List<Vertex<T>>();
            if (IsEmpty) return list;
            list.Add(head.Vertex);
            var currentNode = head;
            while (currentNode.Next != null)
            {
                list.Add(currentNode.Next.Vertex);
                currentNode = currentNode.Next;
            }
            return list;
        }

        public List<Vertex<T>> GetVerticesClone()
        {
            List<Vertex<T>> clones = new List<Vertex<T>>();
            if (IsEmpty) return clones;
            clones.Add((Vertex<T>)head.Vertex.Clone());
            var currentNode = head;
            while (currentNode.Next != null)
            {
                clones.Add((Vertex<T>)currentNode.Next.Vertex.Clone());
                currentNode = currentNode.Next;
            }
            return clones;
        }
    }
}

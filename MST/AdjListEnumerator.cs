using System.Collections;

namespace GraphWinForms
{
    public class AdjListEnumerator : IEnumerator
    {
        private AdjVertexSortedList list;
        private int position;
        private AdjacencyVertexNode currentNode;
        public Edge<VisVertex> Current
        {
            get
            {
                if (position == 0) return list.Head.Edge;
                return currentNode.Edge;
            }
        }

        public AdjListEnumerator(AdjVertexSortedList list)
        {
            this.list = list;
            currentNode = list.Head;
            position = -1;
        }


        object IEnumerator.Current => Current;

        public void Dispose()
        {
            list = null;
            currentNode = null;
        }

        public bool MoveNext()
        {
            if (list.IsEmpty) return false;
            if (position == -1)
            {
                position++;
                return true;
            }
            if (currentNode.HasNext)
            {
                currentNode = currentNode.Next;
                position++;
                return true;
            }
            Reset();
            return false;
        }

        public void Reset()
        {
            currentNode = list.Head;
            position = -1;
        }
    }
}

using System;

namespace GraphWinForms
{
    public class DisjointSet: IDisjointSetDataStructure, IValiableDSU
    {
        protected int[] parent;
        protected int[] rank;
        public int Count => parent.Length;
        public bool IsEmpty => parent.Length == 0;

        public DisjointSet()
        {
            parent = new int[0];
            rank = new int[0];
        }

        public DisjointSet(int count)
        {
            MakeSet(count);
        }

        public int GetCount()
        {
            return Count;
        }

        public int GetValue(int index)
        {
            if (index < 0 || index >= Count)
                throw new ArgumentOutOfRangeException(
                    "Запрашиваемый индекс вне диапазона множества");
            return parent[index];
        }

        public bool InTheSameSet(int elementA, int elementB)
        {
            return FindRoot(elementA) == FindRoot(elementB);
        }

        public virtual void MakeSet(int count)
        {
            parent = new int[count];
            rank = new int[count];
            for(int i = 0; i < parent.Length; i++) parent[i] = i;
        }

        public int FindRoot(int elementNumber)
        {
            if (IsEmpty) throw new Exception("Система множеств пуста");
            if (parent[elementNumber] == elementNumber) return elementNumber;
            else
            {
                int root = FindRoot(parent[elementNumber]);
                //Если элемент не корневой, продолжаем рекурсивный поиск корня
                parent[elementNumber] = root;
                //на обратном ходу рекурсии обновляем информацию о предке - PathCompression
                return root;
            }
            
        }

        public int UnionSetsReturnsRoot(int elementA, int elementB)
        {
            if (IsEmpty) throw new Exception("Система множеств пуста");
            int rootA = FindRoot(elementA);
            int rootB = FindRoot(elementB);
            if (rootA == rootB) return rootA;
            if (rank[elementA] < rank[elementB]) Swap(ref elementA, ref elementB);
            parent[rootB] = rootA;
            if (rank[elementA] == rank[elementB]) rank[elementA]++;
            return rootA;//Возвращаем новый корень
        }

        public void UnionSets(int elementA, int elementB)
        {
            UnionSetsReturnsRoot(elementA, elementB);
        }

        protected void Swap(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = a;
        }
    }
}

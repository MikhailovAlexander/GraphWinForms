namespace GraphWinForms
{
    public class DisjointSetB: DisjointSet
    {
        private int[] index;

        public DisjointSetB():base()
        {
            index = new int[0];
        }

        public DisjointSetB(int count) : base(count) {}

        public override void MakeSet(int count)
        {
            parent = new int[count];
            rank = new int[count];
            index = new int[count];
            for (int i = 0; i < parent.Length; i++)
            {
                parent[i] = i;
                index[i] = i;
            }
        }

        public int GetIndex(int elementNumber)
        {
            int root = FindRoot(elementNumber);
            return index[root];
        }

        public void UnionSets(int elementA, int elementB, int newIndex)
        {
            int newRoot = UnionSetsReturnsRoot(elementA, elementB);
            index[newRoot] = newIndex;
        }
    }
}

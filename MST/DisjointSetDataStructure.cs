namespace GraphWinForms
{
    public interface IDisjointSetDataStructure
    {
        void MakeSet(int count);
        int FindRoot(int elementNumber);
        void UnionSets(int set1ElNumber, int set2ElNumber);
    }
}

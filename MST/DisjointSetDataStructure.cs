using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphWinForms
{
    public interface IDisjointSetDataStructure
    {
        void MakeSet(int count);
        int FindRoot(int elementNumber);
        void UnionSets(int set1ElNumber, int set2ElNumber);
    }
}

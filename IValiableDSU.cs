using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphWinForms
{
    public interface IValiableDSU:IDisjointSetDataStructure
    {
        int GetCount();
        int GetValue(int index);
    }
}

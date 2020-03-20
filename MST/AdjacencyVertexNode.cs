using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphWinForms
{
    public class AdjacencyVertexNode
    {
        public Edge<VisVertex> Edge { get; private set; }
        public int AdjVertexID => this.Edge.V2Id;
        public int Weight => this.Edge.Weight;
        public AdjacencyVertexNode Previous { get; set; }
        public AdjacencyVertexNode Next { get; set; }
        public bool HasNext => Next != null;

        public AdjacencyVertexNode(Edge<VisVertex> edge)
        {
            this.Edge = edge;
            Previous = null;
            Next = null;
        }
        public AdjacencyVertexNode(Edge<VisVertex> edge, AdjacencyVertexNode next)
        {
            this.Edge = edge;
            Previous = null;
            Next = next;
        }
        public AdjacencyVertexNode(Edge<VisVertex> edge, AdjacencyVertexNode previous, AdjacencyVertexNode next)
        {
            this.Edge = edge;
            Previous = previous;
            Next = next;
        }

        public static bool operator > (AdjacencyVertexNode avn1, AdjacencyVertexNode avn2)
        {
            return avn1.Weight > avn2.Weight;
        }

        public static bool operator < (AdjacencyVertexNode avn1, AdjacencyVertexNode avn2)
        {
            return avn1.Weight < avn2.Weight;
        }

        public static bool operator >= (AdjacencyVertexNode avn1, AdjacencyVertexNode avn2)
        {
            return avn1.Weight >= avn2.Weight;
        }

        public static bool operator <= (AdjacencyVertexNode avn1, AdjacencyVertexNode avn2)
        {
            return avn1.Weight <= avn2.Weight;
        }

        public static bool operator > (Edge<VisVertex> edge, AdjacencyVertexNode avn)
        {
            return edge.Weight > avn.Weight;
        }

        public static bool operator < (Edge<VisVertex> edge, AdjacencyVertexNode avn)
        {
            return edge.Weight < avn.Weight;
        }

        public static bool operator >= (Edge<VisVertex> edge, AdjacencyVertexNode avn)
        {
            return edge.Weight >= avn.Weight;
        }

        public static bool operator <= (Edge<VisVertex> edge, AdjacencyVertexNode avn)
        {
            return edge.Weight <= avn.Weight;
        }
    }
}

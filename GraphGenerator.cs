using System;
using System.Drawing;
using static GraphWinForms.Geometry;

namespace GraphWinForms
{
    public class GraphGenerator
    {
        private Random rnd;
        private Graph<VisVertex> graph;
        private int margine = 10;

        public GraphGenerator()
        {
            rnd = new Random();
            graph = new Graph<VisVertex>();
        }

        public Graph<VisVertex> GetGraph(
            int order, int width, int height, int percentProbability, bool wihoutLoops)
        {
            NewGraphWitnOrder(order, width, height);
            SetRandomEdges(percentProbability, wihoutLoops);
            return (Graph<VisVertex>)graph.Clone();
        }

        public Graph<VisVertex> GetGraphWeight(int order, int width, int height, 
            int percentProbability, int maxWeight, bool wihoutLoops, bool diffWeight) 
        {
            NewGraphWitnOrder(order, width, height);
            SetRandomWeightEdges(percentProbability, maxWeight, wihoutLoops, diffWeight);
            return (Graph<VisVertex>)graph.Clone();
        }

        private void NewGraphWitnOrder(int order, int width, int height)
        {
            if (order < 0) throw new Exception("Порядок графа не может быть отрицательным");
            graph = new Graph<VisVertex>();
            for (int i = 0; i < order; i++)
            {
                Point point = new Point(rnd.Next(margine, width), rnd.Next(margine, height));
                while (!CheckVertexPoint(point))
                    point = new Point(rnd.Next(margine, width), rnd.Next(margine, height));
                var visVertex = new VisVertex(
                    i.ToString(), point);
                graph.AddVertex(new Vertex<VisVertex>(i, visVertex));
            }
        }

        private bool CheckVertexPoint(Point point)
        {
            foreach (var vertex in graph.Vertices)
                if (GetDistanse(vertex.Data.GetPoint, point) < 20) return false;
            return true;
        }

        private void SetRandomEdges(int percentProbability, bool withoutLoops)
        {
            if (percentProbability < 0)
                throw new Exception("Процент вероятности не может быть отрицательным");
            if (percentProbability > 100)
                throw new Exception("Процент вероятности не может быть больше 100");
            for (int i = 0; i < graph.Order; i++)
                for (int j = 0; j < graph.Order; j++)
                {
                    if (i == j && withoutLoops) continue;
                    if (rnd.Next(percentProbability - 100, percentProbability) > 0)
                        graph.AddEdge(graph.Vertices[i], graph.Vertices[j]);
                }
        }

        private void SetRandomWeightEdges(
            int percentProbability, int maxWeight, bool withoutLoops, bool diffWeight)
        {
            if (percentProbability < 0)
                throw new Exception("Процент вероятности не может быть отрицательным");
            if (percentProbability > 100)
                throw new Exception("Процент вероятности не может быть больше 100");
            int uniqueWeight = 1;
            for (int i = 0; i < graph.Order; i++)
                for (int j = 0; j < graph.Order; j++)
                {
                    if (i == j && withoutLoops) continue;
                    if (rnd.Next(percentProbability - 100, percentProbability) > 0)
                    {
                        int weight = rnd.Next(1, maxWeight);
                        if (diffWeight) weight = uniqueWeight++;
                        graph.AddEdge(graph.Vertices[i], graph.Vertices[j], weight);
                    }
                }
        }
    }
}

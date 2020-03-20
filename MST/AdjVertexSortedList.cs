using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphWinForms
{
    public class AdjVertexSortedList:IEnumerable
    {
        private AdjacencyVertexNode head;
        public bool IsEmpty => head == null;
        public Edge<VisVertex> MaxWeightEdge => MaxWeightNode.Edge;
        public Edge<VisVertex> MinWeightEdge => MinWeightNode.Edge;
        public AdjacencyVertexNode Head => head;
        public int Lenght => GetLenght();

        public AdjVertexSortedList()
        {
            head = null;
        }

        public void Add(Edge<VisVertex> edge)
        {
            if (IsEmpty)
            {
                head = new AdjacencyVertexNode(edge);
                head.Previous = head;
                return;
            }
            if(edge <= head)
            {
                head = new AdjacencyVertexNode(edge, head.Previous, head);//При добавлении элемента в начало, сохраняем в начале указаьельна конец
                head.Next.Previous = head;//Обновляем информацию о предшественнике у сдвинутого элемента
                return;
            }
            var currentNode = head;
            while (currentNode.Next != null && edge > currentNode.Next) currentNode = currentNode.Next;
            currentNode.Next = new AdjacencyVertexNode(edge, currentNode, currentNode.Next);
            if (currentNode.Next.Next == null) head.Previous = currentNode.Next;//Если добавили в конец, обновляем информацию о конце в Head
            else currentNode.Next.Next.Previous = currentNode.Next;//Если добавили не в конец, обновляем информацию о предшественнике в элементе перед которым вставили
        }

        public Edge<VisVertex> ExtractMinWeightEdge()
        {
            if (IsEmpty) throw new Exception("Список пуст");
            Edge<VisVertex> edge = head.Edge;
            if (head.Previous == head) head = null;
            else
            {
                var tmp = head.Previous;
                head = head.Next;
                head.Previous = tmp;
            }
            return edge;
        }

        public Edge<VisVertex> ExtractMaxWeightEdge()
        {
            if (IsEmpty) throw new Exception("Список пуст");
            Edge<VisVertex> edge = head.Previous.Edge;
            if (head.Previous == head) head = null;
            else
            {
                head.Previous.Previous.Next = null;
                head.Previous = head.Previous.Previous;
            }
            return edge;
        }

        private AdjacencyVertexNode MaxWeightNode
        {
            get
            {
                if (IsEmpty) throw new Exception("Список пуст");
                return head.Previous;
            }
        }

        private AdjacencyVertexNode MinWeightNode
        {
            get
            {
                if (IsEmpty) throw new Exception("Список пуст");
                return head;
            }
        }

        public AdjVertexSortedList Union(AdjVertexSortedList list2Union, bool[] isIncluded)
        {
            var unionList = new AdjVertexSortedList();
            while (!this.IsEmpty && !list2Union.IsEmpty)
            {
                if (isIncluded[this.MaxWeightNode.AdjVertexID]) this.ExtractMaxWeightEdge();//Удаляем из текущего списка ребра, у которых обе вершины входят в текущую компоненту связности
                else if  (isIncluded[list2Union.MaxWeightNode.AdjVertexID]) list2Union.ExtractMaxWeightEdge();//Удаляем из списка для объединения ребра, у которых обе вершины входят в текущую компоненту связности
                else if (this.MaxWeightNode > list2Union.MaxWeightNode)
                    unionList.Add(this.ExtractMaxWeightEdge());
                else unionList.Add(list2Union.ExtractMaxWeightEdge());
            }
            while (!this.IsEmpty)
            {
                if (isIncluded[this.MaxWeightNode.AdjVertexID]) this.ExtractMaxWeightEdge();
                else unionList.Add(this.ExtractMaxWeightEdge());
            }
            while (!list2Union.IsEmpty)
            {
                if (isIncluded[list2Union.MaxWeightNode.AdjVertexID]) list2Union.ExtractMaxWeightEdge();
                else unionList.Add(list2Union.ExtractMaxWeightEdge());
            }
            return unionList;
        }

        public AdjVertexSortedList Union(AdjVertexSortedList list2Union, DisjointSet dsu)
        {
            var unionList = new AdjVertexSortedList();
            while (!this.IsEmpty && !list2Union.IsEmpty)
            {
                if (dsu.InTheSameSet(this.MaxWeightEdge.V1Id, this.MaxWeightEdge.V2Id))
                    this.ExtractMaxWeightEdge();//Удаляем из текущего списка ребра, у которых обе вершины входят в одну компоненту связности
                else if (dsu.InTheSameSet(list2Union.MaxWeightEdge.V1Id, list2Union.MaxWeightEdge.V2Id))
                    list2Union.ExtractMaxWeightEdge();//Удаляем из списка для объединения ребра, у которых обе вершины входят в одну компоненту связности
                else if (this.MaxWeightNode > list2Union.MaxWeightNode)
                    unionList.Add(this.ExtractMaxWeightEdge());
                else unionList.Add(list2Union.ExtractMaxWeightEdge());
            }
            while (!this.IsEmpty)
            {
                if (dsu.InTheSameSet(this.MaxWeightEdge.V1Id, this.MaxWeightEdge.V2Id))
                    this.ExtractMaxWeightEdge();
                else unionList.Add(this.ExtractMaxWeightEdge());
            }
            while (!list2Union.IsEmpty)
            {
                if (dsu.InTheSameSet(list2Union.MaxWeightEdge.V1Id, list2Union.MaxWeightEdge.V2Id))
                    list2Union.ExtractMaxWeightEdge();
                else unionList.Add(list2Union.ExtractMaxWeightEdge());
            }
            return unionList;
        }

        public static AdjVertexSortedList[] GetAdjLists(Graph<VisVertex> graph)
        {
            var lists = new AdjVertexSortedList[graph.Order];//Создаем массив списков смежности 
            for (int i = 0; i < graph.Order; i++)//Создаем списки смежности для каждой вершины графа
                lists[i] = new AdjVertexSortedList();
            foreach (Edge<VisVertex> edge in graph.Edges)//Распределяем ребра по спискам
            {
                if (edge.V1Id == edge.V2Id) continue;//Пропускаем петли
                lists[edge.V1Id].Add(edge);//Добавляем ребро в список первой вершины
                lists[edge.V2Id].Add(edge.Reverse());//Добавляем ребро в список второй вершины (переворачиваем ребро, т.к. для второй вешины смежняая будет первая)
            }
            return lists;
        }

        public static string [][] GetStringAdjLists(Graph<VisVertex> graph)
        {
            var lists = GetAdjLists(graph);
            string[][] strLists = new string[lists.Length][];
            for (int i = 0; i < lists.Length; i++)
            {
                strLists[i] = new string[lists[i].Lenght];
                int j = 0;
                foreach (Edge<VisVertex> edge in lists[i])
                    strLists[i][j++] = edge.ToString();
            }
            return strLists;
        }

        public IEnumerator GetEnumerator()
        {
            return new AdjListEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new AdjListEnumerator(this);
        }

        private int GetLenght()
        {
            int counter = 0;
            if (this.IsEmpty) return counter;
            foreach (var edge in this) counter++;
            return counter;
        }
    }
}
 
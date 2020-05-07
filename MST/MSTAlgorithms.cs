using System;
using System.Collections.Generic;

namespace GraphWinForms
{
    public class MSTAlgorithms
    {
        protected Random rnd;
        public static Graph<VisVertex> GetMST_Boruvka(Graph<VisVertex> graph)
        {
            int order = graph.Order;
            Graph<VisVertex> mst = new Graph<VisVertex>(graph.VerticesClone);
            //Создаем МОД с вершинами графа
            DisjointSetB dsu = new DisjointSetB(order);
            //Создаем DSU_B для поиска компонеты, включающей элемент и хранения нового адреса списка
            var asl = GetAdjLists(graph);
            //Создаем массив сортированных списков смежности для вершин графа
            bool[] isUsed;
            //Отмечаем в массиве элементы использованные на текущей итерации
            int currentIndex = 0;
            //Индекс для помещения объединенного списка смежности в начало массива
            bool HasEdge2Add = true;
            //Переменная для выхода из цикла при отсутствии ребер для добавления в МОД
            while (mst.EdgesCount < order - 1 && HasEdge2Add)
            {
                isUsed = new bool[order];
                //Для каждой итерации отмечаем все компоненты, как неиспользованные
                HasEdge2Add = false;
                //Обновляем флаг для проверки наличия ребер
                currentIndex = 0;
                //Обновляем индекс для помещения объединенных списков в начало массива
                for (int i = 0; i < order && asl[i] != null; i++)//Для каждой компоненты связности
                {
                    if (asl[i].IsEmpty || isUsed[i]) continue;
                    int listAddress2 = dsu.GetIndex(asl[i].MinWeightEdge.V2Id);
                    HasEdge2Add = true;
                    isUsed[i] = true;//Отмечаем компонету, как использованную
                    Edge<VisVertex> edge2Add = asl[i].ExtractMinWeightEdge();
                    //Извлекаем минимальное ребро текущей компоненты
                    mst.AddEdge(edge2Add);//Добавляем извлеченное ребро в МОД                     
                    if (isUsed[listAddress2])
                        //Если компонента с которой планируется объединение уже 
                        //была объединена на этой итерации
                    {
                        dsu.UnionSets(edge2Add.V1Id, edge2Add.V2Id, listAddress2);
                        //Объединяем текущую компонету и присоединенную извлеченным ребром
                        asl[listAddress2] = asl[i].Union(asl[listAddress2], dsu);
                        //Объединяем сортированные списки смежности объединенных компонент
                        continue;
                    }
                    dsu.UnionSets(edge2Add.V1Id, edge2Add.V2Id, currentIndex);
                    //Объединяем текущую компонету и присоединенную извлеченным ребром
                    asl[currentIndex++] = asl[i].Union(asl[listAddress2], dsu);
                    //Объединяем сортированные списки смежности объединенных компонент
                    //Объединенный список помещаем в начало массива, за последним объединенным, 
                    //отмечаем элементы как использованные,указываем индекс объединенного списка
                }
                if (currentIndex < order) asl[currentIndex] = null;
                //После последнего объединенного списка вставляем null,
                //чтобы на следующей итерации не проходить дальше
            }
            if (mst.EdgesCount < order - 1) throw new Exception("Ошибка МОД не найдено");
            return mst;
        }

        public static Graph<VisVertex> GetMST_KrusculDSU(Graph<VisVertex> graph)
        {
            Edge<VisVertex>[] sortedEdges = GetSortedEdges(graph.EdgesClone);
            Graph<VisVertex> mst = new Graph<VisVertex>(graph.VerticesClone);//Создаем МОД
            DisjointSet dsu = new DisjointSet(graph.Order);
            foreach (Edge<VisVertex> edge in sortedEdges)
            {
                if (mst.EdgesCount == graph.Order - 1) break;//Если МОД построен выходим из цикла
                if (dsu.InTheSameSet(edge.V1Id, edge.V2Id)) continue;
                //Если вершины ребра в одной компоненте пропускаем ребро
                mst.AddEdge(edge);//Добавляем ребро мнимального веса в МОД 
                dsu.UnionSets(edge.V1Id, edge.V2Id);//Объединяем связанные компоненты
            }
            if (mst.EdgesCount != graph.Order - 1) throw new Exception("Ошибка МОД не найдено");
            return mst;
        }

        protected static Edge<VisVertex>[] GetSortedEdges(List<Edge<VisVertex>> edges)
        {
            Edge<VisVertex>[] arrayEdges = edges.ToArray();
            Array.Sort(arrayEdges);
            return arrayEdges;
        }

        public static Graph<VisVertex> GetMST_PrimNaive(Graph<VisVertex> graph)
        {
            Random rnd = new Random();
            bool[] inMST = new bool[graph.Order];
            //Создаем логический массив для проверки вхождения вершин в МОД
            List<Vertex<VisVertex>> verticesMST = graph.VerticesClone;
            //Создаем список вершин МОД
            List<Edge<VisVertex>> edgesMST = new List<Edge<VisVertex>>();
            //Создаем список ребер МОД
            inMST[rnd.Next(0, graph.Order)] = true;
            //Отмечаем произвольную вершину, как включенную в МОД
            bool HasEdge2Add = true;
            int minValue, minIndex;
            while (edgesMST.Count < graph.Order - 1 && HasEdge2Add)
            {
                minValue = int.MaxValue;
                minIndex = -1;
                HasEdge2Add = false;
                //Обновляем проверку наличия ребер для добавления
                for (int i = 0; i < graph.EdgesCount; i++)
                    //Поиска мин ребра для добавления в дерево
                {
                    if (inMST[graph.Edges[i].V1Id] == inMST[graph.Edges[i].V2Id])
                        continue;
                    //Пропускаем ребра, которые не соединяют вершину в дереве с вершиной вне дерева
                    if (graph.Edges[i].Weight < minValue)
                    {
                        HasEdge2Add = true;//Отмечаем, что есть ребра к добавлению
                        minValue = graph.Edges[i].Weight;
                        minIndex = i;
                    }
                }
                if (HasEdge2Add)
                {
                    AddEdge(graph.Edges[minIndex], verticesMST, edgesMST);
                    //Добавляем к ребрам МОД минимальное из найденных кандидатов
                    inMST[graph.Edges[minIndex].V1Id] = true;
                    //Отмечаем обе вершины добавленного ребра, как включенные в МОД
                    inMST[graph.Edges[minIndex].V2Id] = true;
                }
            }
            if (edgesMST.Count != graph.Order - 1) throw new Exception("Ошибка МОД не найдено");
            return new Graph<VisVertex>(verticesMST, edgesMST);
        }

        public static Graph<VisVertex> GetMstPrim(Graph<VisVertex> graph)
        {
            if (!graph.IsConnected) throw new Exception("Граф не связен");
            Random rnd = new Random();
            bool[] inMST = new bool[graph.Order];
            //Создаем логический массив для проверки вхождения вершин в МОД
            List<Vertex<VisVertex>> verticesMST = graph.VerticesClone;
            //Создаем список вершин МОД
            List<Edge<VisVertex>> edgesMST = new List<Edge<VisVertex>>();
            //Создаем список ребер МОД
            var adjVertexSortLists = GetAdjLists(graph);
            //Создаем сортированные списки смежности для вершин графа
            var adjVertexSortListMST = new AdjVertexSortedList();
            //Создаем пустой сортированный список смежности для всего МОД
            int firsrVertex = rnd.Next(0, graph.Order);
            //Выбираем случайную вершину для начала построения МОД
            inMST[firsrVertex] = true;
            //Отмечаем произвольную вершину, как включенную в МОД
            adjVertexSortListMST = adjVertexSortListMST.Union(
                adjVertexSortLists[firsrVertex], inMST);
            //Объединяем список смежности МОД и список смежности выбраной вершины 
            //(при объединении сортировка поддерживается)
            for (int i = 0; i < graph.Order - 1; i++)
                //Цикл для построения МОД, шагов по количеству вершин - 1
            {
                Edge<VisVertex> edge2Add = adjVertexSortListMST.ExtractMinWeightEdge();
                //выбираем из списка смежности МОД ребро минимального веса
                AddEdge(edge2Add, verticesMST, edgesMST);
                //Добавляем ребро мнимального веса в МОД 
                inMST[edge2Add.V2Id] = true;
                //Отмечаем присоединенную вершину, как включенную в МОД 
                adjVertexSortListMST = adjVertexSortListMST.Union(
                    adjVertexSortLists[edge2Add.V2Id], inMST);
                //Объединяем списки смежности МОД и последней добавленной вершины 
                //(при этом ребра внутри МОД удаляются)
            }
            if (edgesMST.Count != graph.Order - 1) throw new Exception("Ошибка МОД не найдено");
            return new Graph<VisVertex>(verticesMST, edgesMST);
        }

        protected static AdjVertexSortedList[] GetAdjLists(Graph<VisVertex> graph)
        {
            var lists = new AdjVertexSortedList[graph.Order];
            //Создаем массив списков смежности 
            for (int i = 0; i < graph.Order; i++)
                //Создаем списки смежности для каждой вершины графа
                lists[i] = new AdjVertexSortedList();
            foreach (Edge<VisVertex> edge in graph.Edges)//Распределяем ребра по спискам
            {
                if (edge.V1Id == edge.V2Id) continue;//Пропускаем петли
                lists[edge.V1Id].Add(edge);//Добавляем ребро в список первой вершины
                lists[edge.V2Id].Add(edge.Reverse());
                //Добавляем ребро в список второй вершины 
                //(переворачиваем ребро, т.к. для второй вешины смежняая будет первая)
            }
            return lists;
        }

        protected static void AddEdge(Edge<VisVertex> edge, List<Vertex<VisVertex>> vertices, 
            List<Edge<VisVertex>> edges)
        {
            edges.Add(new Edge<VisVertex>(vertices[edge.V1Id], vertices[edge.V2Id], edge.Weight));
        }
    }
}

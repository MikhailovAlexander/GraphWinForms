using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphWinForms
{
    public class MSTAlgorithms
    {
        private AlgorithmsVisualisator visualisator;
        private Graph<VisVertex> graph;
        private Random rnd;
        private Color[] colors;
        private Form1 form;
        public int SleepInterval {get;set;}

        public MSTAlgorithms(GraphPrinter printer, Graph<VisVertex> graph, Label lblLog, PictureBox dataStructuresArea, Form1 form)
        {
            this.graph = graph;
            visualisator = new AlgorithmsVisualisator(printer, graph, lblLog, dataStructuresArea);
            SleepInterval = 1000;
            rnd = new Random();
            colors = GetColorsArray(graph.Order);
            this.form = form;
        }

        public async void PrimsAlgorithmVisAsync(Color mstColor)
        {
            if (!graph.IsConnected)
            {
                visualisator.Print("Остовное дерево не может быть построено. Граф не связен!");
                visualisator.ApEndLog("Остовное дерево не может быть построено. Граф не связен!");
                return;
            }
            form.BlockTabControl();
            int mstWeight = 0;
            bool[] inMST = new bool[graph.Order];//Создаем логический массив для проверки вхождения вершин в МОД
            List<Edge<VisVertex>> edgesMST = new List<Edge<VisVertex>>();//Создаем список ребер МОД
            var adjVertexSortLists = GetAdjLists(graph);//Создаем сортированные списки смежности для вершин графа
            var adjVertexSortListMST = new AdjVertexSortedList();//Создаем пустой сортированный список смежности для всего МОД
            int firsrVertex = rnd.Next(0, graph.Order);//Выбираем случайную вершину для начала построения МОД
            inMST[firsrVertex] = true;//Отмечаем произвольную вершину, как включенную в МОД

            visualisator.SetVertexColor(firsrVertex, mstColor);
            visualisator.Print("Начальная вершина выбрана произвольно");
            visualisator.ApEndLog("Произвольный выбор начальной вершины МОД.");
            await Task.Delay(SleepInterval);

            adjVertexSortListMST = adjVertexSortListMST.Union(adjVertexSortLists[firsrVertex], inMST);//Объединяем список смежности МОД и список смежности выбраной вершины (при объединении сортировка поддерживается)
            for (int i = 0; i < graph.Order - 1; i++)//Цикл для построения МОД, шагов по количеству вершин - 1
            {
                Edge<VisVertex> edge2Add = adjVertexSortListMST.ExtractMinWeightEdge();//выбираем из списка смежности МОД ребро минимального веса
                edgesMST.Add(edge2Add); ;//Добавляем ребро мнимального веса в МОД 
                inMST[edge2Add.V2Id] = true;//Отмечаем присоединенную вершину, как включенную в МОД 
                mstWeight += edge2Add.Weight;
                adjVertexSortListMST = adjVertexSortListMST.Union(adjVertexSortLists[edge2Add.V2Id], inMST);//Объединяем списки смежности МОД и последней добавленной вершины (при этом ребра внутри МОД удаляются)

                visualisator.ApEndLog($"Шаг {i + 1}. Выбираем ребро минимального веса, соединяющее вершину внутри и вне МОД -  {edge2Add}");
                visualisator.SetEdgeColor(edge2Add, mstColor);
                visualisator.SetVertexColor(edge2Add.V2Id, mstColor);
                visualisator.Print($"Добавление к МОД смежного ребра минимального веса. Всего ребер {edgesMST.Count}. Общий вес {mstWeight}.");
                visualisator.PrintDataStructuresPrim(adjVertexSortLists, adjVertexSortListMST);
                await Task.Delay(SleepInterval);
            }
            if (edgesMST.Count != graph.Order - 1) throw new Exception("Ошибка МОД не найдено");
            else
            {
                visualisator.Print($"Минимальное остовное дерево построено. Общий вес {mstWeight}.");
                visualisator.ApEndLog($"Минимальное остовное дерево построено. Общий вес {mstWeight}.");
                visualisator.PrintDataStructuresPrim(adjVertexSortLists, adjVertexSortListMST);
            }
            form.UnBlockTabControl();
        }

        public async void KrusculAlgorithmVisAsync()
        {
            if (!graph.IsConnected)
            {
                visualisator.Print("Остовное дерево не может быть построено. Граф не связен!");
                visualisator.ApEndLog("Остовное дерево не может быть построено. Граф не связен!");
                return;
            }
            form.BlockTabControl();
            int order = graph.Order;
            Edge<VisVertex>[] sortedEdges = GetSortedEdges(graph.EdgesClone);
            Graph<VisVertex> mst = new Graph<VisVertex>(graph.VerticesClone);//Создаем МОД
            DisjointSet dsu = new DisjointSet(order);

            SetVerticesDifferentColors();
            visualisator.Print("Маркировка вершин");
            visualisator.ApEndLog(
                "МОД сотоит из отдельных вершин - компонент связности, маркированных различными цветами" +
                "\nПоследовательно простомтрим ребра, отсортированные по неубыванию веса.");
            visualisator.PrintDataStructuresKruskal(sortedEdges, sortedEdges[0], dsu, colors);
            await Task.Delay(SleepInterval);

            foreach (Edge<VisVertex> edge in sortedEdges)
            {
                if (mst.EdgesCount == order - 1) break;//Если МОД построен выходим из цикла
                if (dsu.InTheSameSet(edge.V1Id, edge.V2Id))
                {
                    visualisator.ApEndLog($"Ребро {edge} соединяет вершины из одной компоненты - пропускаем."); visualisator.PrintDataStructuresKruskal(sortedEdges, edge, dsu, colors);
                    await Task.Delay(SleepInterval);
                    continue;//Если вершины ребра в одной компоненте пропускаем ребро
                }
                mst.AddEdge(edge);//Добавляем ребро мнимального веса в МОД 
                dsu.UnionSets(edge.V1Id, edge.V2Id);//Объединяем связанные компоненты

                RefreshColors(dsu,mst);
                visualisator.Print($"Добавление ребра минимального веса. Всего ребер {mst.EdgesCount}. Общий вес {mst.TotalWeight}.");
                visualisator.ApEndLog($"Ребро {edge} соединяет вершины из разных компонент - добавляем в МОД. " +
                    $"Объединяем связанные ребром компоненты.");
                visualisator.PrintDataStructuresKruskal(sortedEdges, edge, dsu, colors);
                await Task.Delay(SleepInterval);
            }
            if (mst.EdgesCount != order - 1) throw new Exception("Ошибка МОД не найдено");
            else
            {
                visualisator.Print($"Минимальное остовное дерево построено. Общий вес {mst.TotalWeight}.");
                visualisator.ApEndLog($"Минимальное остовное дерево построено. Общий вес {mst.TotalWeight}.");
            }
            form.UnBlockTabControl();
        }

        public async void BoruvkaAlgorithmVisAsync()
        {
            if (!graph.IsConnected)
            {
                visualisator.Print("Остовное дерево не может быть построено. Граф не связен!");
                visualisator.ApEndLog("Остовное дерево не может быть построено. Граф не связен!");
                return;
            }
            form.BlockTabControl();
            int order = graph.Order;
            Graph<VisVertex> mst = new Graph<VisVertex>(graph.VerticesClone);//Создаем МОД с вершинами графа
            DisjointSetB dsu = new DisjointSetB(order);//Создаем DSU_B для поиска компонеты, включающей элемент и хранения нового адреса списка
            var asl = GetAdjLists(graph);//Создаем массив сортированных списков смежности для вершин графа
            bool[] isUsed;//Отмечаем в массиве элементы использованные на текущей итерации
            int currentIndex = 0;//Индекс для помещения объединенного списка смежности в начало массива
            bool HasEdge2Add = true;//Переменная для выхода из цикла при отсутствии ребер для добавления в МОД

            int stepCounter = 1;
            int componentCounter = order;
            SetVerticesDifferentColors();
            visualisator.Print("Маркировка вершин");
            visualisator.ApEndLog(
                 "МОД сотоит из отдельных вершин - компонент связности, маркированных различными цветами" +
                 "\nДля каждой компоненты найдем наименьшее по весу ребро, соединяющее ее с другой компонентой.");
            visualisator.PrintDataStructuresBoruvka(asl, dsu, colors);
            await Task.Delay(SleepInterval);

            while (mst.EdgesCount < order - 1 && HasEdge2Add)
            {
                visualisator.ApEndLog($"Шаг {stepCounter++}. Количество компонент связности {componentCounter}.");
                componentCounter = 0;
                isUsed = new bool[order];//Для каждой итерации отмечаем все компоненты, как неиспользованные
                HasEdge2Add = false;//Обновляем флаг для проверки наличия ребер
                currentIndex = 0;//Обновляем индекс для помещения объединенных списков в начало массива
                for (int i = 0; i < order && asl[i] != null; i++)//Для каждой компоненты связности
                {
                    if (asl[i].IsEmpty || isUsed[i])
                    {
                        visualisator.ApEndLog($"    Компонента №{++componentCounter} уже использована.");
                        continue;
                    }
                    int listAddress2 = dsu.GetIndex(asl[i].MinWeightEdge.V2Id);
                    HasEdge2Add = true;
                    isUsed[i] = true;//Отмечаем компонету, как использованную
                    Edge<VisVertex> edge2Add = asl[i].ExtractMinWeightEdge();//Извлекаем минимальное ребро текущей компоненты
                    visualisator.ApEndLog($"    Для компоненты №{++componentCounter} добавляем в МОД ребро {edge2Add}. Объединяем компоненты");
                    mst.AddEdge(edge2Add);//Добавляем извлеченное ребро в МОД                     
                    if (isUsed[listAddress2])//Если компонента с которой планируется объединение уже была объединена на этой итерации
                    {
                        dsu.UnionSets(edge2Add.V1Id, edge2Add.V2Id, listAddress2);//Объединяем текущую компонету и присоединенную извлеченным ребром
                        asl[listAddress2] = asl[i].Union(asl[listAddress2], dsu);//Объединяем сортированные списки смежности объединенных компонент
                        continue;
                    }
                    dsu.UnionSets(edge2Add.V1Id, edge2Add.V2Id, currentIndex);//Объединяем текущую компонету и присоединенную извлеченным ребром
                    asl[currentIndex++] = asl[i].Union(asl[listAddress2], dsu);//Объединяем сортированные списки смежности объединенных компонент
                    //Объединенный список помещаем в начало массива, за последним объединенным, отмечаем элементы как использованные,указываем индекс объединенного списка
                }
                if (currentIndex < order) asl[currentIndex] = null;//После последнего объединенного списка вставляем null,
                                                                   //чтобы на следующей итерации не проходить дальше
                componentCounter = currentIndex + 1;
                RefreshColors(dsu, mst);
                visualisator.Print($"Объединение компонент связности. Всего ребер {mst.EdgesCount}. Общий вес {mst.TotalWeight}.");
                visualisator.PrintDataStructuresBoruvka(asl, dsu, colors);
                await Task.Delay(SleepInterval);
            }
            if (mst.EdgesCount < order - 1) throw new Exception("Ошибка МОД не найдено");
            else
            {
                visualisator.Print($"Минимальное остовное дерево построено. Общий вес {mst.TotalWeight}.");
                visualisator.ApEndLog($"Минимальное остовное дерево построено. Общий вес {mst.TotalWeight}.");
                visualisator.PrintDataStructuresBoruvka(asl, dsu, colors);
            }
            form.UnBlockTabControl();
        }

        private void SetVerticesDifferentColors()
        {
            int index = 0;
            foreach (var vertex in graph.Vertices)
                visualisator.SetVertexColor(vertex, colors[index++]);
        }

        private void RefreshColors(IDisjointSetDataStructure dsu, Graph<VisVertex> mst)
        {
            Color currentColor;
            foreach (var edge in mst.Edges)
            {
                currentColor = colors[dsu.FindRoot(edge.V1Id)];
                visualisator.SetEdgeColor(edge, currentColor);
                visualisator.SetVertexColor(edge.V1Id, currentColor);
                visualisator.SetVertexColor(edge.V2Id, currentColor);
            }
        }

        private Color[] GetColorsArray(int size)
        {
            List<Color> allColors = GetAllColors();
            int listCount = allColors.Count;
            Color[] colors = new Color[size];
            var currentColor = allColors[rnd.Next(0, listCount)];
            for (int i = 0; i < colors.Length; i++)
            {
                currentColor = allColors[rnd.Next(0, listCount)];
                while (colors.Contains(currentColor) && i < listCount - 1)
                    currentColor = allColors[rnd.Next(0, listCount)];
                colors[i] = currentColor;
            }
            return colors;
        }

        private List<Color> GetAllColors()
        {
            List<Color> allColors = new List<Color>();
            foreach (PropertyInfo property in typeof(Color).GetProperties())
                if (property.PropertyType == typeof(Color) && !((Color)property.GetValue(null)).ToString().Contains("White"))
                    allColors.Add((Color)property.GetValue(null));
            Color[] usedColors = new Color[]
            {
                Color.Black,
                Color.White,
                visualisator.VertexColor,
                visualisator.EdgeColor,
                visualisator.areaBackColor
            };
            foreach(Color color in usedColors) allColors.Remove(color);
            return allColors;
        }

        public static Graph<VisVertex> GetMST_Boruvka(Graph<VisVertex> graph)
        {
            int order = graph.Order;
            Graph<VisVertex> mst = new Graph<VisVertex>(graph.VerticesClone);//Создаем МОД с вершинами графа
            DisjointSetB dsu = new DisjointSetB(order);//Создаем DSU_B для поиска компонеты, включающей элемент и хранения нового адреса списка
            var asl = GetAdjLists(graph);//Создаем массив сортированных списков смежности для вершин графа
            bool[] isUsed;//Отмечаем в массиве элементы использованные на текущей итерации
            int currentIndex = 0;//Индекс для помещения объединенного списка смежности в начало массива
            bool HasEdge2Add = true;//Переменная для выхода из цикла при отсутствии ребер для добавления в МОД
            while (mst.EdgesCount < order - 1 && HasEdge2Add)
            {
                isUsed = new bool[order];//Для каждой итерации отмечаем все компоненты, как неиспользованные
                HasEdge2Add = false;//Обновляем флаг для проверки наличия ребер
                currentIndex = 0;//Обновляем индекс для помещения объединенных списков в начало массива
                for (int i = 0; i < order && asl[i] != null; i++)//Для каждой компоненты связности
                {
                    if (asl[i].IsEmpty || isUsed[i]) continue;
                    int listAddress2 = dsu.GetIndex(asl[i].MinWeightEdge.V2Id);
                    HasEdge2Add = true;
                    isUsed[i] = true;//Отмечаем компонету, как использованную
                    Edge<VisVertex> edge2Add = asl[i].ExtractMinWeightEdge();//Извлекаем минимальное ребро текущей компоненты
                    mst.AddEdge(edge2Add);//Добавляем извлеченное ребро в МОД                     
                    if (isUsed[listAddress2])//Если компонента с которой планируется объединение уже была объединена на этой итерации
                    {
                        dsu.UnionSets(edge2Add.V1Id, edge2Add.V2Id, listAddress2);//Объединяем текущую компонету и присоединенную извлеченным ребром
                        asl[listAddress2] = asl[i].Union(asl[listAddress2], dsu);//Объединяем сортированные списки смежности объединенных компонент
                        continue;
                    }
                    dsu.UnionSets(edge2Add.V1Id, edge2Add.V2Id, currentIndex);//Объединяем текущую компонету и присоединенную извлеченным ребром
                    asl[currentIndex++] = asl[i].Union(asl[listAddress2], dsu);//Объединяем сортированные списки смежности объединенных компонент
                    //Объединенный список помещаем в начало массива, за последним объединенным, отмечаем элементы как использованные,указываем индекс объединенного списка
                }
                if (currentIndex < order) asl[currentIndex] = null;//После последнего объединенного списка вставляем null,
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
                if (dsu.InTheSameSet(edge.V1Id, edge.V2Id)) continue;//Если вершины ребра в одной компоненте пропускаем ребро
                mst.AddEdge(edge);//Добавляем ребро мнимального веса в МОД 
                dsu.UnionSets(edge.V1Id, edge.V2Id);//Объединяем связанные компоненты
            }
            if (mst.EdgesCount != graph.Order - 1) throw new Exception("Ошибка МОД не найдено");
            return mst;
        }

        private static Edge<VisVertex>[] GetSortedEdges(List<Edge<VisVertex>> edges)
        {
            Edge<VisVertex>[] arrayEdges = edges.ToArray();
            Array.Sort(arrayEdges);
            return arrayEdges;
        }

        public static Graph<VisVertex> GetMST_PrimNaive(Graph<VisVertex> graph)
        {
            Random rnd = new Random();
            bool[] inMST = new bool[graph.Order];//Создаем логический массив для проверки вхождения вершин в МОД
            List<Vertex<VisVertex>> verticesMST = graph.VerticesClone;//Создаем список вершин МОД
            List<Edge<VisVertex>> edgesMST = new List<Edge<VisVertex>>();//Создаем список ребер МОД
            inMST[rnd.Next(0, graph.Order)] = true;//Отмечаем произвольную вершину, как включенную в МОД
            bool HasEdge2Add = true;
            int minValue, minIndex;
            while (edgesMST.Count < graph.Order - 1 && HasEdge2Add)
            {
                minValue = int.MaxValue;
                minIndex = -1;
                HasEdge2Add = false;//Обновляем проверку наличия ребер для добавления
                for (int i = 0; i < graph.EdgesCount; i++)//Поиска мин ребра для добавления в дерево
                {
                    if (inMST[graph.Edges[i].V1Id] == inMST[graph.Edges[i].V2Id])
                        continue;//Пропускаем ребра, которые не соединяют вершину в дереве с вершиной вне дерева
                    if (graph.Edges[i].Weight < minValue)
                    {
                        HasEdge2Add = true;//Отмечаем, что есть ребра к добавлению
                        minValue = graph.Edges[i].Weight;
                        minIndex = i;
                    }
                }
                if (HasEdge2Add)
                {
                    AddEdge(graph.Edges[minIndex], verticesMST, edgesMST);//Добавляем к ребрам МОД минимальное из найденных кандидатов
                    inMST[graph.Edges[minIndex].V1Id] = true;//Отмечаем обе вершины добавленного ребра, как включенные в МОД
                    inMST[graph.Edges[minIndex].V2Id] = true;
                }
            }
            if (edgesMST.Count != graph.Order - 1) throw new Exception("Ошибка МОД не найдено");
            return new Graph<VisVertex>(verticesMST, edgesMST);
        }

        public static Graph<VisVertex> MyMst(Graph<VisVertex> graph)
        {
            if (!graph.IsConnected) throw new Exception("Граф не связен");
            Random rnd = new Random();
            bool[] inMST = new bool[graph.Order];//Создаем логический массив для проверки вхождения вершин в МОД
            List<Vertex<VisVertex>> verticesMST = graph.VerticesClone;//Создаем список вершин МОД
            List<Edge<VisVertex>> edgesMST = new List<Edge<VisVertex>>();//Создаем список ребер МОД
            var adjVertexSortLists = GetAdjLists(graph);//Создаем сортированные списки смежности для вершин графа
            var adjVertexSortListMST = new AdjVertexSortedList();//Создаем пустой сортированный список смежности для всего МОД
            int firsrVertex = rnd.Next(0, graph.Order);//Выбираем случайную вершину для начала построения МОД
            inMST[firsrVertex] = true;//Отмечаем произвольную вершину, как включенную в МОД
            adjVertexSortListMST = adjVertexSortListMST.Union(adjVertexSortLists[firsrVertex], inMST);//Объединяем список смежности МОД и список смежности выбраной вершины (при объединении сортировка поддерживается)
            for (int i = 0; i < graph.Order - 1; i++)//Цикл для построения МОД, шагов по количеству вершин - 1
            {
                Edge<VisVertex> edge2Add = adjVertexSortListMST.ExtractMinWeightEdge();//выбираем из списка смежности МОД ребро минимального веса
                AddEdge(edge2Add, verticesMST, edgesMST); ;//Добавляем ребро мнимального веса в МОД 
                inMST[edge2Add.V2Id] = true;//Отмечаем присоединенную вершину, как включенную в МОД 
                adjVertexSortListMST = adjVertexSortListMST.Union(adjVertexSortLists[edge2Add.V2Id], inMST);//Объединяем списки смежности МОД и последней добавленной вершины (при этом ребра внутри МОД удаляются)
            }
            if (edgesMST.Count != graph.Order - 1) throw new Exception("Ошибка МОД не найдено");
            return new Graph<VisVertex>(verticesMST, edgesMST);
        }

        private static AdjVertexSortedList[] GetAdjLists(Graph<VisVertex> graph)
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

        private static void AddEdge(Edge<VisVertex> edge, List<Vertex<VisVertex>> vertices, List<Edge<VisVertex>> edges)
        {
            edges.Add(new Edge<VisVertex>(vertices[edge.V1Id], vertices[edge.V2Id], edge.Weight));
        }
    }
}

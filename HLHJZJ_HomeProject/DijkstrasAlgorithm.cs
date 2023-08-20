using System;

namespace Graph_HomeProject
{
    public class DijkstraAlgorithm
    {
        Graph graph;


        //граф вертекс инфо должен быть в виде списка
        List<GraphVertexInfo> graphVertexInfos; //нет инициализации потому что мы ищем пути из разных вершин и каждый рза мы будем очищать этот лист

        public DijkstraAlgorithm(Graph graph)
        {
            this.graph = graph;
        }

        public void InitInfo()
        {
            graphVertexInfos = new List<GraphVertexInfo>();

            //граф.вертисес - список от вершин
            //проходится по каждой вершине, ко всем вертисам применит то что написано в фигурных скобках

            //был тип вертекс стал вар
            foreach (var vertex in graph.Vertices) //фор- диапазон от 1 до 10 выполни что то , а для форич это перебор данных, мне не нужно знать диапазон мне нужно просто для всех элементов запустить какое-то действие
            {
                graphVertexInfos.Add(new GraphVertexInfo(vertex));  //проходимся по каждой вершине графа и добавляем в нашу таблицу
            }
        }

        GraphVertexInfo GetVertexInfo(Vertex vertex)
        {
            foreach (GraphVertexInfo graphVertexInfo in graphVertexInfos)
            {
                if (graphVertexInfo.Vertex.Equals(vertex))
                {
                    return graphVertexInfo;
                }
            }

            return null; //если не нашли ни одной информации
        }

        public GraphVertexInfo FindUnvisitedVertexWithMinOrcs() //этот метод для нахождения мин колва орков до вершины, поиск непосещенной вершины с мин значением суммы
        {
            int minValue = int.MaxValue;
            GraphVertexInfo minVertexInfo = null;
            foreach (GraphVertexInfo graphVertexInfo in graphVertexInfos)
            {
                if (graphVertexInfo.IsUnvisited && graphVertexInfo.SumOfOrcs < minValue)
                {
                    minVertexInfo = graphVertexInfo;
                    minValue = graphVertexInfo.SumOfOrcs;
                }
            }

            return minVertexInfo;
        }

        public string FindShortestPath(string startLand, string finishLand) //норм ли так называть стринговое значение, или чтобы не путаться оставить finishLand?
        {
            return FindShortestPath(graph.FindVertex(startLand), graph.FindVertex(finishLand));
        }

        

        public string FindShortestPath(Vertex startVertex, Vertex finishVertex)
        {
            InitInfo();
            var first = GetVertexInfo(startVertex);
            first.SumOfOrcs = 0;
            while (true) //почему тут тру он будет проверять настоящее до тех пор пока не найдет анвизитед вертисес виз минимал оркс
            {
                var current = FindUnvisitedVertexWithMinOrcs();
                if (current == null)
                {
                    break;
                }

                SetSumToNextVertex(current);
            }
            GraphVertexInfo info = GetVertexInfo(finishVertex);
            return GetPath(startVertex, finishVertex) + " " + info.SumOfOrcs;
        }
        // Вычисление суммы весов ребер для следующей вершины
        void SetSumToNextVertex(GraphVertexInfo info)
        {
            info.IsUnvisited = false;
            foreach (var e in info.Vertex.ways)
            {
                var nextInfo = GetVertexInfo(e.ConnectedVertex);
                var sum = info.SumOfOrcs + e.Weight;
                if (sum < nextInfo.SumOfOrcs)
                {
                    nextInfo.SumOfOrcs = sum;
                    nextInfo.PreviousVertex = info.Vertex;
                }
            }
        }
        // Формирование пути
        public string GetPath(Vertex startVertex, Vertex endVertex)
        {
            var path = endVertex.ToString();
            while (startVertex != endVertex)
            {
                endVertex = GetVertexInfo(endVertex).PreviousVertex;
                path = endVertex.ToString() + " -> " + path;
            }

            return path;
        }
    }
}


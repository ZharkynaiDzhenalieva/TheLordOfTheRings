using System;
namespace Graph_HomeProject
{
    public class GraphVertexInfo
    {
        public Vertex Vertex { get; set; } //вершина

        public bool IsUnvisited { get; set; } //посещали или не посещали

        public int SumOfOrcs { get; set; } //сумма весов ребер (shortest distance from A)

        public Vertex PreviousVertex { get; set; }

        public GraphVertexInfo(Vertex vertex)
        {
            Vertex = vertex;
            this.IsUnvisited = true;
            SumOfOrcs = int.MaxValue; //константа, по сути мы берем бесконечность 
            PreviousVertex = null; //пока что предыдущего вертекса нет, по умолчанию налл- отсутствие данных( не одно и то же с 0!)
        }




        //отсюда переходим на дейкстра класс

    }
}


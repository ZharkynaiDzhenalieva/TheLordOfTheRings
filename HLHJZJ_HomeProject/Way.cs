using System;
namespace Graph_HomeProject
{
    public class Way
    {
        public int Weight { get; }
        public Vertex ConnectedVertex { get; }
        public Orcs<string> orcs;

        public Way(Vertex connectedVertex, int weight)
        {
            this.Weight = weight; //numberOfOrcs
            this.ConnectedVertex = connectedVertex;
            this.orcs = new Orcs<string>(); 
            for (int i = 0; i < weight; i++) //если вес равен нулю, то условие не выполнится
            {
                this.orcs.Insert2Back($"Orc #{i}"); 
            }
        }
    }
}


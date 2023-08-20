using System;
namespace Graph_HomeProject
{
    public class Way
    {
        public int Weight { get; }
        public Vertex ConnectedVertex { get; }


        public Way(Vertex connectedVertex, int weight)
        {
            this.Weight = weight;
            this.ConnectedVertex = connectedVertex;
        }
    }
}


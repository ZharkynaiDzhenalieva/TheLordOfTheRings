using System;
namespace Graph_HomeProject
{
    //egde of the graph
    public class Way
    {
        //EdgeWeight
        public int NumberOfOrcs { get; }

        //connected vertex
        public Site ConnectedSite { get; }
        public Orcs<string> orcs;


        
        public Way(Site connectedVertex, int numberOfOrcs)
        {
            this.NumberOfOrcs = numberOfOrcs; 
            this.ConnectedSite = connectedVertex;
            this.orcs = new Orcs<string>(); 
            for (int i = 0; i < numberOfOrcs; i++) 
            {
                this.orcs.Insert2Back($"Orc #{i}"); 
            }
        }
    }
}


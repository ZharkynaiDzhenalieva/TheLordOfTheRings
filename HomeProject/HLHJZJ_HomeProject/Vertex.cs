using System;
using System.Xml.Linq;


namespace Graph_HomeProject
{
    //Graph Vertex
    public class Site
    {
        public string land;
        
        public bool IsUnderSauron { get; }

        //list of Edges
        public List<Way> ways { get; }



        public Site(string land, bool isUnderSauron)
        {
            this.land = land;
            this.ways = new List<Way>();
            this.IsUnderSauron = isUnderSauron;

        }


        //AddEdge
        public void AddWay(Site vertex, int numberOfOrcs)
        {
            ways.Add(new Way(vertex, numberOfOrcs));
        }


        //Convert to string
        public override string ToString() => land;



    }
}


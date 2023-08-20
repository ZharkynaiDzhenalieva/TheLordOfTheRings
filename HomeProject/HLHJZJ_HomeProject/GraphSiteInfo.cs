using System;
namespace Graph_HomeProject
{
    //Information about the Vertex
    //table
    public class GraphSiteInfo
    {
        //Vertex
        public Site Site { get; set; } 

        //Invisited Vertex
        public bool IsUnvisited { get; set; } 

        //Edges Weight Sum
        public int SumOfOrcs { get; set; } 

        //Previous Vertex
        public Site PreviousSite { get; set; }

        public GraphSiteInfo(Site site)
        {
            this.Site = site;
            this.IsUnvisited = true;
            this.SumOfOrcs = int.MaxValue; 
            this.PreviousSite = null; 
        }




       

    }
}


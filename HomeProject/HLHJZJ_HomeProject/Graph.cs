using System;
namespace Graph_HomeProject
{
    //Graph
    public class Graph
    {
        //List of Graph's Vertices
        public List<Site> Sites { get; }

        public Graph()
        {
            Sites = new List<Site>();
        }

        //AddVertex
        public void AddSite(string nameOfLand, bool isUnderSauron)
        {
            Sites.Add(new Site(nameOfLand, isUnderSauron));
        }

        //Vertex Search
        public Site FindSite(string nameOfLand)
        {
            foreach (Site vertex in Sites)
            {
                if (vertex.land.Equals(nameOfLand))
                {
                    return vertex;
                }
            }

            return null; 
        }

        //AddEdge
        public void AddWay(string from, string to, int weight)
        {
            var start = FindSite(from);
            var finish = FindSite(to);
            if (finish != null && start != null)
            {
                start.AddWay(finish, weight); //это из вертекс класса
                finish.AddWay(start, weight);
            }
        }
        public void GenerateEdgesRandomly(double probability)
        {
            Random RND = new Random();

            foreach (var vertexOne in Sites)
            {
                foreach (var vertexTwo in Sites)
                {
                    if (vertexOne != vertexTwo && RND.NextDouble() < probability && !EdgeExists(vertexOne, vertexTwo) && !EdgeExists(vertexTwo, vertexOne))
                    {
                        int numberOfOrcs = RND.Next(1, 100);
                        AddWay(vertexOne.land, vertexTwo.land, numberOfOrcs);
                    }
                }
            }
        }
        public bool EdgeExists(Site source, Site destination)
        {
            foreach (var way in source.ways)
            {
                if (way.ConnectedSite == destination)
                {
                    return true;
                }

            }
            return false;
        }
    }
}



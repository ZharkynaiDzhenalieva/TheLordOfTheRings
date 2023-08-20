using System;

namespace Graph_HomeProject
{
    //Dijkstra's Algorithm
    public class DijkstrasAlgorithm
    {
        Graph graph;


        List<GraphSiteInfo> graphSiteInfos; 

        public DijkstrasAlgorithm(Graph graph)
        {
            this.graph = graph;
        }

        public void InitInfo()
        {
            graphSiteInfos = new List<GraphSiteInfo>();

            foreach (var vertex in graph.Sites)
            {
                graphSiteInfos.Add(new GraphSiteInfo(vertex)); 
            }
        }
        //Getting Information about the Vertex of the Graph
        GraphSiteInfo GetSiteInfo(Site vertex)
        {
            foreach (GraphSiteInfo graphSiteInfo in graphSiteInfos)
            {
                if (graphSiteInfo.Site.Equals(vertex))
                {
                    return graphSiteInfo;
                }
            }

            return null;
        }
        //Find Unvisited Vertex With Min Sum
        public GraphSiteInfo FindUnvisitedSiteWithMinOrcs()
        {
            int minValue = int.MaxValue;
            GraphSiteInfo minSiteInfo = null;
            foreach (GraphSiteInfo graphSiteInfo in graphSiteInfos)
            {
                if (graphSiteInfo.IsUnvisited && graphSiteInfo.SumOfOrcs < minValue)
                {
                    minSiteInfo = graphSiteInfo;
                    minValue = graphSiteInfo.SumOfOrcs;
                }
            }

            return minSiteInfo;
        }
        //Finding the Shortest Path by Vertex Names
        public string FindShortestPath(string startLand, string finishLand) 
        {
            return FindShortestPath(graph.FindSite(startLand), graph.FindSite(finishLand));
        }

        
        //Finding the Shortest Path
        public string FindShortestPath(Site source, Site destination)
        {
            InitInfo();
            var first = GetSiteInfo(source);
            first.SumOfOrcs = 0;
            while (true) 
            {
                var current = FindUnvisitedSiteWithMinOrcs();
                if (current == null)
                {
                    break;
                }

                SetSumToNextSite(current);
            }
            GraphSiteInfo info = GetSiteInfo(destination);
            return GetPath(source, destination) + " " + info.SumOfOrcs;
        }
        // Calculate the Sum of Edge Weights for the Next Vertex
        void SetSumToNextSite(GraphSiteInfo info)
        {
            info.IsUnvisited = false;
            foreach (var e in info.Site.ways)
            {
                var nextInfo = GetSiteInfo(e.ConnectedSite);
                var sum = info.SumOfOrcs + e.NumberOfOrcs;
                if (sum < nextInfo.SumOfOrcs)
                {
                    nextInfo.SumOfOrcs = sum;
                    nextInfo.PreviousSite = info.Site;
                }
            }
        }
        // Forming the path
        public string GetPath(Site source, Site destination)
        {
            var path = destination.ToString();
            while (source != destination)
            {
                destination = GetSiteInfo(destination).PreviousSite;
                path = destination.ToString() + " -> " + path;
            }

            return path;
        }
    }
}


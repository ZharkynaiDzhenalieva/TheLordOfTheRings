using System;
namespace Graph_HomeProject
{
    public class Graph
    {

        public List<Vertex> Vertices { get; } 
        public void AddVertex(Vertex vertex)
        {
            Vertices.Add(vertex);
        }

        public void AddVertex(string nameOfLand, bool isUnderSauron)
        {
            AddVertex(new Vertex(nameOfLand, isUnderSauron));
        }



        public Graph()
        {
            Vertices = new List<Vertex>(); //2.создаю пустой список переменная = стронгли тайпд лист оф обджектс(вертекс)
        }

        public Vertex FindVertex(string nameOfLand)
        {
            foreach (Vertex vertex in Vertices)
            {
                if (vertex.land.Equals(nameOfLand))
                {
                    return vertex;
                }
            }

            return null; //прошелся по списку и не нашел данные
        }
        public void AddWay(string from, string to, int weight)
        {
            var start = FindVertex(from);
            var finish = FindVertex(to);
            if (finish != null && start != null)
            {
                start.AddWay(finish, weight); //это из вертекс класса
                finish.AddWay(start, weight);
            }
        }
        //public void GenerateEdgesRandomly(double probability)
        //{
        //    Random RND = new Random();

        //    foreach (var vertexOne in Vertices)
        //    {
        //        foreach (var vertexTwo in Vertices)
        //        {
        //            if (vertexOne != vertexTwo && RND.NextDouble() < probability)
        //            {
        //                int numberOfOrcs = RND.Next(1, 100);
        //                AddWay(vertexOne.land, vertexTwo.land, numberOfOrcs);
        //            }
        //        }
        //    }
        //}
        //public bool EdgeExists(Vertex source, Vertex destination)
        //{
        //    foreach (var way in source.ways )
        //    {
        //        if (way.ConnectedVertex == destination)
        //        {
        //            return true;
        //        }
                
        //    }
        //    return false;
        //}
    }
}

//внутри метода обращаться именно к голубым и белым

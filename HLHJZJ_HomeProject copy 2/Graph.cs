using System;
namespace Graph_HomeProject
{
    public class Graph
    {

        public List<Vertex> Vertices { get; } //зеленые - это типы  //белые - переменные // голубые - аргументы
                                              //1.список инициализируют в конструкторе
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

    }
}

//внутри метода обращаться именно к голубым и белым

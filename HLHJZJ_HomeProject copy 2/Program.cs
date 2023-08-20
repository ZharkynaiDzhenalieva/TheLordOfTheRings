using System;

namespace Graph_HomeProject
{
    internal class Program
    {
        static public Graph InitialiseGraph()
        {
            var g = new Graph();

            //добавление вершин
            g.AddVertex("Mordor", true);
            g.AddVertex("County", false);
            g.AddVertex("Minas-Tirith", false);
            g.AddVertex("Rivendell", false);
            g.AddVertex("Edoras", true);
            g.AddVertex("Harad Desert", true);
            g.AddVertex("The Shire", false);



            //g.AddWay("Mordor", "County", 22);
            g.AddWay("Mordor", "Minas-Tirith", 33);
            g.AddWay("Mordor", "Rivendell", 61);
            g.AddWay("County", "Minas-Tirith", 47);
            g.AddWay("County", "Edoras", 93);
            g.AddWay("Minas-Tirith", "Rivendell", 11);
            g.AddWay("Minas-Tirith", "Edoras", 79);
            g.AddWay("Minas-Tirith", "Harad Desert", 63);
            g.AddWay("Rivendell", "Harad Desert", 41);
            g.AddWay("Edoras", "Harad Desert", 17);
            g.AddWay("Edoras", "The Shire", 58);
            g.AddWay("Harad Desert", "The Shire", 84);

            return g;
        }
        static void Main(string[] args)
        {
            Graph graph = InitialiseGraph();

            Console.WriteLine("Hello! This application is ");
            Console.WriteLine("***********************************");
            Console.WriteLine("Please use following commands:");
            Console.WriteLine("1 - determine if the site is under Saurons influence or not");
            Console.WriteLine("2 - show Saurons influenced sites");
            Console.WriteLine("3 - show the safest anf fastest way");
            Console.WriteLine("0 - exit application");
            bool exitCommand = false;
            string cmd = Console.ReadLine() ?? "";
            while (!exitCommand)
            {

                switch (cmd)
                {
                    case "1": 
                        {
                            Console.WriteLine("Choose the site you want to check");
                            string site = Console.ReadLine() ??"";
                            Vertex vertex = graph.FindVertex(site);
                            if (vertex.IsUnderSauron == true)
                            {
                                Console.WriteLine("is under Saurons hands");
                            }
                            else
                            {
                                var joinedNames = vertex.ways.Aggregate("",(a, b) => a + ", " + b.ConnectedVertex.land);//функция для листов, проходится по всем элементам списка и генерирует агрегирующий результат
                                Console.WriteLine("is free" + joinedNames);
                            }
                            break;

                        }

                    case "2":
                        {
                            Console.WriteLine("sites influenced by Sauron");

                            
                            break;
                        }
                   
                    case "0":
                        exitCommand = true; //exit application
                        break;
                    default:
                        Console.WriteLine("Invalid command provided");
                        break;
                }
                if (!exitCommand)
                {
                    cmd = Console.ReadLine() ?? "";
                }

            }

        }
    }
}

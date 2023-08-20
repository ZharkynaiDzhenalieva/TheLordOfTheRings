using System;

namespace Graph_HomeProject
{
    internal class Program
    {
        static public Graph GenerateWays(Graph g, bool random = false)
        {

            if (random == true)
            {
                Console.WriteLine("Welcome to the Lord of The Rings Universe! Here are the possible ways:");
                g.GenerateEdgesRandomly(0.3);
                foreach (var site in g.Sites)
                {
                    Console.WriteLine("From " + site.land + " You Can Go To:");
                    foreach (var way in site.ways)
                    {
                        Console.WriteLine(way.ConnectedSite + " " + way.NumberOfOrcs);
                    }
                }
            }
            else
            {
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
            }

            return g;
        }

        static public Graph InitialiseGraph()
        {
            var g = new Graph();

            //добавление вершин
            g.AddSite("Mordor", true);
            g.AddSite("County", false);
            g.AddSite("Minas-Tirith", false);
            g.AddSite("Rivendell", false);
            g.AddSite("Edoras", true);
            g.AddSite("Harad Desert", true);
            g.AddSite("The Shire", false);

            return g;
        }
        static void Main(string[] args)
        {
            Graph graph = GenerateWays(InitialiseGraph(), true); //true when its random



            Console.WriteLine("Hello! This application is made to help the two hobbits, Frodo and Sam, get to Mount Doom ");
            Console.WriteLine("***********************************");
            Console.WriteLine("Please use following commands:");
            Console.WriteLine("1 - Determine if the venue is in Sauron's hands. If not, please show the neighbour sites");
            Console.WriteLine("2 - Show the orcs stationed in sites, that are under Sauron's influence ");
            Console.WriteLine("3 - Tell us through which places the two hobbits from the County can get to Mordor on the fastest way, while touching places where as few orcs as possible are stationed");

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
                            string site = Console.ReadLine() ?? "";
                            Site vertex = graph.FindSite(site);
                            if (vertex.IsUnderSauron == true)
                            {
                                Console.WriteLine("is under Saurons hands");
                            }
                            else
                            {
                                var joinedNames = vertex.ways.Aggregate("", (a, b) => a + ", " + b.ConnectedSite.land);//функция для листов, проходится по всем элементам списка и генерирует агрегирующий результат
                                Console.WriteLine("is free" + joinedNames);
                            }
                            break;

                        }

                    case "2":
                        {
                            Console.WriteLine("Choose the site you want to check");
                            string site = Console.ReadLine() ?? "";
                            Site vertex = graph.FindSite(site);
                            foreach (var way in vertex.ways)
                            {
                                Console.WriteLine();
                                Console.WriteLine(way.ConnectedSite.land + ":");
                                way.orcs.Print();
                            }

                            break;
                        }

                    case "3":
                        {
                            try
                            {
                                var dijkstra = new DijkstrasAlgorithm(graph);
                                var path = dijkstra.FindShortestPath("County", "Mordor");
                                Console.WriteLine(path);

                            }
                            catch (NullReferenceException e)
                            { Console.WriteLine("Unable to find path"); }
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

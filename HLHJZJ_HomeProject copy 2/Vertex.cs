using System;
using System.Xml.Linq;
using HLHJZJ_HomeProject;

namespace Graph_HomeProject
{
    public class Vertex
    {
        public string land;
        //если класс не может существовать без какого либо свойства то он должен быть в аргументах конструктора
        //есть вершина- вершина не может быть без названия(ленд)

        //3
        public bool IsUnderSauron { get; }
        public List<Way> ways { get; } //get- почтовый ящик, всегда будет заполнен письмами, тогда я его создаю в конструкторе
                                       //почтовый ящик возвращает письмо . геттер сокращенный


        public Vertex(string land, bool isUnderSauron)
        {
            this.land = land;
            this.ways = new List<Way>();
            this.IsUnderSauron = isUnderSauron;
            //по умолчанию создает пустой лист когда создается вертекс^ программа скажет чел,
                                         //ты не можешь создать вершину без отрезков если дать аргумент в конструкторе,
                                         //а не инициализировать внутри
        }



        public override string ToString() => land;




        /// <summary>
        /// Добавить ребро(более дружелюбный - без проблем, только мне нужны вот эти переменные)
        /// </summary>
        /// <param name="vertex">Вершина</param>
        /// <param name="edgeWeight">Вес</param>
        public void AddWay(Vertex vertex, int numberOfOrcs)
        {
            AddWay(new Way(vertex, numberOfOrcs));
        }

        public void AddWay(Way newWay)
        {
            ways.Add(newWay);
        }
        /// <summary>
        /// Добавить ребро(требует готовые - то есть перед этим я должна сама создать ребро)
        /// </summary>
        /// <param name="newEdge">Ребро</param>
    }
}


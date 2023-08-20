using System;
using System.Xml.Linq;


namespace Graph_HomeProject
{
    public class Vertex
    {
        public string land;
        
        public bool IsUnderSauron { get; }
        public List<Way> ways { get; }

         

        public Vertex(string land, bool isUnderSauron)
        {
            this.land = land;
            this.ways = new List<Way>(); //инициализируем хотя бы пустым, иначе при вызове эдд вей он упадет потому что будет нулл
            this.IsUnderSauron = isUnderSauron;
            
        }



        public override string ToString() => land; //чтобы отображал что то понятное //чтобы правильно отображать вертекс

        public void AddWay(Vertex vertex, int numberOfOrcs)
        {
            ways.Add(new Way(vertex, numberOfOrcs));
        }

        
        
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12
{
    internal class Program
    {
        static void Main(string[] args) // Without Constructor :
        {
            //car c = new car();
            //c.year = 2022;
            //c.model = "Mango";
            //c.color = "Yellow";

            //car c2 = new car();
            //c2.year = 2023;
            //c2.model = "Apple";
            //c2.color = "Red";
            //Console.WriteLine("year : {0} model : {1} color : {2} " , c.year,c.model,c.color);
            //Console.WriteLine("{0} {1} {2}",c2.year,c2.model,c2.color);
            //Console.ReadLine();

            // With Constructor :

            car c = new car(1992 , "Graph" , "Green");
            car c2 = new car(1882 , "Pich" , "LightGreen");
            Console.WriteLine( "{0} {1} {2}" , c.year , c.model ,c.color);
            Console.WriteLine("{0} {1} {2}",c2.year,c2.model,c2.color);
            Console.ReadLine();
        } 
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11
    //Constructor :
{
    internal class car
    {
        //public string model;
        //public string name;

        //public  car()
        //{
        //    model = "toyota";
        //    name = "kgf2";
        //}

        //cONSTRUCTOR WITH PERAMETERS:

        public int age;
        public string name;
        public string model;
        public car(int Age, string Name, string Model)
        {
            age = Age;
            name = Name;
            model = Model;


            Console.WriteLine("{0} {1} {2}" , Age , Name , Model);
            Console.ReadLine();
        }

    }
}

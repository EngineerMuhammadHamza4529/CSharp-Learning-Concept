using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Animal myanimal = new Animal();
            //Pig mypig = new Pig();
            //Dog mydog = new Dog();
            //myanimal.animalsound();
            //mypig.animalsound();
            //mydog.animalsound();
            //Console.ReadLine();
            Animal myanimal = new Animal();
            Animal mypig = new Pig();
            Animal mydog = new Dog();

            myanimal.animalsound();
            mypig.animalsound();
            mydog.animalsound();
            Console.ReadLine();


            
        }
    }
}

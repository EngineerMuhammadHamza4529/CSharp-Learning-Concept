using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp10;
namespace ConsoleApp10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            student std = new student();
            library lib = new library();
           

            std.mymetod(1200);
            std.mystr("Hello World");
            lib.mylib(333);           
            Console.ReadLine(); 
        }
    }
}

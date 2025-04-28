using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            student std = new student();
            std.Age = 10;
            Console.WriteLine(std.Age);
            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp9;
namespace ConsoleApp9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            student std = new student();
            std.age = 25;
            std.marks = 200;
            std.name = "Hamza";
            std.details();
            std.details1();
        }
    }
}

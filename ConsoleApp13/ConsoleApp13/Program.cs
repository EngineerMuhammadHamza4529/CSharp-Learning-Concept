using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            person p = new person();
            p.Name = "Hamza Shaikh";
            Console.WriteLine(p.Name);
            Console.ReadLine();
        }
    }
}

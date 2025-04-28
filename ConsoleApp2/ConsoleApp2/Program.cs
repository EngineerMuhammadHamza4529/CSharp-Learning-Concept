using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string firstname = "Hamza";
            string lastname = "Shaikh";
            //Console.WriteLine("{0}  {1}",firstname,lastname);
            // string fulname = firstname + lastname;
            string fulname = firstname + " " + lastname;
            Console.WriteLine(fulname);
            Console.ReadLine();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[3];
            array[0] = 1;
            array[1] = 2;   
            array[2] = 3;
            Console.WriteLine(array[2]);
            Console.ReadLine(); 

            string[] array2 = new string[3];

            array2[0] = "2";
            array2[1] = "8";
            array2[2] = "6";
            Console.WriteLine(array2[2]);
            Console.ReadLine();

            string[] array3 = { "hamza", "shaikh" } ;
            Console.WriteLine(array3[1]);
            Console.ReadLine();

        }
    }
}

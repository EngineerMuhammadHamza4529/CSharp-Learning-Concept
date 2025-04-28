using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] myNum = { 100, 20, 30, 40 };
            Array.Sort(myNum);
            foreach (int item in myNum)
            {
                Console.WriteLine(item);
                Console.ReadLine();
            }
        }
    }
}

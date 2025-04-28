using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 1  , b=2;
            int sum = a + b;
            int sub = a - b;
            int mul = a * b;
            // Console.WriteLine($"sum = { sum} sub = {sub} mul - {mul}" );
            Console.WriteLine("sum={0}\n sub={1}\n mul={2}\n",sum,sub,mul);
            
            Console.ReadLine();
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cloth c = new Cloth();
            c.productID = 1;
            c.name = "jeans";
            c.price = 100;
            c.color = "Blue";
            c.size = 32;
      
            Console.WriteLine("{0} {1} {2} {3} {4}",c.productID,c.name,c.price,c.color,c.size);
            Console.ReadLine();

            Food f = new Food();
            f.productID = 2;
            f.name = "Burger";
            f.price = 200;
            f.size =32;
            Console.WriteLine("{0} {1} {2} {3}",f.productID,f.name,f.price,f.size);
            Console.ReadLine();
        }
    }
}

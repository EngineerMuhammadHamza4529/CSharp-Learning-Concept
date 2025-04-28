using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp8;

namespace ConsoleApp8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Automobile auto1 = new Automobile();
            Automobile auto2 = new Automobile();
            Automobile auto3 = new Automobile();

            auto1.make = "Toyata";
            auto1.model = "Corolla";
            auto1.price = 220000;
            auto1.color = "Red";

            auto2.make = "Indus";
            auto2.model = "suzuki";
            auto2.price = 23000;
            auto2.color = "Blue";

            auto3.make = "Honda";
            auto3.model = "Civic";
            auto3.price = 27000;
            auto3.color = "Black";

            Automobile auto4 = new Automobile() { make = "Honda city", model = "Bike", price = 22200, color = "Rainbow" };

            Console.WriteLine( "make {0} , model {1} , price {2} , color {3}" , auto1.make,auto1.model,auto1.price,auto1.color);

            Console.WriteLine("make {0} , model {1} , price {2} , color {3}", auto2.make, auto2.model, auto2.price, auto2.color);
            Console.WriteLine("make {0} , model {1} , price {2} , color {3}", auto3.make, auto3.model, auto3.price, auto3.color);
            Console.WriteLine("make {0} , model {1} , price {2} , color {3}", auto4.make, auto4.model, auto4.price, auto4.color);
            Console.ReadLine();

       

        }
    }
}

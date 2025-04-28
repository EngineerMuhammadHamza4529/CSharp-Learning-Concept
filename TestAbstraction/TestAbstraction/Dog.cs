using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAbstraction
{
    public class Dog : Animal
    {
        public override void animalsound()
        {
            Console.WriteLine("Boww ..");
        }
    }
}

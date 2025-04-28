using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAbstraction
{
    public abstract class Animal
    {
        public  abstract void animalsound();

        public void sleep()
        {
            Console.WriteLine("Zzz..");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPolymorphism
{
    public class Animal
    {
        public virtual void MakeSound()
        {
            Console.WriteLine("The animal make a sound!!");
        }
    }
}

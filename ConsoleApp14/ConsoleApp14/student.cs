using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14
{
    internal class student
    {
        private int age;
        public int Age
        {
            get { return age; }
            set
            {
                if(value > 0)
                {
                    age = value;
                }
                else
                {
                    Console.WriteLine("you have entered invalid value : ");
                    Console.ReadLine();
                }
            }
        }

    }
}

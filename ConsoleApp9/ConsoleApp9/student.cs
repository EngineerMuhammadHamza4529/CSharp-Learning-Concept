using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    internal class student
    {
        public int age;
        public int marks;
        public string name;

        public void details()
        {
            Console.WriteLine("age {0} marks {1} name {2}" , age,marks,name);
            Console.ReadLine();
        }
        
        public void details1()
        {
            Console.WriteLine("This is my program : ");
            Console.ReadLine();
        }
        
    }
}

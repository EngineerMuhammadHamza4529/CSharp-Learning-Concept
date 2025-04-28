using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    internal class student
    {
        protected int age;
        private string name;
        protected int model;

        public void mymetod(int a)
        {
            age = a;
            Console.WriteLine(a);
        }
        public void mystr(string n)
        {
            name = n;
            Console.WriteLine(name);
        }
    }
    //Inhetence:
    class library : student
    {
        public void mylib(int m)
        {
            model = m;
            Console.WriteLine(m);
        }
    }
}



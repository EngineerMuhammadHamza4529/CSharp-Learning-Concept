using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            Console.WriteLine("Enter a number : ");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter a second number : ");
            int b= int .Parse(Console.ReadLine());
            if (a < 20 )
            {
                if (b < 50)
                {
                    Console.WriteLine("True");
                }
            }
            else
            {
                Console.WriteLine(false);
            }
            Console.ReadLine();
            */

            // if else if//

            int marks = 55;
            string grade = "";

            if (marks > 40 && marks < 50)
            {
                grade = "C";
            }
            if (marks > 50 && marks < 60)
            {
                grade = "B";
            }
            if (marks > 60 && marks < 70)
            {
                grade = "A";
            }
            if (marks > 80 && marks < 100)
            {
                grade = "A+";
            }
            if (marks < 40)
            {
                grade = "Fail";
            }
            Console.WriteLine("your grade is {0}",grade);
            Console.ReadLine();
           
        }
        
    }
}

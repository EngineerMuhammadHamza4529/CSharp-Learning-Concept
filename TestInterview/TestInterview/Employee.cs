using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestInterview
{
    public class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public int EmpAge { get; set; }
        public int EmpContact { get; set; }
        
        public void show()
        {
            Console.WriteLine("This is the method of Base class!!");
        }
    }


}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp15;
namespace ConsoleApp15
{
    internal class Food : Hardware
    {
        public int productID { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public DateTime Exp {get; set;}
    }
}

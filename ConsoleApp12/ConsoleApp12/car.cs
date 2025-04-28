using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12
{
    internal class car  
    {
        public int year;
        public string model;
        public string color;

        //With Constructor
        public car(int Year, string Model , string Color)
        {
            model = Model;
            year  = Year;
            color = Color;
        }
    }
}

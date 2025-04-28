using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    public class Car : Vehicle
    {
        public override void Start()
        {
            Console.WriteLine("Car Engine Started..");
        }

        public override void Stop()
        {
            Console.WriteLine("Car Enigine Stoped !!");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class ClassA:InterfaceA
    {
        int counter = 0;
        string str = "Hello!!";

        public void methodA()
        {
            //do something
        }

        public string display()
        {
            return "Hello";
        }

        public void print()
        {
            Console.WriteLine("Hi!!!");
        }
    }
}

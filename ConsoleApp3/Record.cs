using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Record
    {
        public Record() { }

        public void Hello() { 
            Student std = new Student();
            std.Name = "Nick";
            std.Address = "Paris";
            std.Age = 50;
        }
    }
}

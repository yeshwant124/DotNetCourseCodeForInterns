using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class ScienceStudent:Student
    {
        //Constructor
        public ScienceStudent()
        {

        }

        //Method Overriding
        public override void returnHello()
        {
            Console.WriteLine("Hello Science Student!!!");
        }

        public override void returnHello(string name)
        {
            Console.WriteLine("Welcome to C# tutorial:" + name);
        }

        public void MethodA(int age,string name,string address)
        {
            ScienceStudent student = new ScienceStudent();
            student.Name = name;
            student.Age = age;
            student.Address = address;
        }
    }
}

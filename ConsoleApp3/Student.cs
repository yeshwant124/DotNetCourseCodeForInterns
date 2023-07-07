using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class Student
    {
        protected internal int Age;

        public string Name;

        public string Address;

        //Constructor
        public Student()
        {
            if(Name == null) Name = string.Empty;
            if (Address == null) Address = string.Empty;
        }

        public Student(int age, string name, string address)
        {
            Age = age;
            Name = name;
            Address = address;
        }

        public virtual void returnHello()
        {
            Console.WriteLine("Hello Student!!!");
        }

        //Method Overloading
        public virtual void returnHello(string name)
        {
            Console.WriteLine("Hello " + name + "!!!");            
        }
    }
    
}

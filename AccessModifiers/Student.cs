using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessModifiers
{
    public class Student
    {
        public string Name { get; set; }

        public int Id { get; set; }

        public int Age { get; set; }

        public string DOB { get; set; }

        public Student() { 
            
        }

        
        public void MethodA()
        {
            Student student = new Student();
            student.Name = Name;
            Console.WriteLine("do Something");
        }
    }
}

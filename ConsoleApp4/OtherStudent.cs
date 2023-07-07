using ConsoleApp3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class OtherStudent:Student
    {
        public void MethodB() {
            OtherStudent student = new OtherStudent();

            student.Name = "Charles";
            student.Address = "Texas";
            student.Age = 20;

        }
        
    }
}

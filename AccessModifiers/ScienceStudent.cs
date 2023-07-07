using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessModifiers
{
    internal class ScienceStudent:Student
    {
        
        public ScienceStudent()
        {

        }

        public void MethodA()
        {
            ScienceStudent student = new ScienceStudent();
            student.Name = "A";
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessModifiers
{
    internal class Record
    {
        public Record() { 
        
        }

        public void MethodA() { 
            Student std = new Student();
            std.Name = "Deepak";
            std.Age = 40;
            std.DOB = "3/12/2005";
                
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccessModifiers;

namespace AccessModifier2
{
    internal class OtherRecord: AccessModifiers.Student
    {
        public static void Main()
        {
            OtherRecord otherRecord = new OtherRecord();

            otherRecord.Name = "Test";
            

        }

    }
}

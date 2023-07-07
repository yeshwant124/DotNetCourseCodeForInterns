using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLSeedExample.Models
{
    public partial class UserJobInfo
    {
        public int UserId { get; set; }
        public string? JobTitle { get; set; }
        public string? Department { get; set; }
    }
}

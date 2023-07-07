using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelExmaple.Models
{
    public class Computer
    {
        public int ComputerId { get; set; }
        //nullable strings
        public string? MotherBoard { get; set; }

        public int? CPUCores { get; set; }

        public bool HasWifi { get; set; }

        public bool HasLTE { get; set; }

        public DateTime ReleaseDate { get; set; }

        public decimal Price { get; set; }

        public string? VideoCard { get; set; }

        public Computer()
        {
           if(MotherBoard == null)
            {
                MotherBoard = string.Empty;
            }
           if(VideoCard == null)
            {
                VideoCard = string.Empty;   
            }
            if (CPUCores == null)
            {
                CPUCores = 0;
            }
        }
    }
}

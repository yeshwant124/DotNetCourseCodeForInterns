using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ModelExmaple2.Models
{
    public class Computer
    {
        [JsonPropertyName("ComputerId")]
        public int ComputerId { get; set; }
        //nullable strings
        
        [JsonPropertyName("motherboard")]
        public string? MotherBoard { get; set; }

        public int? CPUCores { get; set; }

        [JsonPropertyName("hasWifi")]
        public bool HasWifi { get; set; }

        [JsonPropertyName("hasLTE")]
        public bool HasLTE { get; set; }

        [JsonPropertyName("releaseDate")]
        public DateTime? ReleaseDate { get; set; }

        public decimal Price { get; set; }

        [JsonPropertyName("videoCard")]
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

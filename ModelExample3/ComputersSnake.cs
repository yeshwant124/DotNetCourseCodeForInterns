using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ModelExample3
{
    internal class ComputersSnake
    {
        public int computer_id { get; set; }
        //nullable strings

        public string? motherboard { get; set; }

        public int? cpu_cores { get; set; }

        public bool has_wifi { get; set; }

        public bool has_lte { get; set; }

        public DateTime? release_date { get; set; }

        public decimal price { get; set; }

        public string? video_card { get; set; }

        public ComputersSnake()
        {
            if (motherboard == null)
            {
                motherboard = string.Empty;
            }
            if (video_card == null)
            {
                video_card = string.Empty;
            }
            if (cpu_cores == null)
            {
                cpu_cores = 0;
            }
        }
    }
}

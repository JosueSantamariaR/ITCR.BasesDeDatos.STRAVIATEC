using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiStraviaTec
{
    public class Activity
    {
        public int id { get; set; }
        public string date { get; set; }
        public string hour { get; set; }
        public string duration { get; set; }
        public string type { get; set; }
        public int mileage { get; set; }
        public int traveled { get; set; }
    }
}

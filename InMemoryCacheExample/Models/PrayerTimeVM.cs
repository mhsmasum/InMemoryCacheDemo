using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InMemoryCacheExample.Models
{
    public class PrayerTimeVM
    {


        public string Code { get; set; }
        public string Ctatus { get; set; }
        public Data Data { get; set; }
    }

    public class Data
    {
        public Timings timings { get; set; }
        
    }
    public class Timings
    {
          public string Fajr { get; set; }
        public string Sunrise { get; set; }
        public string Dhuhr { get; set; }
        public string Asr { get; set; }
        public string Sunset { get; set; }
        public string Maghrib { get; set; }
        public string Isha { get; set; }
        public string Imsak { get; set; }
        public string Midnight { get; set; }
    }
}

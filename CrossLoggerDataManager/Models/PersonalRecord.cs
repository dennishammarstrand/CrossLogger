using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrossLoggerDataManager.Models
{
    public class PersonalRecord
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        public DateTime Date { get; set; }
        public User User { get; set; }
    }
}

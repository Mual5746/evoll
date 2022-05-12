using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evry.Evaluation.Models
{
    public class Person
    {
        public Guid ID { get; set; }
        public Guid RegionID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime Starts { get; set; }
        public DateTime Leaves { get; set; }

        public Person()
        {
            ID = Guid.NewGuid();
        }
    }
}

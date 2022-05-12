using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evry.Evaluation.Models
{
    public class Event
    {
        public Guid ID { get; set; }
        public Guid TypeID { get; set; }
        public Guid PersonID { get; set; }
        public DateTime Time { get; set; }
        public double Amount { get; set; }

        public Event()
        {
            ID = Guid.NewGuid();
        }
    }
}

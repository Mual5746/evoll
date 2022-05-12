using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Evry.Evaluation.Models
{
    public class EventViewModel
    {
        public Guid ID { get; set; }
        public Guid TypeID { get; set; }
        public Guid PersonID { get; set; }
        public string TypeName { get; set; }
        public string PersonName { get; set; }
        public DateTime Time { get; set; }
        public double Amount { get; set; }
        public double Sum { get; set; }
        public string Region { get; set; }
    }
}
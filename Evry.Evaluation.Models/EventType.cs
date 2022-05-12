using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evry.Evaluation.Models
{
    public class EventType
    {
        public Guid ID { get; set; }
        
        /// <summary>
        /// Multipliers by region
        /// </summary>
        public Dictionary<Guid,double> Multipliers { get; set; }
        public string Name { get; set; }

        public EventType()
        {
            ID = Guid.NewGuid();
        }
    }
}

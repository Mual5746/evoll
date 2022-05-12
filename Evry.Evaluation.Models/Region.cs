using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evry.Evaluation.Models
{
    public class Region
    {
        public Guid ID { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Name { get; set; }

        public Region()
        {
            ID = Guid.NewGuid();
        }
    }
}

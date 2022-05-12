using Evry.Evaluation.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evry.Evaluation.Models
{
    public class ProcessedPersonResult
    {
        public Guid ID { get; set; }
        public Guid PersonID { get; set; }
        public PeriodClass PeriodClass { get; set; }
        public Dictionary<PeriodType,double> PeriodTotals { get; set; }
        public double GrandTotal { get; set; }
    }
}

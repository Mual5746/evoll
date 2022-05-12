using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evry.Evaluation.Models.Enums
{
    public enum PeriodClass
    {
        None = 0,
        Week,
        Month,
        Quarter,
        Year
    }
    public enum PeriodType
    {
        None = 0,
        Current,
        Previous,
        Next
    }
}

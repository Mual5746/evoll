using Evry.Evaluation.Models;
using Evry.Evaluation.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evry.Evaluation.Interfaces.BusinessLogic
{
    public interface IProcessor
    {
        IEnumerable<ProcessedPersonResult> ProcessEvents(IEnumerable<Event> events, PeriodClass periodClass, IEnumerable<EventType> eventTypes = null);
    }
}

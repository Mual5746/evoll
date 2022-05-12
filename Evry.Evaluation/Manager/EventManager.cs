using Evry.Evaluation.Models;
using Evry.Evaluation.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Evry.Evaluation.Manager
{
    public class EventManager
    {
        public List<EventViewModel> GetEventList()
        {
            var result = new List<EventViewModel>();
            using (var repo = new DataRepository())
            {
                // EVAL: Get data from repository and fill view models
            }
            return result;
        }
    }
}
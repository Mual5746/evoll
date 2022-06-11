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
            
                repo.GetRegions();
                repo.GetPeople();//.Where(pep => pep.Firstname[1] != null);
                repo.GetEvents();
                repo.GetEventTypes();


                result.Add(new EventViewModel()
                {
                    PersonName = "Max",
                    Region =repo.region().Where(x =>x.Region[1] ),
                    TypeName = "This is type namne",                    
                    Amount = 22,
                    Sum = 223

                });
                //result = repo.GetEvents().Where()

                /// https://www.youtube.com/watch?v=n2SWViVYzoc  C# Tutorial: Lists of Objects
                /// 

                // https://www.youtube.com/watch?v=ExBIIDsHU-4 hendi button list


            }
            return result;
        }
    }
}
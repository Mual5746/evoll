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

                var allRegions = repo.GetRegions();
                var allPeople = repo.GetPeople();//.Where(pep => pep.Firstname[1] != null);
                var allEvents = repo.GetEvents();
                var allGetEventsType = repo.GetEventTypes();

                foreach (Person person in allPeople)
                {
                    var personRegion = allRegions.Where(region => region.ID == person.RegionID).FirstOrDefault();
                    var personRegionname = personRegion == null ? "Region not found" : personRegion.Name;
                    // om någon av evets id matcher med person id så plocka dem och gör den till list
                    var allPersonEvents = allEvents.Where(eve => eve.PersonID == person.ID).ToList();

                    if (allPersonEvents.Any())
                    {
                        double sum = allPersonEvents.Count(); //antal event
                        foreach (var personevent in allPersonEvents)
                        {
                            //plocka perosnnes event
                            double amount = personevent.Amount;
                            DateTime time = personevent.Time;
                            //plocka alla event som ha liknnande ID som personen om det inte finns returnera null
                            var eventType = allGetEventsType.FirstOrDefault(eveType => eveType.ID == personevent.ID);
                            Guid eventTypeID = eventType == null ? Guid.Empty : eventType.ID;
                            // om type name finns inte returnera ´medelande annars plocka eventtype name
                            String typeName = eventType == null ? "No event type name found" : eventType.Name;

                            //nu fyller eventViewmodelen med data från Repository 
                            result.Add(new EventViewModel
                            {
                                ID = person.ID,
                                TypeID = eventTypeID,
                                PersonID = person.ID,
                                TypeName = typeName,
                                PersonName = person.Firstname + " " + person.Lastname,
                                Time = time,
                                Amount = amount,
                                Sum = sum,
                                Region = personRegionname

                            });

                        }

                    }
                }
            }
            return result;
        }
    }
}
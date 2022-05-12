using Evry.Evaluation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evry.Evaluation.Interfaces.Repositories
{
    public interface IDataRepository : IDisposable
    {
        IEnumerable<Person> GetPeople();

        IEnumerable<Person> GetPeopleByRegion(Guid regionId);

        IEnumerable<Region> GetRegions();

        IEnumerable<Event> GetEvents();

        IEnumerable<Event> GetEventsByRegion(Guid regionId);

        IEnumerable<Event> GetEventsByPerson(Guid personId);

        IEnumerable<Event> GetEventsByType(Guid typeId);

        IEnumerable<Event> GetEventsByDateRange(DateTime start, DateTime end);

        IEnumerable<EventType> GetEventTypes();
    }
}

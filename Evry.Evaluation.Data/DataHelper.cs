using Evry.Evaluation.Interfaces.Data;
using Evry.Evaluation.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evry.Evaluation.Data
{
    public static class DataHelper
    {
        public static IDataSession Session()
        {
            return new TestDataSession();
        }

        public static IDataSession Session<T>(IEnumerable<T> set) where T : class
        {
            return Session().AddSet(set);
        }

        public static IDataSession AddSet<T>(this IDataSession session, IEnumerable<T> set) where T : class
        {
            session.SaveSet<T>(set);
            return session;
        }

        public static TestDataSession GetTestData()
        {
            var session = new TestDataSession();

            #region Test Data
            var regions = new Region[]
            {
                new Region
                {
                    ID = Guid.NewGuid(),
                    Name = "Home",
                    Start = DateTime.MinValue,
                    End = DateTime.MaxValue
                },
                new Region
                {
                    ID = Guid.NewGuid(),
                    Name = "Away",
                    Start = DateTime.MinValue,
                    End = DateTime.MaxValue
                },
                new Region
                {
                    ID = Guid.NewGuid(),
                    Name = "Close by",
                    Start = new DateTime(2000, 10, 10),
                    End = new DateTime(2018, 06, 01)
                }
            };

            var people = new Person[]
            {
                new Person
                {
                    ID = Guid.NewGuid(),
                    Firstname = "John",
                    Lastname = "Svensson",
                    Starts = new DateTime(1986, 02, 01),
                    Leaves = new DateTime(2001, 06, 15),
                    RegionID = regions[0].ID
                },
                new Person
                {
                    ID = Guid.NewGuid(),
                    Firstname = "Maria",
                    Lastname = "Andersson",
                    Starts = new DateTime(1996, 05, 01),
                    Leaves = new DateTime(2009, 10, 15),
                    RegionID = regions[1].ID
                },
                new Person
                {
                    ID = Guid.NewGuid(),
                    Firstname = "Erik",
                    Lastname = "Johansson",
                    Starts = new DateTime(1988, 03, 01),
                    Leaves = new DateTime(2007, 09, 15),
                    RegionID = regions[2].ID
                },
                new Person
                {
                    ID = Guid.NewGuid(),
                    Firstname = "Lars",
                    Lastname = "Karlsson",
                    Starts = new DateTime(1987, 05, 01),
                    Leaves = new DateTime(2015, 10, 15),
                    RegionID = regions[0].ID
                },
                new Person
                {
                    ID = Guid.NewGuid(),
                    Firstname = "Anna",
                    Lastname = "Nilsson",
                    Starts = new DateTime(1991, 09, 01),
                    Leaves = new DateTime(1999, 12, 15),
                    RegionID = regions[1].ID
                },
                new Person
                {
                    ID = Guid.NewGuid(),
                    Firstname = "Margareta",
                    Lastname = "Eriksson",
                    Starts = new DateTime(2001, 01, 01),
                    Leaves = new DateTime(2005, 08, 15),
                    RegionID = regions[2].ID
                },
                new Person
                {
                    ID = Guid.NewGuid(),
                    Firstname = "Karl",
                    Lastname = "Larsson",
                    Starts = new DateTime(1987, 08, 01),
                    Leaves = new DateTime(2010, 12, 15),
                    RegionID = regions[0].ID
                },
                new Person
                {
                    ID = Guid.NewGuid(),
                    Firstname = "Elisabeth",
                    Lastname = "Olsson",
                    Starts = new DateTime(2005, 02, 01),
                    Leaves = new DateTime(2008, 08, 15),
                    RegionID = regions[1].ID
                },
                new Person
                {
                    ID = Guid.NewGuid(),
                    Firstname = "Anders",
                    Lastname = "Persson",
                    Starts = new DateTime(2013, 10, 01),
                    Leaves = new DateTime(2034, 11, 15),
                    RegionID = regions[2].ID
                },
                new Person
                {
                    ID = Guid.NewGuid(),
                    Firstname = "Johan",
                    Lastname = "Gustafsson",
                    Starts = new DateTime(2011, 08, 01),
                    Leaves = new DateTime(2021, 09, 15),
                    RegionID = regions[0].ID
                },
                new Person
                {
                    ID = Guid.NewGuid(),
                    Firstname = "Eva",
                    Lastname = "Pettersson",
                    Starts = new DateTime(1998, 04, 01),
                    Leaves = new DateTime(2008, 02, 15),
                    RegionID = regions[1].ID
                }
            };

            var eventTypes = new EventType[]
            {
                new EventType
                {
                    ID = Guid.NewGuid(),
                    Name = "Normal",
                    Multipliers = new Dictionary<Guid, double> { { regions[0].ID, 0.9 }, { regions[1].ID, 0.5 }, { regions[2].ID, 1.5 } }
                },
                new EventType
                {
                    ID = Guid.NewGuid(),
                    Name = "Extra",
                    Multipliers = new Dictionary<Guid, double> { { regions[0].ID, 1.9 }, { regions[1].ID, 1.2 }, { regions[2].ID, 1.8 } }
                },
                new EventType
                {
                    ID = Guid.NewGuid(),
                    Name = "Slow",
                    Multipliers = new Dictionary<Guid, double> { { regions[0].ID, 0.7 }, { regions[1].ID, 0.3 }, { regions[2].ID, 1 } }
                }
            };

            var events = new Event[] 
            {
                new Event
                {
                    ID = Guid.NewGuid(),
                    Amount = 1,
                    PersonID = people[0].ID,
                    TypeID = eventTypes[1].ID,
                    Time = new DateTime(1992, 03, 05)
                },
                new Event
                {
                    ID = Guid.NewGuid(),
                    Amount = 10,
                    PersonID = people[0].ID,
                    TypeID = eventTypes[1].ID,
                    Time = new DateTime(2002, 05, 15)
                },
                new Event
                {
                    ID = Guid.NewGuid(),
                    Amount = 2,
                    PersonID = people[0].ID,
                    TypeID = eventTypes[2].ID,
                    Time = new DateTime(1997, 07, 05)
                },
                new Event
                {
                    ID = Guid.NewGuid(),
                    Amount = 1.8,
                    PersonID = people[0].ID,
                    TypeID = eventTypes[0].ID,
                    Time = new DateTime(1999, 01, 10)
                },
                new Event
                {
                    ID = Guid.NewGuid(),
                    Amount = 10.5,
                    PersonID = people[0].ID,
                    TypeID = eventTypes[1].ID,
                    Time = new DateTime(2005, 10, 26)
                },
                new Event
                {
                    ID = Guid.NewGuid(),
                    Amount = 17.8,
                    PersonID = people[0].ID,
                    TypeID = eventTypes[2].ID,
                    Time = new DateTime(2015, 08, 18)
                },
                new Event
                {
                    ID = Guid.NewGuid(),
                    Amount = 8.7,
                    PersonID = people[0].ID,
                    TypeID = eventTypes[2].ID,
                    Time = new DateTime(2010, 06, 17)
                },
                new Event
                {
                    ID = Guid.NewGuid(),
                    Amount = 1.8,
                    PersonID = people[0].ID,
                    TypeID = eventTypes[2].ID,
                    Time = new DateTime(2001, 11, 10)
                },
                new Event
                {
                    ID = Guid.NewGuid(),
                    Amount = 1,
                    PersonID = people[1].ID,
                    TypeID = eventTypes[1].ID,
                    Time = new DateTime(1992, 03, 05)
                },
                new Event
                {
                    ID = Guid.NewGuid(),
                    Amount = 10,
                    PersonID = people[1].ID,
                    TypeID = eventTypes[1].ID,
                    Time = new DateTime(2002, 05, 15)
                },
                new Event
                {
                    ID = Guid.NewGuid(),
                    Amount = 2,
                    PersonID = people[1].ID,
                    TypeID = eventTypes[2].ID,
                    Time = new DateTime(1997, 11, 05)
                },
                new Event
                {
                    ID = Guid.NewGuid(),
                    Amount = 1.8,
                    PersonID = people[1].ID,
                    TypeID = eventTypes[0].ID,
                    Time = new DateTime(1999, 01, 10)
                },
                new Event
                {
                    ID = Guid.NewGuid(),
                    Amount = 10.5,
                    PersonID = people[1].ID,
                    TypeID = eventTypes[1].ID,
                    Time = new DateTime(2005, 10, 26)
                },
                new Event
                {
                    ID = Guid.NewGuid(),
                    Amount = 17.8,
                    PersonID = people[1].ID,
                    TypeID = eventTypes[2].ID,
                    Time = new DateTime(2015, 08, 18)
                },
                new Event
                {
                    ID = Guid.NewGuid(),
                    Amount = 8.7,
                    PersonID = people[1].ID,
                    TypeID = eventTypes[2].ID,
                    Time = new DateTime(2010, 06, 17)
                },
                new Event
                {
                    ID = Guid.NewGuid(),
                    Amount = 1.8,
                    PersonID = people[1].ID,
                    TypeID = eventTypes[2].ID,
                    Time = new DateTime(2001, 11, 10)
                },
                new Event
                {
                    ID = Guid.NewGuid(),
                    Amount = 1,
                    PersonID = people[2].ID,
                    TypeID = eventTypes[1].ID,
                    Time = new DateTime(1992, 03, 05)
                },
                new Event
                {
                    ID = Guid.NewGuid(),
                    Amount = 10,
                    PersonID = people[2].ID,
                    TypeID = eventTypes[1].ID,
                    Time = new DateTime(2002, 05, 15)
                },
                new Event
                {
                    ID = Guid.NewGuid(),
                    Amount = 2,
                    PersonID = people[2].ID,
                    TypeID = eventTypes[2].ID,
                    Time = new DateTime(1997, 08, 05)
                },
                new Event
                {
                    ID = Guid.NewGuid(),
                    Amount = 1.8,
                    PersonID = people[2].ID,
                    TypeID = eventTypes[0].ID,
                    Time = new DateTime(1999, 01, 10)
                },
                new Event
                {
                    ID = Guid.NewGuid(),
                    Amount = 10.5,
                    PersonID = people[2].ID,
                    TypeID = eventTypes[1].ID,
                    Time = new DateTime(2005, 10, 26)
                },
                new Event
                {
                    ID = Guid.NewGuid(),
                    Amount = 17.8,
                    PersonID = people[2].ID,
                    TypeID = eventTypes[2].ID,
                    Time = new DateTime(2015, 08, 18)
                },
                new Event
                {
                    ID = Guid.NewGuid(),
                    Amount = 8.7,
                    PersonID = people[2].ID,
                    TypeID = eventTypes[2].ID,
                    Time = new DateTime(2010, 06, 17)
                },
                new Event
                {
                    ID = Guid.NewGuid(),
                    Amount = 1.8,
                    PersonID = people[2].ID,
                    TypeID = eventTypes[2].ID,
                    Time = new DateTime(2001, 11, 10)
                },
                new Event
                {
                    ID = Guid.NewGuid(),
                    Amount = 1,
                    PersonID = people[3].ID,
                    TypeID = eventTypes[1].ID,
                    Time = new DateTime(1992, 03, 05)
                },
                new Event
                {
                    ID = Guid.NewGuid(),
                    Amount = 10,
                    PersonID = people[3].ID,
                    TypeID = eventTypes[1].ID,
                    Time = new DateTime(2002, 05, 15)
                },
                new Event
                {
                    ID = Guid.NewGuid(),
                    Amount = 2,
                    PersonID = people[3].ID,
                    TypeID = eventTypes[2].ID,
                    Time = new DateTime(1997, 12, 05)
                },
                new Event
                {
                    ID = Guid.NewGuid(),
                    Amount = 1.8,
                    PersonID = people[3].ID,
                    TypeID = eventTypes[0].ID,
                    Time = new DateTime(1999, 01, 10)
                },
                new Event
                {
                    ID = Guid.NewGuid(),
                    Amount = 10.5,
                    PersonID = people[3].ID,
                    TypeID = eventTypes[1].ID,
                    Time = new DateTime(2005, 10, 26)
                },
                new Event
                {
                    ID = Guid.NewGuid(),
                    Amount = 17.8,
                    PersonID = people[3].ID,
                    TypeID = eventTypes[2].ID,
                    Time = new DateTime(2015, 08, 18)
                },
                new Event
                {
                    ID = Guid.NewGuid(),
                    Amount = 8.7,
                    PersonID = people[3].ID,
                    TypeID = eventTypes[2].ID,
                    Time = new DateTime(2010, 06, 17)
                },
                new Event
                {
                    ID = Guid.NewGuid(),
                    Amount = 1.8,
                    PersonID = people[3].ID,
                    TypeID = eventTypes[2].ID,
                    Time = new DateTime(2001, 11, 10)
                },
                new Event
                {
                    ID = Guid.NewGuid(),
                    Amount = 1,
                    PersonID = people[4].ID,
                    TypeID = eventTypes[1].ID,
                    Time = new DateTime(1992, 03, 05)
                },
                new Event
                {
                    ID = Guid.NewGuid(),
                    Amount = 10,
                    PersonID = people[4].ID,
                    TypeID = eventTypes[1].ID,
                    Time = new DateTime(2002, 05, 15)
                },
                new Event
                {
                    ID = Guid.NewGuid(),
                    Amount = 2,
                    PersonID = people[4].ID,
                    TypeID = eventTypes[2].ID,
                    Time = new DateTime(1997, 07, 05)
                },
                new Event
                {
                    ID = Guid.NewGuid(),
                    Amount = 1.8,
                    PersonID = people[4].ID,
                    TypeID = eventTypes[0].ID,
                    Time = new DateTime(1999, 01, 10)
                },
                new Event
                {
                    ID = Guid.NewGuid(),
                    Amount = 10.5,
                    PersonID = people[4].ID,
                    TypeID = eventTypes[1].ID,
                    Time = new DateTime(2005, 10, 26)
                },
                new Event
                {
                    ID = Guid.NewGuid(),
                    Amount = 17.8,
                    PersonID = people[4].ID,
                    TypeID = eventTypes[2].ID,
                    Time = new DateTime(2015, 08, 18)
                },
                new Event
                {
                    ID = Guid.NewGuid(),
                    Amount = 8.7,
                    PersonID = people[4].ID,
                    TypeID = eventTypes[2].ID,
                    Time = new DateTime(2010, 06, 17)
                },
                new Event
                {
                    ID = Guid.NewGuid(),
                    Amount = 1.8,
                    PersonID = people[4].ID,
                    TypeID = eventTypes[2].ID,
                    Time = new DateTime(2001, 11, 10)
                },
                new Event
                {
                    ID = Guid.NewGuid(),
                    Amount = 1,
                    PersonID = people[5].ID,
                    TypeID = eventTypes[1].ID,
                    Time = new DateTime(1992, 03, 05)
                },
                new Event
                {
                    ID = Guid.NewGuid(),
                    Amount = 10,
                    PersonID = people[5].ID,
                    TypeID = eventTypes[1].ID,
                    Time = new DateTime(2002, 05, 15)
                },
                new Event
                {
                    ID = Guid.NewGuid(),
                    Amount = 2,
                    PersonID = people[5].ID,
                    TypeID = eventTypes[2].ID,
                    Time = new DateTime(1997, 08, 05)
                },
                new Event
                {
                    ID = Guid.NewGuid(),
                    Amount = 1.8,
                    PersonID = people[5].ID,
                    TypeID = eventTypes[0].ID,
                    Time = new DateTime(1999, 01, 10)
                },
                new Event
                {
                    ID = Guid.NewGuid(),
                    Amount = 10.5,
                    PersonID = people[5].ID,
                    TypeID = eventTypes[1].ID,
                    Time = new DateTime(2005, 10, 26)
                },
                new Event
                {
                    ID = Guid.NewGuid(),
                    Amount = 17.8,
                    PersonID = people[5].ID,
                    TypeID = eventTypes[2].ID,
                    Time = new DateTime(2015, 08, 18)
                },
                new Event
                {
                    ID = Guid.NewGuid(),
                    Amount = 8.7,
                    PersonID = people[5].ID,
                    TypeID = eventTypes[2].ID,
                    Time = new DateTime(2010, 06, 17)
                },
                new Event
                {
                    ID = Guid.NewGuid(),
                    Amount = 1.8,
                    PersonID = people[5].ID,
                    TypeID = eventTypes[2].ID,
                    Time = new DateTime(2001, 11, 10)
                },
                new Event
                {
                    ID = Guid.NewGuid(),
                    Amount = 1,
                    PersonID = people[5].ID,
                    TypeID = eventTypes[1].ID,
                    Time = new DateTime(1992, 03, 05)
                },
                new Event
                {
                    ID = Guid.NewGuid(),
                    Amount = 10,
                    PersonID = people[5].ID,
                    TypeID = eventTypes[1].ID,
                    Time = new DateTime(2002, 05, 15)
                },
                new Event
                {
                    ID = Guid.NewGuid(),
                    Amount = 2,
                    PersonID = people[5].ID,
                    TypeID = eventTypes[2].ID,
                    Time = new DateTime(1997, 12, 05)
                },
                new Event
                {
                    ID = Guid.NewGuid(),
                    Amount = 1.8,
                    PersonID = people[5].ID,
                    TypeID = eventTypes[0].ID,
                    Time = new DateTime(1999, 01, 10)
                },
                new Event
                {
                    ID = Guid.NewGuid(),
                    Amount = 10.5,
                    PersonID = people[5].ID,
                    TypeID = eventTypes[1].ID,
                    Time = new DateTime(2005, 10, 26)
                },
                new Event
                {
                    ID = Guid.NewGuid(),
                    Amount = 17.8,
                    PersonID = people[5].ID,
                    TypeID = eventTypes[2].ID,
                    Time = new DateTime(2015, 08, 18)
                },
                new Event
                {
                    ID = Guid.NewGuid(),
                    Amount = 8.7,
                    PersonID = people[5].ID,
                    TypeID = eventTypes[2].ID,
                    Time = new DateTime(2010, 06, 17)
                },
                new Event
                {
                    ID = Guid.NewGuid(),
                    Amount = 1.8,
                    PersonID = people[5].ID,
                    TypeID = eventTypes[2].ID,
                    Time = new DateTime(2001, 11, 10)
                },
                new Event
                {
                    ID = Guid.NewGuid(),
                    Amount = 1,
                    PersonID = people[6].ID,
                    TypeID = eventTypes[1].ID,
                    Time = new DateTime(1992, 03, 05)
                },
                new Event
                {
                    ID = Guid.NewGuid(),
                    Amount = 10,
                    PersonID = people[6].ID,
                    TypeID = eventTypes[1].ID,
                    Time = new DateTime(2002, 05, 15)
                },
                new Event
                {
                    ID = Guid.NewGuid(),
                    Amount = 2,
                    PersonID = people[6].ID,
                    TypeID = eventTypes[2].ID,
                    Time = new DateTime(1997, 06, 05)
                },
                new Event
                {
                    ID = Guid.NewGuid(),
                    Amount = 1.8,
                    PersonID = people[6].ID,
                    TypeID = eventTypes[0].ID,
                    Time = new DateTime(1999, 01, 10)
                },
                new Event
                {
                    ID = Guid.NewGuid(),
                    Amount = 10.5,
                    PersonID = people[6].ID,
                    TypeID = eventTypes[1].ID,
                    Time = new DateTime(2005, 10, 26)
                },
                new Event
                {
                    ID = Guid.NewGuid(),
                    Amount = 17.8,
                    PersonID = people[6].ID,
                    TypeID = eventTypes[2].ID,
                    Time = new DateTime(2015, 08, 18)
                },
                new Event
                {
                    ID = Guid.NewGuid(),
                    Amount = 8.7,
                    PersonID = people[6].ID,
                    TypeID = eventTypes[2].ID,
                    Time = new DateTime(2010, 06, 17)
                },
                new Event
                {
                    ID = Guid.NewGuid(),
                    Amount = 1.8,
                    PersonID = people[6].ID,
                    TypeID = eventTypes[2].ID,
                    Time = new DateTime(2001, 11, 10)
                },
                new Event
                {
                    ID = Guid.NewGuid(),
                    Amount = 1,
                    PersonID = people[6].ID,
                    TypeID = Guid.NewGuid(),
                    Time = new DateTime(1992, 03, 05)
                },
                new Event
                {
                    ID = Guid.NewGuid(),
                    Amount = 10,
                    PersonID = people[6].ID,
                    TypeID = Guid.NewGuid(),
                    Time = new DateTime(2002, 05, 15)
                },
                new Event
                {
                    ID = Guid.NewGuid(),
                    Amount = 2,
                    PersonID = people[6].ID,
                    TypeID = eventTypes[2].ID,
                    Time = new DateTime(1997, 04, 05)
                },
                new Event
                {
                    ID = Guid.NewGuid(),
                    Amount = 1.8,
                    PersonID = people[6].ID,
                    TypeID = eventTypes[0].ID,
                    Time = new DateTime(1999, 01, 10)
                },
                new Event
                {
                    ID = Guid.NewGuid(),
                    Amount = 10.5,
                    PersonID = people[6].ID,
                    TypeID = Guid.NewGuid(),
                    Time = new DateTime(2005, 10, 26)
                },
                new Event
                {
                    ID = Guid.NewGuid(),
                    Amount = 17.8,
                    PersonID = people[6].ID,
                    TypeID = eventTypes[2].ID,
                    Time = new DateTime(2015, 08, 18)
                },
                new Event
                {
                    ID = Guid.NewGuid(),
                    Amount = 8.7,
                    PersonID = people[6].ID,
                    TypeID = eventTypes[2].ID,
                    Time = new DateTime(2010, 06, 17)
                },
                new Event
                {
                    ID = Guid.NewGuid(),
                    Amount = 1.8,
                    PersonID = people[6].ID,
                    TypeID = eventTypes[2].ID,
                    Time = new DateTime(2001, 11, 10)
                }
            };
            #endregion
            session.AddSet(regions);
            session.AddSet(people);
            session.AddSet(eventTypes);
            session.AddSet(events);
            return session;
        }
    }
}

using SimbaToursEastAfrica.Domain.Models;
using SimbaToursEastAfrica.Services.RepositoryServices.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimbaToursEastAfrica.Services.RepositoryServices.Concretes
{
    public class ItinaryRepository : AbstractRepository<Itinary>
    {
        public override bool Delete(Itinary toDelete)
        {
            try
            {
                toDelete = SimbaToursEastAfricaDbContext.Itinaries.SingleOrDefault(p => p.ItinaryId == toDelete.ItinaryId);
                SimbaToursEastAfricaDbContext.Remove(toDelete);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public override Itinary GetById(int id)
        {
            return SimbaToursEastAfricaDbContext.Itinaries.ToList().SingleOrDefault(p => p.ItinaryId == id);
        }

        public override bool Update(Itinary toUpdate)
        {
            try
            {
                var itinary = SimbaToursEastAfricaDbContext.Itinaries.ToList().SingleOrDefault(p => p.ItinaryId == toUpdate.ItinaryId);
                itinary.Schedules = toUpdate.Schedules;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}

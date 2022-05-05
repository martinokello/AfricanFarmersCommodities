using SimbaToursEastAfrica.Domain.Models;
using SimbaToursEastAfrica.Services.RepositoryServices.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimbaToursEastAfrica.Services.RepositoryServices.Concretes
{
    public class DestinationRepository : AbstractRepository<Destination>
    {
        public override bool Delete(Destination toDelete)
        {
            try
            {
                toDelete = SimbaToursEastAfricaDbContext.Destinations.SingleOrDefault(p => p.DestinationId == toDelete.DestinationId);
                SimbaToursEastAfricaDbContext.Remove(toDelete);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public override Destination GetById(int id)
        {
            return SimbaToursEastAfricaDbContext.Destinations.ToList().SingleOrDefault(p => p.DestinationId == id);
        }

        public override bool Update(Destination toUpdate)
        {
            try
            {
                var destination = SimbaToursEastAfricaDbContext.Destinations.ToList().SingleOrDefault(p => p.DestinationId == toUpdate.DestinationId);
                destination.ArriveTime = toUpdate.ArriveTime;
                destination.DepartTime = toUpdate.DepartTime;
                destination.DestinationFrom = toUpdate.DestinationFrom;
                destination.DestinationTo = toUpdate.DestinationTo;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}

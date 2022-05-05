using SimbaToursEastAfrica.Domain.Models;
using SimbaToursEastAfrica.Services.RepositoryServices.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimbaToursEastAfrica.Services.RepositoryServices.Concretes
{
    public class LocationRepository : AbstractRepository<Location>
    {
        public override bool Delete(Location toDelete)
        {
            try
            {
                toDelete = SimbaToursEastAfricaDbContext.Locations.SingleOrDefault(p => p.LocationId == toDelete.LocationId);
                SimbaToursEastAfricaDbContext.Remove(toDelete);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public override Location GetById(int id)
        {
            return SimbaToursEastAfricaDbContext.Locations.ToList().SingleOrDefault(p => p.LocationId == id);
        }

        public override bool Update(Location toUpdate)
        {
            try
            {
                var locations = SimbaToursEastAfricaDbContext.Locations.ToList().SingleOrDefault(p => p.LocationId == toUpdate.LocationId);
                locations.Address = toUpdate.Address;
                locations.AddressId = toUpdate.AddressId;
                locations.Country = toUpdate.Country;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}

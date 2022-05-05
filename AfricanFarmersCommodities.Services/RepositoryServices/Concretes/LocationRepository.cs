using AfricanFarmersCommodities.Domain;
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
                toDelete = GetById(toDelete.LocationId);
                AfricanFarmerCommoditiesDBContext.Remove(toDelete);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public override Location GetByGuid(Guid id)
        {
            throw new NotImplementedException();
        }

        public override Location GetById(int id)
        {
            return AfricanFarmerCommoditiesDBContext.Locations.SingleOrDefault(p => p.LocationId == id);
        }

        public override bool Update(Location toUpdate)
        {
            try
            {
                var locations = GetById(toUpdate.LocationId);
                locations.AddressId = toUpdate.AddressId;
                locations.Country = toUpdate.Country;
                locations.DateUpdated = DateTime.Now;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}

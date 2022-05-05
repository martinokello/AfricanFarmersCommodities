using AfricanFarmersCommodities.Domain;
using SimbaToursEastAfrica.Services.RepositoryServices.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AfricanFarmersCommodities.Services.RepositoryServices.Concretes
{
    public class VehicleCapacityRepository : AbstractRepository<VehicleCapacity>
    {
        public override bool Delete(VehicleCapacity toDelete)
        {
            try
            {
                toDelete = GetById(toDelete.VehicleCapacityId);
                AfricanFarmerCommoditiesDBContext.Remove(toDelete);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public override VehicleCapacity GetByGuid(Guid id)
        {
            throw new NotImplementedException();
        }

        public override VehicleCapacity GetById(int id)
        {
            return AfricanFarmerCommoditiesDBContext.VehicleCapacities.SingleOrDefault(p => p.VehicleCapacityId == id);
        }

        public override bool Update(VehicleCapacity toUpdate)
        {
            try
            {
                var temp = GetById(toUpdate.VehicleCapacityId);
                temp.Description = toUpdate.Description;
                temp.VechicleCapacityUnitsName = toUpdate.VechicleCapacityUnitsName;
                temp.DateUpdated = DateTime.Now;
                temp.VechicleCapacity = toUpdate.VechicleCapacity;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}

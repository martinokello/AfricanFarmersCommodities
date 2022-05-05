using AfricanFarmersCommodities.Domain;
using SimbaToursEastAfrica.Services.RepositoryServices.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimbaToursEastAfrica.Services.RepositoryServices.Concretes
{
    public class VehicleRepository : AbstractRepository<Vehicle>
    {
        public override bool Delete(Vehicle toDelete)
        {
            try
            {
                toDelete = GetById(toDelete.VehicleId);
                AfricanFarmerCommoditiesDBContext.Remove(toDelete);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public override Vehicle GetByGuid(Guid id)
        {
            throw new NotImplementedException();
        }

        public override Vehicle GetById(int id)
        {
            return AfricanFarmerCommoditiesDBContext.Vehicles.SingleOrDefault(p => p.VehicleId == id);
        }

        public override bool Update(Vehicle toUpdate)
        {
            try
            {
                var vehicle = GetById(toUpdate.VehicleId);
                vehicle.DateUpdated = DateTime.Now;
                vehicle.VehicleCapacityId = toUpdate.VehicleCapacityId;
                vehicle.VehicleCapacityId = toUpdate.VehicleCapacityId;
                vehicle.CompanyId = toUpdate.CompanyId;
                vehicle.VehicleRegistration = toUpdate.VehicleRegistration;
                vehicle.InGoodCondition = toUpdate.InGoodCondition;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}

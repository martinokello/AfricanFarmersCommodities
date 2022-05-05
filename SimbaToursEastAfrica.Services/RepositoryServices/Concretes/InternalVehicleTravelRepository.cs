using SimbaToursEastAfrica.Domain.Models;
using SimbaToursEastAfrica.Services.RepositoryServices.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimbaToursEastAfrica.Services.RepositoryServices.Concretes
{
    public class InternalVehicleTravelRepository : AbstractRepository<InternalVehicleTravel>
    {
        public override bool Delete(InternalVehicleTravel toDelete)
        {
            try
            {
                toDelete = SimbaToursEastAfricaDbContext.InternalVehicleTravels.SingleOrDefault(p => p.InternalVehicleTravelId == toDelete.InternalVehicleTravelId);
                SimbaToursEastAfricaDbContext.Remove(toDelete);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public override InternalVehicleTravel GetById(int id)
        {
            return SimbaToursEastAfricaDbContext.InternalVehicleTravels.ToList().SingleOrDefault(p => p.InternalVehicleTravelId == id);
        }

        public override bool Update(InternalVehicleTravel toUpdate)
        {
            try
            {
                var internalVehicleTravel = SimbaToursEastAfricaDbContext.InternalVehicleTravels.ToList().SingleOrDefault(p => p.InternalVehicleTravelId == toUpdate.InternalVehicleTravelId);
                internalVehicleTravel.VehicleAllocated = toUpdate.VehicleAllocated;
                internalVehicleTravel.VehicleCosts = toUpdate.VehicleCosts;
                internalVehicleTravel.VehicleId = toUpdate.VehicleId;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}

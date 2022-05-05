using SimbaToursEastAfrica.Domain.Models;
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
                toDelete = SimbaToursEastAfricaDbContext.Vehicles.SingleOrDefault(p => p.VehicleId == toDelete.VehicleId);
                SimbaToursEastAfricaDbContext.Remove(toDelete);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public override Vehicle GetById(int id)
        {
            return SimbaToursEastAfricaDbContext.Vehicles.ToList().SingleOrDefault(p => p.VehicleId == id);
        }

        public override bool Update(Vehicle toUpdate)
        {
            try
            {
                var vehicle = SimbaToursEastAfricaDbContext.Vehicles.ToList().SingleOrDefault(p => p.VehicleId == toUpdate.VehicleId);
                vehicle.ActualNumberOfPassengersAllocated = toUpdate.ActualNumberOfPassengersAllocated;
                vehicle.MaxNumberOfPassengers = toUpdate.MaxNumberOfPassengers;
                vehicle.VehicleType = toUpdate.VehicleType;
                vehicle.VehicleRegistration = toUpdate.VehicleRegistration;
                vehicle.TourClient = toUpdate.TourClient;
                vehicle.TourClientId = toUpdate.TourClientId;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}

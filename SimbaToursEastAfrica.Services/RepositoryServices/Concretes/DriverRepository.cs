using SimbaToursEastAfrica.Domain.Models;
using SimbaToursEastAfrica.Services.RepositoryServices.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimbaToursEastAfrica.Services.RepositoryServices.Concretes
{
    public class DriverRepository : AbstractRepository<Driver>
    {
        public override bool Delete(Driver toDelete)
        {
            try
            {
                toDelete = SimbaToursEastAfricaDbContext.Drivers.SingleOrDefault(p => p.DriverId == toDelete.DriverId);
                SimbaToursEastAfricaDbContext.Remove(toDelete);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public override Driver GetById(int id)
        {
            return SimbaToursEastAfricaDbContext.Drivers.ToList().SingleOrDefault(p => p.DriverId == id);
        }

        public override bool Update(Driver toUpdate)
        {
            try
            {
                var driver = SimbaToursEastAfricaDbContext.Drivers.ToList().SingleOrDefault(p => p.DriverId == toUpdate.DriverId);
                driver.FirstName = toUpdate.FirstName;
                driver.LastName = toUpdate.LastName;
                driver.Schedules = toUpdate.Schedules;
                driver.Vehicle = toUpdate.Vehicle;
                driver.VehicleId = toUpdate.VehicleId;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}

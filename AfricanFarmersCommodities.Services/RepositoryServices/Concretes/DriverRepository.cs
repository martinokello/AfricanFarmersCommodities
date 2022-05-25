using AfricanFarmersCommodities.Domain;
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
                var driver = GetById(toDelete.DriverId);
                AfricanFarmerCommoditiesDBContext.Remove(driver);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public override Driver GetByGuid(Guid id)
        {
            throw new NotImplementedException();
        }

        public override Driver GetById(int id)
        {
            return AfricanFarmerCommoditiesDBContext.Drivers.SingleOrDefault(p => p.DriverId == id);
        }

        public override bool Update(Driver toUpdate)
        {
            try
            {
                var driver = GetById(toUpdate.DriverId);
                driver.FirstName = toUpdate.FirstName;
                driver.LastName = toUpdate.LastName;
                driver.TransportScheduleId = toUpdate.TransportScheduleId;
                driver.DateUpdated = DateTime.Now;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}

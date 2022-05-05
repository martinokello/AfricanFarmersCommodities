using AfricanFarmersCommodities.Domain;
using SimbaToursEastAfrica.Services.RepositoryServices.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfricanFarmersCommodities.Services.RepositoryServices.Concretes
{
    public class TransportScheduleRepository:AbstractRepository<TransportSchedule>
    {
        public override bool Delete(TransportSchedule toDelete)
        {
            try
            {
                toDelete = GetById(toDelete.TransportScheduleId);
                AfricanFarmerCommoditiesDBContext.Remove(toDelete);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public override TransportSchedule GetByGuid(Guid id)
        {
            throw new NotImplementedException();
        }

        public override TransportSchedule GetById(int id)
        {
            return AfricanFarmerCommoditiesDBContext.TransportSchedules.SingleOrDefault(p => p.TransportScheduleId == id);
        }

        public override bool Update(TransportSchedule toUpdate)
        {
            try
            {
                var transportSchedule = this.GetById(toUpdate.TransportScheduleId);
                transportSchedule.DestinationLocationId = toUpdate.DestinationLocationId;
                transportSchedule.DateUpdated = DateTime.Now;
                transportSchedule.OriginLocationId = toUpdate.OriginLocationId;
                transportSchedule.DateStartFromOrigin = toUpdate.DateStartFromOrigin;
                transportSchedule.DateEndAtDestination = toUpdate.DateEndAtDestination;
                transportSchedule.Description = toUpdate.Description;
                transportSchedule.TransportPricingId = toUpdate.TransportPricingId;
                transportSchedule.TransportScheduleName = toUpdate.TransportScheduleName;
                transportSchedule.VehicleId = toUpdate.VehicleId;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}

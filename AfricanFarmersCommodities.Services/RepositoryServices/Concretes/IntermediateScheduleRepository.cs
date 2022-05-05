using AfricanFarmersCommodities.Domain;
using SimbaToursEastAfrica.Services.RepositoryServices.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimbaToursEastAfrica.Services.RepositoryServices.Concretes
{
    public class IntermediateScheduleRepository : AbstractRepository<IntermediateSchedule>
    {
        public override bool Delete(IntermediateSchedule toDelete)
        {
            try
            {
                toDelete = GetById(toDelete.IntermediateScheduleId);
                AfricanFarmerCommoditiesDBContext.Remove(toDelete);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public override IntermediateSchedule GetByGuid(Guid id)
        {
            throw new NotImplementedException();
        }

        public override IntermediateSchedule GetById(int id)
        {
            return AfricanFarmerCommoditiesDBContext.Schedules.SingleOrDefault(p => p.IntermediateScheduleId == id);
        }

        public override bool Update(IntermediateSchedule toUpdate)
        {
            try
            {
                var intSchedule = GetById(toUpdate.IntermediateScheduleId);
                intSchedule.DestinationLocationId = toUpdate.DestinationLocationId;
                intSchedule.OriginLocationId = toUpdate.OriginLocationId;
                intSchedule.TransportScheduleId = toUpdate.TransportScheduleId;
                intSchedule.Operation = toUpdate.Operation;
                intSchedule.HasReachedFinalDestination = toUpdate.HasReachedFinalDestination;
                intSchedule.DateStartFromOrigin = toUpdate.DateStartFromOrigin;
                intSchedule.DateEndAtDestination = toUpdate.DateEndAtDestination;
                intSchedule.DateUpdated = DateTime.Now;
                intSchedule.VehicleId = toUpdate.VehicleId;
                intSchedule.DateUpdated = toUpdate.DateUpdated;
                intSchedule.IntermediateTransportScheduleName = toUpdate.IntermediateTransportScheduleName;

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}

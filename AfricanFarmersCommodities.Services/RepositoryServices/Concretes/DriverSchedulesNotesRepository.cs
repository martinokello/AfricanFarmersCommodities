using AfricanFarmersCommodities.Domain;
using SimbaToursEastAfrica.Services.RepositoryServices.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AfricanFarmersCommodities.Services.RepositoryServices.Concretes
{
    public class DriverSchedulesNotesRepository : AbstractRepository<DriverSchedulesNote>
    {
        public override bool Delete(DriverSchedulesNote toDelete)
        {
            try
            {
                toDelete = AfricanFarmerCommoditiesDBContext.DriverSchedulesNotes.SingleOrDefault(p => p.DriveScheduleNoteId == toDelete.DriveScheduleNoteId);
                AfricanFarmerCommoditiesDBContext.Remove(toDelete);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public override DriverSchedulesNote GetByGuid(Guid id)
        {
            throw new NotImplementedException();
        }

        public override DriverSchedulesNote GetById(int id)
        {
            return AfricanFarmerCommoditiesDBContext.DriverSchedulesNotes.SingleOrDefault(p => p.DriveScheduleNoteId == id);
        }

        public override bool Update(DriverSchedulesNote toUpdate)
        {
            try
            {
                var driSchNotes = GetById(toUpdate.DriveScheduleNoteId);
                driSchNotes.DriverId = toUpdate.DriverId;
                driSchNotes.TransportScheduleId = toUpdate.TransportScheduleId;
                driSchNotes.DriverNote = toUpdate.DriverNote;
                driSchNotes.IsOriginNote = toUpdate.IsOriginNote;
                driSchNotes.DateUpdated = DateTime.Now;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}

using AfricanFarmersCommodities.Domain;
using SimbaToursEastAfrica.Services.RepositoryServices.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AfricanFarmersCommodities.Services.RepositoryServices.Concretes
{
    public class TransportLogRepository : AbstractRepository<TransportLog>
    {
        public override bool Delete(TransportLog toDelete)
        {
            try
            {
                toDelete = GetById(toDelete.TransportLogId);
                AfricanFarmerCommoditiesDBContext.Remove(toDelete);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public override TransportLog GetByGuid(Guid id)
        {
            throw new NotImplementedException();
        }

        public override TransportLog GetById(int id)
        {
            return AfricanFarmerCommoditiesDBContext.TransportLogs.SingleOrDefault(p => p.TransportLogId == id);
        }

        public override bool Update(TransportLog toUpdate)
        {
            try
            {
                var transportLog = this.GetById(toUpdate.TransportLogId);
                transportLog.InvoiceId = toUpdate.InvoiceId;
                transportLog.DateUpdated = DateTime.Now;
                transportLog.TransportLogName = toUpdate.TransportLogName;
                transportLog.TransportScheduleId = toUpdate.TransportScheduleId;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}

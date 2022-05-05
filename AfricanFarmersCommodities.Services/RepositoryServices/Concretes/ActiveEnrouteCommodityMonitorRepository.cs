using AfricanFarmersCommodities.Domain;
using SimbaToursEastAfrica.Services.RepositoryServices.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AfricanFarmersCommodities.Services.RepositoryServices.Concretes
{
    public class ActiveEnrouteCommodityMonitorRepository : AbstractRepository<ActiveEnrouteCommodityMonitor>
    {
        public override bool Delete(ActiveEnrouteCommodityMonitor toDelete)
        {
            try
            {
                toDelete = AfricanFarmerCommoditiesDBContext.ActiveEnrouteCommodityMonitors.SingleOrDefault(p => p.ActiveEnrouteCommodityMonitorId == toDelete.ActiveEnrouteCommodityMonitorId);
                AfricanFarmerCommoditiesDBContext.Remove(toDelete);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public override ActiveEnrouteCommodityMonitor GetByGuid(Guid id)
        {
            throw new NotImplementedException();
        }

        public override ActiveEnrouteCommodityMonitor GetById(int id)
        {
            return AfricanFarmerCommoditiesDBContext.ActiveEnrouteCommodityMonitors.SingleOrDefault(p => p.ActiveEnrouteCommodityMonitorId == id);
        }

        public override bool Update(ActiveEnrouteCommodityMonitor toUpdate)
        {
            try
            {
                var actCommodity = GetById(toUpdate.ActiveEnrouteCommodityMonitorId);
                actCommodity.DateUpdated = DateTime.Now;
                actCommodity.TransportScheduleId = toUpdate.TransportScheduleId;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}

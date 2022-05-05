using AfricanFarmerCommodities.DataAccess;
using AfricanFarmersCommodities.Domain;
using SimbaToursEastAfrica.Services.RepositoryServices.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AfricanFarmersCommodities.Services.RepositoryServices.Concretes
{
    public class CommodityUnitRepository : AbstractRepository<CommodityUnit>
    {
        public override bool Delete(CommodityUnit toDelete)
        {
            try
            {
                toDelete = GetById(toDelete.CommodityUnitId);
                AfricanFarmerCommoditiesDBContext.Remove(toDelete);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public override CommodityUnit GetByGuid(Guid id)
        {
            throw new NotImplementedException();
        }

        public override CommodityUnit GetById(int id)
        {
            return AfricanFarmerCommoditiesDBContext.CommodityUnits.SingleOrDefault(p => p.CommodityUnitId == id);
        }

        public override bool Update(CommodityUnit toUpdate)
        {
            try
            {
                var actCommodity = GetById(toUpdate.CommodityUnitId);
                actCommodity.Description = toUpdate.Description;
                actCommodity.DateUpdated = DateTime.Now;
                actCommodity.CommodityUnitName = toUpdate.CommodityUnitName;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}

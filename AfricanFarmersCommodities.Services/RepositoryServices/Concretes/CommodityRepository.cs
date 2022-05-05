using AfricanFarmerCommodities.DataAccess;
using AfricanFarmersCommodities.Domain;
using SimbaToursEastAfrica.Services.RepositoryServices.Abstracts;
using System;
using System.Linq;

namespace AfricanFarmersCommodities.Services.RepositoryServices.Concretes
{
    public class CommodityRepository : AbstractRepository<Commodity>
    {
        public override bool Delete(Commodity toDelete)
        {
            try
            {
                toDelete = GetById(toDelete.CommodityId);
                AfricanFarmerCommoditiesDBContext.Remove(toDelete);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public override Commodity GetByGuid(Guid id)
        {
            throw new NotImplementedException();
        }

        public override Commodity GetById(int id)
        {
            return AfricanFarmerCommoditiesDBContext.Commodities.SingleOrDefault(p => p.CommodityId == id);
        }

        public override bool Update(Commodity toUpdate)
        {
            try
            {
                var actCommodity = GetById(toUpdate.CommodityId);
                actCommodity.CommodityCategoryId = toUpdate.CommodityCategoryId;
                actCommodity.FarmerId = toUpdate.FarmerId;
                actCommodity.CommodityDescription = toUpdate.CommodityDescription;
                actCommodity.CommodityName = toUpdate.CommodityName;
                actCommodity.CommodityUnitId = toUpdate.CommodityUnitId;
                actCommodity.CompanyId = toUpdate.CompanyId;
                actCommodity.Username = toUpdate.Username;
                actCommodity.CommodityUnitPrice = toUpdate.CommodityUnitPrice;
                actCommodity.DateUpdated = DateTime.Now;
                actCommodity.NumberOfUnits = toUpdate.NumberOfUnits;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}

using AfricanFarmerCommodities.DataAccess;
using AfricanFarmersCommodities.Domain;
using SimbaToursEastAfrica.Services.RepositoryServices.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AfricanFarmersCommodities.Services.RepositoryServices.Concretes
{
    public class CommodityCategoryRepository : AbstractRepository<CommodityCategory>
    {
        public override bool Delete(CommodityCategory toDelete)
        {
            try
            {
                toDelete = GetById(toDelete.CommodityCategoryId);
                AfricanFarmerCommoditiesDBContext.Remove(toDelete);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public override CommodityCategory GetByGuid(Guid id)
        {
            throw new NotImplementedException();
        }

        public override CommodityCategory GetById(int id)
        {
            return AfricanFarmerCommoditiesDBContext.CommodityCategories.SingleOrDefault(p => p.CommodityCategoryId == id);
        }

        public override bool Update(CommodityCategory toUpdate)
        {
            try
            {
                var actCommodity = GetById(toUpdate.CommodityCategoryId);
                actCommodity.CommodityCategoryName = toUpdate.CommodityCategoryName;
                actCommodity.Description = toUpdate.Description;
                actCommodity.DateUpdated = DateTime.Now;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}

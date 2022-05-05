using AfricanFarmersCommodities.Domain;
using SimbaToursEastAfrica.Services.RepositoryServices.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AfricanFarmersCommodities.Services.RepositoryServices.Concretes
{
    public class FoodHubStorageRepository : AbstractRepository<FoodHubStorage>
    {
        public override bool Delete(FoodHubStorage toDelete)
        {
            try
            {
                toDelete = GetById(toDelete.FoodHubStorageId);
                AfricanFarmerCommoditiesDBContext.Remove(toDelete);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public override FoodHubStorage GetByGuid(Guid id)
        {
            throw new NotImplementedException();
        }

        public override FoodHubStorage GetById(int id)
        {
            return AfricanFarmerCommoditiesDBContext.FoodHubStorages.SingleOrDefault(p => p.FoodHubStorageId == id);
        }

        public override bool Update(FoodHubStorage toUpdate)
        {
            try
            {
                var actCommodity = GetById(toUpdate.FoodHubStorageId);
                actCommodity.DryStorageCapacity = toUpdate.DryStorageCapacity;
                actCommodity.FoodHubStorageName = toUpdate.FoodHubStorageName;
                actCommodity.CommodityUnitId = toUpdate.CommodityUnitId;
                actCommodity.RefreigeratedStorageCapacity = toUpdate.RefreigeratedStorageCapacity;
                actCommodity.UsedDryStorageCapacity = toUpdate.UsedDryStorageCapacity;
                actCommodity.UsedRefreigeratedStorageCapacity = toUpdate.UsedRefreigeratedStorageCapacity;
                actCommodity.FoodHubId = toUpdate.FoodHubId;
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

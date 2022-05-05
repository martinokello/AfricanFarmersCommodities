using AfricanFarmersCommodities.Domain;
using SimbaToursEastAfrica.Services.RepositoryServices.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AfricanFarmersCommodities.Services.RepositoryServices.Concretes
{
    public class FoodHubRepository : AbstractRepository<FoodHub>
    {
        public override bool Delete(FoodHub toDelete)
        {
            try
            {
                toDelete = GetById(toDelete.FoodHubId);
                AfricanFarmerCommoditiesDBContext.Remove(toDelete);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public override FoodHub GetByGuid(Guid id)
        {
            throw new NotImplementedException();
        }

        public override FoodHub GetById(int id)
        {
            return AfricanFarmerCommoditiesDBContext.FoodHubs.SingleOrDefault(p => p.FoodHubId == id);
        }

        public override bool Update(FoodHub toUpdate)
        {
            try
            {
                var actCommodity = GetById(toUpdate.FoodHubId);
                actCommodity.Description = toUpdate.Description;
                actCommodity.FoodHubName = toUpdate.FoodHubName;
                actCommodity.DateUpdated = DateTime.Now;
                actCommodity.LocationId = toUpdate.LocationId;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}

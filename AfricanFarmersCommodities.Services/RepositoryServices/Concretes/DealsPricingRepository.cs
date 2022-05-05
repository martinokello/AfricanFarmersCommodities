using AfricanFarmersCommodities.Domain;
using SimbaToursEastAfrica.Services.RepositoryServices.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimbaToursEastAfrica.Services.RepositoryServices.Concretes
{
    public class DealsPricingRepository : AbstractRepository<DealsPricing>
    {
        public override bool Delete(DealsPricing toDelete)
        {
            try
            {
                toDelete = GetById(toDelete.DealsPricingId);
                AfricanFarmerCommoditiesDBContext.Remove(toDelete);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public override DealsPricing GetByGuid(Guid id)
        {
            throw new NotImplementedException();
        }

        public override DealsPricing GetById(int id)
        {
            return AfricanFarmerCommoditiesDBContext.DealsPricings.SingleOrDefault(p => p.DealsPricingId == id);
        }

        public override bool Update(DealsPricing toUpdate)
        {
            try
            {
                var DealsPricing = GetById(toUpdate.DealsPricingId);
                DealsPricing.DealName = toUpdate.DealName;
                DealsPricing.Description= toUpdate.Description;
                DealsPricing.Price = toUpdate.Price;
                DealsPricing.DateUpdated = DateTime.Now;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}

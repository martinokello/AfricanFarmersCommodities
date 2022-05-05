using SimbaToursEastAfrica.Domain.Models;
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
                toDelete = SimbaToursEastAfricaDbContext.DealsPricings.SingleOrDefault(p => p.DealsPricingId == toDelete.DealsPricingId);
                SimbaToursEastAfricaDbContext.Remove(toDelete);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public override DealsPricing GetById(int id)
        {
            return SimbaToursEastAfricaDbContext.DealsPricings.ToList().SingleOrDefault(p => p.DealsPricingId == id);
        }

        public override bool Update(DealsPricing toUpdate)
        {
            try
            {
                var DealsPricing = SimbaToursEastAfricaDbContext.DealsPricings.ToList().SingleOrDefault(p => p.DealsPricingId == toUpdate.DealsPricingId);
                DealsPricing.DealName = toUpdate.DealName;
                DealsPricing.Description= toUpdate.Description;
                DealsPricing.Price = toUpdate.Price;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}

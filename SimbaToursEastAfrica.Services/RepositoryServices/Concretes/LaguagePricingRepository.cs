using SimbaToursEastAfrica.Domain.Models;
using SimbaToursEastAfrica.Services.RepositoryServices.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimbaToursEastAfrica.Services.RepositoryServices.Concretes
{
    public class LaguagePricingRepository : AbstractRepository<LaguagePricing>
    {
        public override bool Delete(LaguagePricing toDelete)
        {
            try
            {
                toDelete = SimbaToursEastAfricaDbContext.LaguagePricings.SingleOrDefault(p => p.LaguagePricingId == toDelete.LaguagePricingId);
                SimbaToursEastAfricaDbContext.Remove(toDelete);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public override LaguagePricing GetById(int id)
        {
            return SimbaToursEastAfricaDbContext.LaguagePricings.ToList().SingleOrDefault(p => p.LaguagePricingId == id);
        }

        public override bool Update(LaguagePricing toUpdate)
        {
            try
            {
                var laguagePricing = SimbaToursEastAfricaDbContext.LaguagePricings.ToList().SingleOrDefault(p => p.LaguagePricingId == toUpdate.LaguagePricingId);
                laguagePricing.LaguageDescription = toUpdate.LaguageDescription;
                laguagePricing.LaguagePricingName = toUpdate.LaguagePricingName;
                laguagePricing.UnitLaguagePrice = toUpdate.UnitLaguagePrice;
                laguagePricing.UnitTravelDocumentPrice = toUpdate.UnitTravelDocumentPrice;
                laguagePricing.UnitMedicalPrice = toUpdate.UnitMedicalPrice;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}

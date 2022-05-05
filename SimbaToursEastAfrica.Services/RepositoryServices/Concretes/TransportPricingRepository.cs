using SimbaToursEastAfrica.Domain.Models;
using SimbaToursEastAfrica.Services.RepositoryServices.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimbaToursEastAfrica.Services.RepositoryServices.Concretes
{
    public class TransportPricingRepository:AbstractRepository<TransportPricing>
    {
        public override bool Delete(TransportPricing toDelete)
        {
            try
            {
                toDelete = SimbaToursEastAfricaDbContext.TransportPricings.SingleOrDefault(p => p.TransportPricingId == toDelete.TransportPricingId);
                SimbaToursEastAfricaDbContext.Remove(toDelete);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public override TransportPricing GetById(int id)
        {
            return SimbaToursEastAfricaDbContext.TransportPricings.ToList().SingleOrDefault(p => p.TransportPricingId == id);
        }

        public override bool Update(TransportPricing toUpdate)
        {
            try
            {
                var transportPricing = SimbaToursEastAfricaDbContext.TransportPricings.ToList().SingleOrDefault(p => p.TransportPricingId == toUpdate.TransportPricingId);
                transportPricing.FourByFourPricing = toUpdate.FourByFourPricing;
                transportPricing.TaxiPricing = toUpdate.TaxiPricing;
                transportPricing.MiniBusPricing = toUpdate.MiniBusPricing;
                transportPricing.TourBusPricing = toUpdate.TourBusPricing;
                transportPricing.PickupTruckPricing = toUpdate.PickupTruckPricing;
                transportPricing.TransportPricingName = toUpdate.TransportPricingName;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}

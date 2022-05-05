using AfricanFarmersCommodities.Domain;
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
                toDelete = GetById(toDelete.TransportPricingId);
                AfricanFarmerCommoditiesDBContext.Remove(toDelete);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public override TransportPricing GetByGuid(Guid id)
        {
            throw new NotImplementedException();
        }

        public override TransportPricing GetById(int id)
        {
            return AfricanFarmerCommoditiesDBContext.TransportPricings.SingleOrDefault(p => p.TransportPricingId == id);
        }

        public override bool Update(TransportPricing toUpdate)
        {
            try
            {
                var transportPricing = GetById(toUpdate.TransportPricingId);
                transportPricing.CarPricing = toUpdate.CarPricing;
                transportPricing.BusPricing = toUpdate.BusPricing;
                transportPricing.MiniBusPricing = toUpdate.MiniBusPricing;
                transportPricing.TruckPricing = toUpdate.TruckPricing;
                transportPricing.PickupTruckPricing = toUpdate.PickupTruckPricing;
                transportPricing.TaxiPricing = toUpdate.TaxiPricing;
                transportPricing.TrainPricing = toUpdate.TrainPricing;
                transportPricing.TramPricing = toUpdate.TramPricing;
                transportPricing.DateUpdated = DateTime.Now;
                transportPricing.Description = toUpdate.Description;
                transportPricing.ShipPricing = toUpdate.ShipPricing;
                transportPricing.AirPricing = toUpdate.AirPricing;
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

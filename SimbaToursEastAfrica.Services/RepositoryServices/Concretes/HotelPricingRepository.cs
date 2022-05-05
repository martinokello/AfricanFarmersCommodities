using SimbaToursEastAfrica.Domain.Models;
using SimbaToursEastAfrica.Services.RepositoryServices.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimbaToursEastAfrica.Services.RepositoryServices.Concretes
{
    public class HotelPricingRepository : AbstractRepository<HotelPricing>
    {
        public override bool Delete(HotelPricing toDelete)
        {
            try
            {
                toDelete = SimbaToursEastAfricaDbContext.HotelPricings.SingleOrDefault(p => p.HotelPricingId == toDelete.HotelPricingId);
                SimbaToursEastAfricaDbContext.Remove(toDelete);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public override HotelPricing GetById(int id)
        {
            return SimbaToursEastAfricaDbContext.HotelPricings.ToList().SingleOrDefault(p => p.HotelPricingId == id);
        }

        public override bool Update(HotelPricing toUpdate)
        {
            try
            {
                var hotelPricing = SimbaToursEastAfricaDbContext.HotelPricings.ToList().SingleOrDefault(p => p.HotelPricingId == toUpdate.HotelPricingId);
                hotelPricing.Description = toUpdate.Description;
                hotelPricing.Name = toUpdate.Name;
                hotelPricing.Price = toUpdate.Price;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}

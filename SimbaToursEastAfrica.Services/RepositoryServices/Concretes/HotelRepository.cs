using SimbaToursEastAfrica.Domain.Models;
using SimbaToursEastAfrica.Services.RepositoryServices.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimbaToursEastAfrica.Services.RepositoryServices.Concretes
{
    public class HotelRepository : AbstractRepository<Hotel>
    {
        public override bool Delete(Hotel toDelete)
        {
            try
            {
                toDelete = SimbaToursEastAfricaDbContext.Hotels.SingleOrDefault(p => p.HotelId == toDelete.HotelId);
                SimbaToursEastAfricaDbContext.Remove(toDelete);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public override Hotel GetById(int id)
        {
            return SimbaToursEastAfricaDbContext.Hotels.ToList().SingleOrDefault(p => p.HotelId == id);
        }

        public override bool Update(Hotel toUpdate)
        {
            try
            {
                var hotel = SimbaToursEastAfricaDbContext.Hotels.ToList().SingleOrDefault(p => p.HotelId == toUpdate.HotelId);
                hotel.HotelName = toUpdate.HotelName;
                hotel.HotelPricingId = toUpdate.HotelPricingId; ;
                hotel.Location = toUpdate.Location;
                hotel.LocationId = toUpdate.LocationId;
                hotel.HotelPricing = toUpdate.HotelPricing;
                hotel.HasMealsIncluded = toUpdate.HasMealsIncluded;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Hotel GetByNameAndLocation(int locationId, string hotelName)
        {
            return SimbaToursEastAfricaDbContext.Hotels.FirstOrDefault(p => p.LocationId == locationId && p.HotelName == hotelName);
        }
    }
}


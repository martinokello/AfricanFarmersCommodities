using SimbaToursEastAfrica.Domain.Models;
using SimbaToursEastAfrica.Services.RepositoryServices.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SimbaToursEastAfrica.Services.RepositoryServices.Concretes
{
    public class HotelBookingRepository : AbstractRepository<HotelBooking>
    {
        public override bool Delete(HotelBooking toDelete)
        {
            try
            {
                toDelete = SimbaToursEastAfricaDbContext.HotelBookings.SingleOrDefault(p => p.HotelBookingId == toDelete.HotelBookingId);
                SimbaToursEastAfricaDbContext.Remove(toDelete);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public override HotelBooking GetById(int id)
        {
            return SimbaToursEastAfricaDbContext.HotelBookings.Include("Location").Include("HotelPricing").SingleOrDefault(p => p.HotelBookingId == id);
        }

        public override bool Update(HotelBooking toUpdate)
        {
            try
            {
                var hotelBooking = SimbaToursEastAfricaDbContext.HotelBookings.ToList().SingleOrDefault(p => p.HotelBookingId == toUpdate.HotelBookingId);
                hotelBooking.AccomodationCost = toUpdate.AccomodationCost;
                hotelBooking.HasMealsIncluded = toUpdate.HasMealsIncluded;
                hotelBooking.HotelName = toUpdate.HotelName;
                hotelBooking.Location = toUpdate.Location;
                hotelBooking.LocationId = toUpdate.LocationId;
                hotelBooking.TourClientId = toUpdate.TourClientId;
                hotelBooking.TourClient = toUpdate.TourClient;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}

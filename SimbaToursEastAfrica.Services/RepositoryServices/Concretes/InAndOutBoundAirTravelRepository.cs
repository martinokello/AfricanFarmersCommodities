using SimbaToursEastAfrica.Domain.Models;
using SimbaToursEastAfrica.Services.RepositoryServices.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimbaToursEastAfrica.Services.RepositoryServices.Concretes
{
    public class InAndOutBoundAirTravelRepository : AbstractRepository<InAndOutBoundAirTravel>
    {
        public override bool Delete(InAndOutBoundAirTravel toDelete)
        {
            try
            {
                toDelete = SimbaToursEastAfricaDbContext.InAndOutBoundAirTravels.SingleOrDefault(p => p.InAndOutBoundAirTravelId == toDelete.InAndOutBoundAirTravelId);
                SimbaToursEastAfricaDbContext.Remove(toDelete);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public override InAndOutBoundAirTravel GetById(int id)
        {
            return SimbaToursEastAfricaDbContext.InAndOutBoundAirTravels.ToList().SingleOrDefault(p => p.InAndOutBoundAirTravelId == id);
        }

        public override bool Update(InAndOutBoundAirTravel toUpdate)
        {
            try
            {
                var inAndOutBoundAirTravel = SimbaToursEastAfricaDbContext.InAndOutBoundAirTravels.ToList().SingleOrDefault(p => p.InAndOutBoundAirTravelId == toUpdate.InAndOutBoundAirTravelId);
                inAndOutBoundAirTravel.CustomerLaguage = toUpdate.CustomerLaguage;
                inAndOutBoundAirTravel.DestinationId = toUpdate.DestinationId;
                inAndOutBoundAirTravel.FlightCost = toUpdate.FlightCost;
                inAndOutBoundAirTravel.FlightNumber = toUpdate.FlightNumber;
                inAndOutBoundAirTravel.FromAndToDestination = toUpdate.FromAndToDestination;
                inAndOutBoundAirTravel.HasMealsIncluded = toUpdate.HasMealsIncluded;
                inAndOutBoundAirTravel.LaguageId = toUpdate.LaguageId;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}

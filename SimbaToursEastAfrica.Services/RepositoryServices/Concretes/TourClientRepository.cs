using SimbaToursEastAfrica.Domain.Models;
using SimbaToursEastAfrica.Services.RepositoryServices.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimbaToursEastAfrica.Services.RepositoryServices.Concretes
{
    public class TourClientRepository : AbstractRepository<TourClient>
    {
        public override bool Delete(TourClient toDelete)
        {
            try
            {
                toDelete = SimbaToursEastAfricaDbContext.TourClients.SingleOrDefault(p => p.TourClientId == toDelete.TourClientId);
                SimbaToursEastAfricaDbContext.Remove(toDelete);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public override TourClient GetById(int id)
        {
            return SimbaToursEastAfricaDbContext.TourClients.ToList().SingleOrDefault(p => p.TourClientId == id);
        }

        public override bool Update(TourClient toUpdate)
        {
            try
            {
                var tourClient = SimbaToursEastAfricaDbContext.TourClients.ToList().SingleOrDefault(p => p.TourClientId == toUpdate.TourClientId);
                tourClient.ClientFirstName = toUpdate.ClientFirstName;
                tourClient.ClientLastName = toUpdate.ClientLastName;
                tourClient.GrossTotalCosts = toUpdate.GrossTotalCosts;
                tourClient.HasRequiredVisaStatus = toUpdate.HasRequiredVisaStatus;
                tourClient.HotelBookings = toUpdate.HotelBookings;
                tourClient.Nationality = toUpdate.Nationality;
                tourClient.NumberOfIndividuals = toUpdate.NumberOfIndividuals;
                tourClient.EmailAddress = toUpdate.EmailAddress;
                tourClient.PaidInstallments = toUpdate.PaidInstallments;
                tourClient.CurrentPayment = toUpdate.CurrentPayment;
                tourClient.HasFullyPaid = toUpdate.HasFullyPaid;
                tourClient.DateUpdated = toUpdate.DateUpdated;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}

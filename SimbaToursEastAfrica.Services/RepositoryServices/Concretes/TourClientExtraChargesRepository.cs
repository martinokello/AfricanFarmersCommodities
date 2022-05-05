using SimbaToursEastAfrica.Domain.Models;
using SimbaToursEastAfrica.Services.RepositoryServices.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimbaToursEastAfrica.Services.RepositoryServices.Concretes
{
    public class TourClientExtraChargesRepository : AbstractRepository<TourClientExtraCharge>
    {

        public override bool Delete(TourClientExtraCharge toDelete)
        {
            try
            {
                toDelete = SimbaToursEastAfricaDbContext.TourClientExtraCharges.SingleOrDefault(p => p.TourClientExtraChargesId == toDelete.TourClientExtraChargesId);
                SimbaToursEastAfricaDbContext.Remove(toDelete);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public override TourClientExtraCharge GetById(int id)
        {
            return SimbaToursEastAfricaDbContext.TourClientExtraCharges.ToList().SingleOrDefault(p => p.TourClientExtraChargesId == id);
        }

        public override bool Update(TourClientExtraCharge toUpdate)
        {
            try
            {
                var extraCharge = SimbaToursEastAfricaDbContext.TourClientExtraCharges.ToList().SingleOrDefault(p => p.TourClientExtraChargesId == toUpdate.TourClientExtraChargesId);
                extraCharge.ExtraCharges = toUpdate.ExtraCharges;
                extraCharge.TourClient = toUpdate.TourClient;
                extraCharge.TourClientId = toUpdate.TourClientId;
                extraCharge.Description = toUpdate.Description;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}

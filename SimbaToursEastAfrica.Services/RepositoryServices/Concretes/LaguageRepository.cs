using SimbaToursEastAfrica.Domain.Models;
using SimbaToursEastAfrica.Services.RepositoryServices.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimbaToursEastAfrica.Services.RepositoryServices.Concretes
{
    public class LaguageRepository : AbstractRepository<Laguage>
    {
        public override bool Delete(Laguage toDelete)
        {
            try
            {
                toDelete = SimbaToursEastAfricaDbContext.Laguages.SingleOrDefault(p => p.LaguageId == toDelete.LaguageId);
                SimbaToursEastAfricaDbContext.Remove(toDelete);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public override Laguage GetById(int id)
        {
            return SimbaToursEastAfricaDbContext.Laguages.ToList().SingleOrDefault(p => p.LaguageId == id);
        }

        public override bool Update(Laguage toUpdate)
        {
            try
            {
                var laguage = SimbaToursEastAfricaDbContext.Laguages.ToList().SingleOrDefault(p => p.LaguageId == toUpdate.LaguageId);
                laguage.TourClient = toUpdate.TourClient;
                laguage.TourClientId = toUpdate.TourClientId;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}

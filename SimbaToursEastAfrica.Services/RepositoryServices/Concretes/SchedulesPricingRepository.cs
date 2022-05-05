using SimbaToursEastAfrica.Domain.Models;
using SimbaToursEastAfrica.Services.RepositoryServices.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimbaToursEastAfrica.Services.RepositoryServices.Concretes
{
    public class SchedulesPricingRepository : AbstractRepository<SchedulesPricing>
    {
        public override bool Delete(SchedulesPricing toDelete)
        {
            try
            {
                toDelete = SimbaToursEastAfricaDbContext.SchedulesPricings.SingleOrDefault(p => p.SchedulesPricingId == toDelete.SchedulesPricingId);
                SimbaToursEastAfricaDbContext.Remove(toDelete);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public override SchedulesPricing GetById(int id)
        {
            return SimbaToursEastAfricaDbContext.SchedulesPricings.ToList().SingleOrDefault(p => p.SchedulesPricingId == id);
        }

        public override bool Update(SchedulesPricing toUpdate)
        {
            try
            {
                var schedulesPricing = SimbaToursEastAfricaDbContext.SchedulesPricings.ToList().SingleOrDefault(p => p.SchedulesPricingId == toUpdate.SchedulesPricingId);
                schedulesPricing.SchedulesDescription = toUpdate.SchedulesDescription;
                schedulesPricing.SchedulesPricingName = toUpdate.SchedulesPricingName;
                schedulesPricing.Price = toUpdate.Price;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}

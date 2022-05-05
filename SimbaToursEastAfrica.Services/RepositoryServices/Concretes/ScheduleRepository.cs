using SimbaToursEastAfrica.Domain.Models;
using SimbaToursEastAfrica.Services.RepositoryServices.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimbaToursEastAfrica.Services.RepositoryServices.Concretes
{
    public class ScheduleRepository : AbstractRepository<Schedule>
    {
        public override bool Delete(Schedule toDelete)
        {
            try
            {
                toDelete = SimbaToursEastAfricaDbContext.Schedules.SingleOrDefault(p => p.ScheduleId == toDelete.ScheduleId);
                SimbaToursEastAfricaDbContext.Remove(toDelete);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public override Schedule GetById(int id)
        {
            return SimbaToursEastAfricaDbContext.Schedules.ToList().SingleOrDefault(p => p.ScheduleId == id);
        }

        public override bool Update(Schedule toUpdate)
        {
            try
            {
                var schedule = SimbaToursEastAfricaDbContext.Schedules.ToList().SingleOrDefault(p => p.ScheduleId == toUpdate.ScheduleId);
                schedule.Driver = toUpdate.Driver;
                schedule.DriverId = toUpdate.DriverId;
                schedule.Itinary = toUpdate.Itinary;
                schedule.ItinaryId = toUpdate.ItinaryId;
                schedule.Location = toUpdate.Location;
                schedule.LocationId = toUpdate.LocationId;
                schedule.Operation = toUpdate.Operation;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}

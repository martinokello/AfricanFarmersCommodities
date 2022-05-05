using SimbaToursEastAfrica.Domain.Models;
using SimbaToursEastAfrica.Services.RepositoryServices.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimbaToursEastAfrica.Services.RepositoryServices.Concretes
{
    public class MealRepository : AbstractRepository<Meal>
    {
        public override bool Delete(Meal toDelete)
        {
            try
            {
                toDelete = SimbaToursEastAfricaDbContext.Meals.SingleOrDefault(p => p.MealId == toDelete.MealId);
                SimbaToursEastAfricaDbContext.Remove(toDelete);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public override Meal GetById(int id)
        {
            return SimbaToursEastAfricaDbContext.Meals.ToList().SingleOrDefault(p => p.MealId == id);
        }

        public override bool Update(Meal toUpdate)
        {
            try
            {
                var meal = SimbaToursEastAfricaDbContext.Meals.ToList().SingleOrDefault(p => p.MealId == toUpdate.MealId);
                meal.TourClient = toUpdate.TourClient;
                meal.TourClientId = toUpdate.TourClientId;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}

using SimbaToursEastAfrica.Domain.Models;
using SimbaToursEastAfrica.Services.RepositoryServices.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimbaToursEastAfrica.Services.RepositoryServices.Concretes
{
    public class MealsPricingRepository : AbstractRepository<MealPricing>
    {
        public override bool Delete(MealPricing toDelete)
        {
            try
            {
                toDelete = SimbaToursEastAfricaDbContext.MealPricings.SingleOrDefault(p => p.MealPricingId == toDelete.MealPricingId);
                SimbaToursEastAfricaDbContext.Remove(toDelete);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public override MealPricing GetById(int id)
        {
            return SimbaToursEastAfricaDbContext.MealPricings.ToList().SingleOrDefault(p => p.MealPricingId == id);
        }

        public override bool Update(MealPricing toUpdate)
        {
            try
            {
                var mealPricing = SimbaToursEastAfricaDbContext.MealPricings.ToList().SingleOrDefault(p => p.MealPricingId == toUpdate.MealPricingId);
                mealPricing.MealName = toUpdate.MealName;
                mealPricing.MealDescription = toUpdate.MealDescription;
                mealPricing.Price = toUpdate.Price;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}

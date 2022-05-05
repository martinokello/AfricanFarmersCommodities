using AfricanFarmersCommodities.Domain;
using SimbaToursEastAfrica.Services.RepositoryServices.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AfricanFarmersCommodities.Services.RepositoryServices.Concretes
{
    public class VehicleCategoryRepository : AbstractRepository<VehicleCategory>
    {
        public override bool Delete(VehicleCategory toDelete)
        {
            try
            {
                toDelete = GetById(toDelete.VehicleCategoryId);
                AfricanFarmerCommoditiesDBContext.Remove(toDelete);
                return true;
            }
            catch (Exception e)
            { 
                return false;
            }
        }

        public override VehicleCategory GetByGuid(Guid id)
        {
            throw new NotImplementedException();
        }

        public override VehicleCategory GetById(int id)
        {
            return AfricanFarmerCommoditiesDBContext.VehicleCategories.SingleOrDefault(p => p.VehicleCategoryId == id);
        }

        public override bool Update(VehicleCategory toUpdate)
        {
            try
            {
                var actCommodity = GetById(toUpdate.VehicleCategoryId);
                actCommodity.Description = toUpdate.Description;
                actCommodity.VehicleCategoryName = toUpdate.VehicleCategoryName;
                actCommodity.DateUpdated = DateTime.Now;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}

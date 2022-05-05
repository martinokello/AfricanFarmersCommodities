using AfricanFarmerCommodities.DataAccess;
using AfricanFarmersCommodities.Domain;
using SimbaToursEastAfrica.Services.RepositoryServices.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AfricanFarmersCommodities.Services.RepositoryServices.Concretes
{
    public class FarmerRepository : AbstractRepository<Farmer>
    {
        public override bool Delete(Farmer toDelete)
        {
            try
            {
                toDelete = GetById(toDelete.FarmerId);
                AfricanFarmerCommoditiesDBContext.Remove(toDelete);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public override Farmer GetByGuid(Guid id)
        {
            throw new NotImplementedException();
        }

        public override Farmer GetById(int id)
        {
            return AfricanFarmerCommoditiesDBContext.Farmers.SingleOrDefault(p => p.FarmerId == id);
        }

        public override bool Update(Farmer toUpdate)
        {
            try
            {
                var farmer = GetById(toUpdate.FarmerId);
                farmer.FarmerName = toUpdate.FarmerName;
                farmer.DateUpdated = DateTime.Now;
                farmer.AddressId = toUpdate.AddressId;
                farmer.CompanyId = toUpdate.CompanyId;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}

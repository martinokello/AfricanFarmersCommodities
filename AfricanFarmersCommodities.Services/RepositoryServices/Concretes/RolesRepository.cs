using AfricanFarmerCommodities.DataAccess;
using AfricanFarmersCommodities.Domain;
using SimbaToursEastAfrica.Services.RepositoryServices.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace AfricanFarmersCommodities.Services.RepositoryServices.Concretes
{
    public class RolesRepository : AbstractRepository<Role>
    {
        public override bool Delete(Role toDelete)
        {
            try
            {
                toDelete = GetByGuid(toDelete.RoleId);
                AfricanFarmerCommoditiesDBContext.Remove(toDelete);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public override Role GetByGuid(Guid id)
        {
            return AfricanFarmerCommoditiesDBContext.Roles.SingleOrDefault(p => p.RoleId == id);
        }

        public override Role GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override bool Update(Role toUpdate)
        {
            try
            {
                var role = GetByGuid(toUpdate.RoleId);
                role.RoleName = toUpdate.RoleName;
                
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}

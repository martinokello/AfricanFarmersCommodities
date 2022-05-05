using AfricanFarmerCommodities.DataAccess;
using AfricanFarmersCommodities.Domain;
using SimbaToursEastAfrica.Services.RepositoryServices.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AfricanFarmersCommodities.Services.RepositoryServices.Concretes
{
    public class UserInRolesRepository : AbstractRepository<UserRole>
    {
        public override bool Delete(UserRole toDelete)
        {
            try
            {
                toDelete = GetByGuid(toDelete.UserRoleId);
                AfricanFarmerCommoditiesDBContext.Remove(toDelete);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public override UserRole GetByGuid(Guid id)
        {
            return AfricanFarmerCommoditiesDBContext.UserRoles.SingleOrDefault(p => p.UserRoleId == id);
        }

        public override UserRole GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override bool Update(UserRole toUpdate)
        {
            try
            {
                var userrole = GetByGuid(toUpdate.UserRoleId);
                userrole.RoleId = toUpdate.RoleId;
                userrole.UserId = toUpdate.UserId;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}

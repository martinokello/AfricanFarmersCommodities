using AfricanFarmerCommodities.DataAccess;
using AfricanFarmersCommodities.Domain;
using SimbaToursEastAfrica.Services.RepositoryServices.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AfricanFarmersCommodities.Services.RepositoryServices.Concretes
{
    public class UserRepository : AbstractRepository<User>
    {
        public override bool Delete(User toDelete)
        {
            try
            {
                toDelete = GetByGuid(toDelete.UserId);
                AfricanFarmerCommoditiesDBContext.Remove(toDelete);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public override User GetByGuid(Guid id)
        {
            return AfricanFarmerCommoditiesDBContext.Users.SingleOrDefault(p => p.UserId == id);
        }

        public override User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override bool Update(User toUpdate)
        {
            try
            {
                var user = GetByGuid(toUpdate.UserId);
                user.FirstName = toUpdate.FirstName;
                user.FirstName = toUpdate.LastName; 
                user.FirstName = toUpdate.Email;
                user.Token = toUpdate.Token;
                user.CompanyId = toUpdate.CompanyId;
                user.IsLockedOut = toUpdate.IsLockedOut;
                user.IsActive = toUpdate.IsActive;
                user.LastLogInTime = toUpdate.LastLogInTime;
                user.MobileNumber = toUpdate.MobileNumber;
                user.Email = toUpdate.Email;
                user.Password = toUpdate.Password;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}

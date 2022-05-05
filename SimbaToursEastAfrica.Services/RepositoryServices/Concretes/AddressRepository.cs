using SimbaToursEastAfrica.Domain.Models;
using SimbaToursEastAfrica.Services.RepositoryServices.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimbaToursEastAfrica.Services.RepositoryServices.Concretes
{
    public class AddressRepository : AbstractRepository<Address>
    {
        public override bool Delete(Address toDelete)
        {
            try
            {
                toDelete = SimbaToursEastAfricaDbContext.Addresses.SingleOrDefault(p => p.AddressId == toDelete.AddressId);
                SimbaToursEastAfricaDbContext.Remove(toDelete);
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public override Address GetById(int id)
        {
            return SimbaToursEastAfricaDbContext.Addresses.ToList().SingleOrDefault(p => p.AddressId == id);
        }

        public override bool Update(Address toUpdate)
        {
            try
            {
                var address = SimbaToursEastAfricaDbContext.Addresses.ToList().SingleOrDefault(p => p.AddressId == toUpdate.AddressId);
                address.AddressLine1 = toUpdate.AddressLine1;
                address.AddressLine2 = toUpdate.AddressLine2;
                address.Country = toUpdate.Country;
                address.PhoneNumber = toUpdate.PhoneNumber;
                address.Town = toUpdate.Town;
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
    }
}

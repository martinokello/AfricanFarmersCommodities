using AfricanFarmersCommodities.Domain;
using SimbaToursEastAfrica.Services.RepositoryServices.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimbaToursEastAfrica.Services.RepositoryServices.Concretes
{
    public class ItemRepository : AbstractRepository<Item>
    {
        public override bool Delete(Item toDelete)
        {
            try
            {
                toDelete = GetById(toDelete.ItemId);
                AfricanFarmerCommoditiesDBContext.Remove(toDelete);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public override Item GetByGuid(Guid id)
        {
            throw new NotImplementedException();
        }

        public override Item GetById(int id)
        {
            return AfricanFarmerCommoditiesDBContext.Items.SingleOrDefault(p => p.ItemId == id);
        }

        public override bool Update(Item toUpdate)
        {
            try
            {
                var item = GetById(toUpdate.ItemId);
                item.ItemName = toUpdate.ItemName;
                item.ItemCost= toUpdate.ItemCost;
                item.Quantity = toUpdate.Quantity;
                item.DateUpdated = DateTime.Now;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}

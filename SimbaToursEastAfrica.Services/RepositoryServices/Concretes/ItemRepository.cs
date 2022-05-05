using SimbaToursEastAfrica.Domain.Models;
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
                toDelete = SimbaToursEastAfricaDbContext.Items.SingleOrDefault(p => p.ItemId == toDelete.ItemId);
                SimbaToursEastAfricaDbContext.Remove(toDelete);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public override Item GetById(int id)
        {
            return SimbaToursEastAfricaDbContext.Items.ToList().SingleOrDefault(p => p.ItemId == id);
        }

        public override bool Update(Item toUpdate)
        {
            try
            {
                var item = SimbaToursEastAfricaDbContext.Items.ToList().SingleOrDefault(p => p.ItemId == toUpdate.ItemId);
               
                item.ItemCost= toUpdate.ItemCost;
                item.ItemType = toUpdate.ItemType;
                item.Quantity = toUpdate.Quantity;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}

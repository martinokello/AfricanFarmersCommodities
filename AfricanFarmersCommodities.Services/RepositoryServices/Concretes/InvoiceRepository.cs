using AfricanFarmersCommodities.Domain;
using SimbaToursEastAfrica.Services.RepositoryServices.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimbaToursEastAfrica.Services.RepositoryServices.Concretes
{
    public class InvoiceRepository : AbstractRepository<Invoice>
    {
        public override bool Delete(Invoice toDelete)
        {
            try
            {
                toDelete = GetById(toDelete.InvoiceId);
                AfricanFarmerCommoditiesDBContext.Remove(toDelete);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public override Invoice GetByGuid(Guid id)
        {
            throw new NotImplementedException();
        }

        public override Invoice GetById(int id)
        {
            return AfricanFarmerCommoditiesDBContext.Invoices.SingleOrDefault(p => p.InvoiceId == id);
        }

        public override bool Update(Invoice toUpdate)
        {
            try
            {
                var invoice = GetById(toUpdate.InvoiceId);
                invoice.GrossCost = toUpdate.GrossCost;
                invoice.InvoicedItems = toUpdate.InvoicedItems;
                invoice.InvoiceName = toUpdate.InvoiceName;
                invoice.DateUpdated = DateTime.Now;
                invoice.HasFullyPaid = toUpdate.HasFullyPaid;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}

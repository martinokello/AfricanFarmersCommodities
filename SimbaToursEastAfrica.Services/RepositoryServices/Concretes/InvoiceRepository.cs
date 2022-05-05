using SimbaToursEastAfrica.Domain.Models;
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
                toDelete = SimbaToursEastAfricaDbContext.Invoices.SingleOrDefault(p => p.InvoiceId == toDelete.InvoiceId);
                SimbaToursEastAfricaDbContext.Remove(toDelete);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public override Invoice GetById(int id)
        {
            return SimbaToursEastAfricaDbContext.Invoices.ToList().SingleOrDefault(p => p.InvoiceId == id);
        }

        public override bool Update(Invoice toUpdate)
        {
            try
            {
                var invoice = SimbaToursEastAfricaDbContext.Invoices.ToList().SingleOrDefault(p => p.InvoiceId == toUpdate.InvoiceId);
                invoice.GrossCost = toUpdate.GrossCost;
                invoice.InvoicedItems = toUpdate.InvoicedItems;
                invoice.InvoiceName = toUpdate.InvoiceName;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}

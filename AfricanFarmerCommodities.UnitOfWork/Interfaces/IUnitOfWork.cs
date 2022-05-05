using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfricanFarmerCommodities.UnitOfWork.Interfaces
{
    public interface IUnitOfWork
    {
        void SaveChanges();
    }
}

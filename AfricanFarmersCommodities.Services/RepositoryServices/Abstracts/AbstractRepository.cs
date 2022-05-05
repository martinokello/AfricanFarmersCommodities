using AfricanFarmerCommodities.DataAccess;
using SimbaToursEastAfrica.Services.RepositoryServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimbaToursEastAfrica.Services.RepositoryServices.Abstracts
{
    public abstract class AbstractRepository<T> : IRepository<T> where T : class
    {
        public AfricanFarmerCommoditiesDBContext AfricanFarmerCommoditiesDBContext { get; set; }
        public abstract bool Delete(T toDelete);

        public IQueryable<T> GetAll()
        {
            return AfricanFarmerCommoditiesDBContext.Set<T>().AsQueryable<T>();
        }

        public abstract T GetById(int id);

        public abstract T GetByGuid(Guid id);
        public bool Insert(T toInsert)
        {
            try{    

                AfricanFarmerCommoditiesDBContext.Add<T>(toInsert);
                return true;
            }
            catch(Exception e){
                return false;
            }
        }

        public abstract bool Update(T toUpdate);
    }
}

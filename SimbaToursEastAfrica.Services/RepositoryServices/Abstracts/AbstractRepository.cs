using SimbaToursEastAfrica.DataAccess;
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
        public SimbaToursEastAfricaDbContext SimbaToursEastAfricaDbContext { get; set; }
        public abstract bool Delete(T toDelete);

        public IQueryable<T> GetAll()
        {
            return SimbaToursEastAfricaDbContext.Set<T>().AsQueryable<T>();
        }

        public abstract T GetById(int id);

        public bool Insert(T toInsert)
        {
            try{
                SimbaToursEastAfricaDbContext.Add<T>(toInsert);
                return true;
            }
            catch(Exception e){
                return false;
            }
        }

        public abstract bool Update(T toUpdate);
    }
}

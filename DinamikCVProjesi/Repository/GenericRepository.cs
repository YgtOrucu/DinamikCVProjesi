using DinamikCVProjesi.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DinamikCVProjesi.Repository
{
    public class GenericRepository<T> where T : class, new()
    {
        DB_UdemyAdminPanelliDinamikCVEntities cVEntities = new DB_UdemyAdminPanelliDinamikCVEntities();

        public List<T> List()
        {
            return cVEntities.Set<T>().ToList();
        }
        public void TAdd(T entity)
        {
            cVEntities.Set<T>().Add(entity);
            cVEntities.SaveChanges();
        }
        public void TDelete(T entity)
        {
            cVEntities.Set<T>().Remove(entity);
            cVEntities.SaveChanges();
        }
        public void TUpdate(T entity)
        {
        }

        public T TGetID(int id)
        {
            return cVEntities.Set<T>().Find(id);
        }
    }
}
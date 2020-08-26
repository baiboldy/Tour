using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KolesaTwo.Contexts;
using Microsoft.EntityFrameworkCore;

namespace KolesaTwo.Repositories {
    public class BaseRepository<T> :  IBaseRepository<T> where T : class, IMainTable
    {
        private readonly DbSet<T> _db;
        public BaseRepository(BaseContext context
        )
        {
            _db = context.Set<T>();
        }
        public void Create(T t)
        {
            _db.Add(t);
        }

        public void Update(T t)
        {
            _db.Update(t);
        }

        public void Delete(Guid id)
        {
            T objectToDelete = _db.Find(id);
            _db.Remove(objectToDelete);
        }

        public ICollection<T> GetByid(Guid id)
        {
           return _db.Where(x => x.id == id).ToList();
        }

        public ICollection<T> GetAll()
        {
            return _db.AsQueryable().ToList();
        }

    }
}

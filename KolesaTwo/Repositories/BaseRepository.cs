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
        public Guid Create(T t)
        {
            _db.Add(t);
            return t.Id;
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

        public T GetById(Guid id)
        {
           return _db.Where(x => x.Id == id).ToList().FirstOrDefault();
        }

        public ICollection<T> GetAll()
        {
            return _db.AsQueryable().ToList();
        }

        public bool IsExist(Guid id)
        {
	        if (id == null)
	        {
		        throw new ArgumentNullException(nameof(id));
	        }

	        return _db.Any(_ => _.Id == id);
        }
    }
}

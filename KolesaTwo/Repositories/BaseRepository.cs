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
        public async Task<Guid> Create(T t)
        {
            await _db.AddAsync(t);
            return t.Id;
        }

        public void Update(T t)
        {
            _db.Update(t);
        }

        public async Task Delete(Guid id)
        {
            T objectToDelete = await _db.FindAsync(id);
            _db.Remove(objectToDelete);
        }

        public T GetById(Guid id)
        {
           return _db.Where(x => x.Id == id).ToList().FirstOrDefault();
        }

        public ICollection<T> GetAll()
        {
            return _db.ToList();
        }

        public async Task<bool> IsExist(Guid id)
        {
	        if (id == null)
	        {
		        throw new ArgumentNullException(nameof(id));
	        }

	        return await _db.AnyAsync(_ => _.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolesaTwo.Repositories {
    public interface IBaseRepository<T>
    {
        Task<Guid> Create(T t);
        void Update(T t);
        Task Delete(Guid id);
        T GetById(Guid id);
        ICollection<T> GetAll();
        Task<bool> IsExist(Guid id);
    }
}

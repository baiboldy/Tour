using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolesaTwo.Repositories {
    public interface IBaseRepository<T>
    {
        void Create(T t);
        void Update(T t);
        void Delete(Guid id);
        ICollection<T> GetByid(Guid id);
        ICollection<T> GetAll();
    }
}

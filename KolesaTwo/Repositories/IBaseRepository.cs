using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolesaTwo.Repositories {
    public interface IBaseRepository<T>
    {
        Guid Create(T t);
        void Update(T t);
        void Delete(Guid id);
        T GetById(Guid id);
        ICollection<T> GetAll();
        bool IsExist(Guid id);
    }
}

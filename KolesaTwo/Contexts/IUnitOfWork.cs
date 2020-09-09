using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KolesaTwo.Models;
using KolesaTwo.Repositories;

namespace KolesaTwo.Contexts {
    public interface IUnitOfWork {
        IBaseRepository<Tour> Tours { get; }
        IBaseRepository<Place> Places { get; }
        IBaseRepository<Guide> Guides { get; }
        IBaseRepository<TourLink> TourLink { get; }
    }
}

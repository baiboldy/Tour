using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KolesaTwo.Models;

namespace KolesaTwo.Repositories.TourRepository {
	public interface ITourRepository : IBaseRepository<TourLink>
	{
		Task<IList<TourLink>> getByTourId(Guid tourId);
	}
}

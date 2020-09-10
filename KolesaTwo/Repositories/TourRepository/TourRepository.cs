using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using KolesaTwo.Contexts;
using KolesaTwo.Models;
using Microsoft.EntityFrameworkCore;

namespace KolesaTwo.Repositories.TourRepository {
	public class TourRepository : BaseRepository<TourLink>, ITourRepository {
		private readonly DbSet<TourLink> _db;
		private readonly BaseContext _context;
		public TourRepository(BaseContext context) : base(context) {
			_db = context.Set<TourLink>();
			_context = context;
		}

		public async Task<IList<TourLink>> getByTourId(Guid tourId)
		{
			return await _db.Where(_ => _.TourId == tourId).Include(x => x.Tour).ToListAsync();
		}
	}
}

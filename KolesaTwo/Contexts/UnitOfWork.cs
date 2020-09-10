using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KolesaTwo.Models;
using KolesaTwo.Repositories;
using KolesaTwo.Repositories.TourRepository;

namespace KolesaTwo.Contexts {
	public class UnitOfWork : IUnitOfWork, IDisposable {
		private BaseContext _context;
		private IBaseRepository<Tour> _tours;
		private IBaseRepository<Place> _places;
		private IBaseRepository<Guide> _guides;
		private ITourRepository _tourlink;

		public UnitOfWork( BaseContext context ) {
			_context = context;
		}

		public IBaseRepository<Tour> Tours {
			get { return _tours ?? ( _tours = new BaseRepository<Tour>( _context ) ); }
		}

		public IBaseRepository<Place> Places {
			get { return _places ?? ( _places = new BaseRepository<Place>( _context ) ); }
		}

		public IBaseRepository<Guide> Guides {
			get { return _guides ?? ( _guides = new BaseRepository<Guide>( _context ) ); }
		}

		public ITourRepository TourLink
		{
			get { return _tourlink ?? (_tourlink = new TourRepository(_context)); }
		}

		public void Dispose() {
			try {
				_context?.Dispose();
				GC.SuppressFinalize(this);
			} catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}

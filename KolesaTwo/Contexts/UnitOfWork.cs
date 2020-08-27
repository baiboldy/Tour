using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KolesaTwo.Models;
using KolesaTwo.Repositories;

namespace KolesaTwo.Contexts {
	public class UnitOfWork : IUnitOfWork, IDisposable {
		private BaseContext _context;
		private BaseRepository<Tour> _tours;
		private BaseRepository<Place> _places;
		private BaseRepository<Guide> _guides;

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

		public void Dispose() {
			try {
				_context.SaveChanges();
				_context?.Dispose();
				GC.SuppressFinalize(this);
			} catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}

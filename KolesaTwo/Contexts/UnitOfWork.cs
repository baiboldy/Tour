﻿using System;
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
		private BaseRepository<TourLink> _tourlink;

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

		public IBaseRepository<TourLink> TourLink
		{
			get { return _tourlink ?? (_tourlink = new BaseRepository<TourLink>(_context)); }
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

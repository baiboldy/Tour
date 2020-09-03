using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KolesaTwo.Contexts;
using KolesaTwo.Dtos;
using KolesaTwo.Models;
using Microsoft.AspNetCore.Mvc;

namespace KolesaTwo.Controllers {
	[ApiController]
	[Route( "[controller]" )]
	public class TourController : ControllerBase {
		private readonly IUnitOfWork _uow;
		private readonly IMapper _mapper;

		public TourController( IUnitOfWork uow, IMapper mapper ) {
			_uow = uow;
			_mapper = mapper;
		}


		[HttpGet]
		public IActionResult GetTour() {
			var tours = _uow.Tours.GetAll();
			return Ok( _mapper.Map<IEnumerable<TourDto>>( tours ) );
		}

		[HttpPost]
		public IActionResult CreateTour( TourForCreation tourCreation ) {
			var tour = _mapper.Map<Tour>( tourCreation );
			var result = _uow.Tours.Create( tour );
			return Ok(result);
		}

		[HttpDelete( "{id:guid}" )]
		public IActionResult DeleteTour( Guid id ) {
			_uow.Tours.Delete( id );
			return Ok();
		}

		[HttpPut( "{id:guid}" )]
		public IActionResult UpdateTour( Guid id, [FromBody] TourForCreation tourForCreation ) {
			if (!_uow.Tours.IsExist( id )) {
				return NotFound();
			}

			var tourFromRepo = _uow.Tours.GetById( id );
			if (tourFromRepo == null)
			{
				var tourToAdd = _mapper.Map<Tour>(tourForCreation);
				tourToAdd.Id = id;

				_uow.Tours.Create(tourToAdd);

				var courseToReturn = _mapper.Map<TourDto>(tourToAdd);
				return CreatedAtRoute("CreateTour", courseToReturn);
			}

			_mapper.Map(tourForCreation, tourFromRepo);
			_uow.Tours.Update(tourFromRepo);
			return NoContent();
		}
	}
}
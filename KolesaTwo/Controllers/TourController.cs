using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KolesaTwo.Contexts;
using KolesaTwo.Dtos;
using KolesaTwo.Dtos.Tour;
using KolesaTwo.Models;
using KolesaTwo.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KolesaTwo.Controllers {
	[ApiController]
	[Route( "[controller]" )]
	public class TourController : ControllerBase {
		private readonly IUnitOfWork _uow;
		private readonly IMapper _mapper;
		private readonly ITourService _tourService;

		public TourController( IUnitOfWork uow, IMapper mapper, ITourService tourService ) {
			_uow = uow;
			_mapper = mapper;
			_tourService = tourService;
		}


		[HttpGet("{id:guid}")]
		public async Task<IActionResult> GetTour(Guid id)
		{
			var tours = await _uow.TourLink.getByTourId(id);
			return Ok(_mapper.Map<IEnumerable<TourLinkDto>>(tours));
		}

		[HttpPost]
		public async Task<IActionResult> CreateTour( TourForCreation tourCreation ) {
			await _tourService.SaveTour(tourCreation);
			return Ok();
		}

		[HttpDelete( "{id:guid}" )]
		public IActionResult DeleteTour( Guid id ) {
			_uow.Tours.Delete( id );
			return Ok();
		}

		[HttpPut( "{id:guid}" )]
		public async Task<IActionResult> UpdateTour( Guid id, [FromBody] TourDto tourForCreation ) {
			if (!_uow.Tours.IsExist( id ).Result) {
				return NotFound();
			}

			var tourFromRepo = _uow.Tours.GetById( id );
			if (tourFromRepo == null)
			{
				var tourToAdd = _mapper.Map<Tour>(tourForCreation);
				tourToAdd.Id = id;

				await _uow.Tours.Create(tourToAdd);

				var courseToReturn = _mapper.Map<TourDto>(tourToAdd);
				return CreatedAtRoute("CreateTour", courseToReturn);
			}

			_mapper.Map(tourForCreation, tourFromRepo);
			_uow.Tours.Update(tourFromRepo);
			return NoContent();
		}
	}
}
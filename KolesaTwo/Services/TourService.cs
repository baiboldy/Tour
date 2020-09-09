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

namespace KolesaTwo.Services {
	public class TourService : ITourService {
		private readonly IUnitOfWork _uow;
		private readonly IMapper _mapper;

		public TourService(IUnitOfWork uow, IMapper mapper)
		{
			_uow = uow;
			_mapper = mapper;
		}


		public async Task SaveTour( TourForCreation tourLinkDto )
		{
			var tour = _mapper.Map<Tour>( tourLinkDto.TourDto);
			var tourId = await _uow.Tours.Create(tour);
			foreach (var guideId in tourLinkDto.GuideIds)
			{
				var tourLink = new TourLink() {
					TourId = tourId,
					PlaceId = tourLinkDto.PlaceId,
					GuideId = guideId
				};
				await _uow.TourLink.Create(tourLink);
			}


		}
	}
}

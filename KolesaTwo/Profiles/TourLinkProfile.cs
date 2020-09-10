using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KolesaTwo.Dtos;
using KolesaTwo.Dtos.Tour;
using KolesaTwo.Models;

namespace KolesaTwo.Profiles {
	public class TourLinkProfile : Profile{
		public TourLinkProfile()
		{
			CreateMap<TourLink, TourLinkDto>();
			CreateMap<TourLinkDto, TourLink>();
		}
	}
}

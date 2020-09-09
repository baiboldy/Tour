using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KolesaTwo.Dtos;
using KolesaTwo.Models;

namespace KolesaTwo.Profiles {
	public class TourProfile : Profile {
		public TourProfile()
		{
			CreateMap<Tour, TourDto>();
			CreateMap<TourDto, Tour>();
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KolesaTwo.Dtos;
using KolesaTwo.Dtos.Tour;

namespace KolesaTwo.Services.Interfaces {
	public interface ITourService
	{
		Task SaveTour( TourForCreation tourDto );
	}
}

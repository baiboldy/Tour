using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KolesaTwo.Contexts;
using KolesaTwo.Dtos;
using KolesaTwo.Models;
using Microsoft.AspNetCore.Mvc;

namespace KolesaTwo.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class TourController : ControllerBase
    {

        private readonly IUnitOfWork _uow;

        public TourController(IUnitOfWork uow)
        {
            _uow = uow;
        }


        [HttpGet]
        public IActionResult GetTour()
        {
            var tours = _uow.Tours.GetAll().Select(_ => new TourDto
            {
                Name = _.name,
                DateFrom = _.dateFrom,
                DateTo = _.dateTo,
                PeopleLimit = _.peopleLimit
            });
            return Ok(tours);
        }

        [HttpPost]
        public IActionResult CreateTour(TourForCreation tourCreation)
        {
            var tourdto = new Tour()
            {
                name = tourCreation.Name,
                dateFrom = tourCreation.DateFrom,
                dateTo = tourCreation.DateTo,
                places = tourCreation.places,
                guides = tourCreation.guides
            };
            _uow.Tours.Create(tourdto);
            return Ok();
        }
    }
}
using AutoMapper;
using KolesaTwo.Contexts;
using KolesaTwo.Dtos;
using KolesaTwo.Models;
using Microsoft.AspNetCore.Mvc;

namespace KolesaTwo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GuideController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        public GuideController(IMapper mapper, IUnitOfWork uow)
        {
            _uow = uow;
            _mapper = mapper;

        }

        [HttpGet]
        public IActionResult GetTour()
        {
            var guides = _uow.Guides.GetAll();
            return Ok(_mapper.Map<GuideForCreation>(guides));
        }

        [HttpPost]
        public IActionResult CreateTour([FromBody] GuideForCreation guide)
        {
            var guideMapped = _mapper.Map<Guide>(guide);
            _uow.Guides.Create(guideMapped);
            return Ok();
        } 
    }
}
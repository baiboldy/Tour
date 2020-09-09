using KolesaTwo.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace KolesaTwo.Repositories
{
    [ApiController]
    [Route("[controller]")]
    public class TourRepository : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        public TourRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        
    }
}
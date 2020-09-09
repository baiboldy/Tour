using AutoMapper;
using KolesaTwo.Dtos;
using KolesaTwo.Models;

namespace KolesaTwo.Profiles
{
    public class GuideProfile : Profile
    {
        public GuideProfile()
        {
            CreateMap<GuideDto, Guide>();
        }
    }
}
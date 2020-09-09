using System;
using KolesaTwo.Contexts;

namespace KolesaTwo.Dtos
{
    public class GuideDto
    {
        public string Name {get; set;}
        public int ExperienceCount {get; set;}
        public Guid TourId {get; set;}
    }
}
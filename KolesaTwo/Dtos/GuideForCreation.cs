using System;
using KolesaTwo.Contexts;

namespace KolesaTwo.Dtos
{
    public class GuideForCreation
    {
        public string Name {get; set;}
        public int ExperienceCount {get; set;}
        public Guid TourId {get; set;}
    }
}
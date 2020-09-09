using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using KolesaTwo.Contexts;

namespace KolesaTwo.Models {
    public class Tour : IMainTable
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(500)]
        public string Name { get; set; }
        [Required]
        public DateTime DateFrom { get; set; }
        [Required]
        public DateTime DateTo { get; set; }
        public int PeopleLimit { get; set; }
        [ForeignKey( "GuideId" )]
        public virtual Guide Guide { get; set; }
        public Guid? GuideId { get; set; }
        [ForeignKey( "PlaceId" )]
        public virtual Place Place { get; set; }
        public Guid? PlaceId { get; set; }
    }
}

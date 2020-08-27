using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using KolesaTwo.Contexts;

namespace KolesaTwo.Models {
    public class Place : IMainTable
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(500)]
        public string Name { get; set; }
        [ForeignKey( "TourId" )]
        public Tour Tour { get; set; }
        public Guid TourId { get; set; }
    }
}

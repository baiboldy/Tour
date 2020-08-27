using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public ICollection<Place> Places { get; set; }
        [Required]
        public DateTime DateFrom { get; set; }
        [Required]
        public DateTime DateTo { get; set; }
        public int PeopleLimit { get; set; }
        public ICollection<Guide> Guides { get; set; }
    }
}

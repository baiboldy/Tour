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
        public Guid id { get; set; }
        [Required]
        [MaxLength(500)]
        public string name { get; set; }
        public ICollection<Place> places { get; set; }
        [Required]
        public DateTime dateFrom { get; set; }
        [Required]
        public DateTime dateTo { get; set; }
        public int peopleLimit { get; set; }
        public ICollection<Guide> guides { get; set; }
    }
}

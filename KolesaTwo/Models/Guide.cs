using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using KolesaTwo.Contexts;

namespace KolesaTwo.Models {
    public class Guide : IMainTable
    {
        [Key]
        public Guid id { get; set; }
        [Required]
        [MaxLength(500)]
        public string name { get; set; }
        public int experienceCount { get; set; }
        [ForeignKey("tourId")]
        public Tour tour { get; set; }
        public Guid tourId { get; set; }
    }
}

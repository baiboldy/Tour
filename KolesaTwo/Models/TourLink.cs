using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using KolesaTwo.Contexts;

namespace KolesaTwo.Models {
	public class TourLink : IMainTable {
		[Key]
		public Guid Id { get; set; }
		[ForeignKey("GuideId")]
		public virtual Guide Guide { get; set; }
		public Guid? GuideId { get; set; }
		[ForeignKey("PlaceId")]
		public virtual Place Place { get; set; }
		public Guid? PlaceId { get; set; }
		[ForeignKey("TourId")]
		[Required]
		public virtual Tour Tour { get; set; }
		public Guid? TourId { get; set; }
	}
}

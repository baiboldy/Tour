using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KolesaTwo.Models;

namespace KolesaTwo.Dtos.Tour {
	public class TourLinkDto {
		public Guide Guide { get; set; }
		public Guid? GuideId { get; set; }
		public Place Place { get; set; }
		public Guid? PlaceId { get; set; }
		public TourDto Tour { get; set; }
		public Guid? TourId { get; set; }
	}
}

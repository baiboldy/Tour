using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolesaTwo.Dtos.Tour {
	public class TourForCreation {
		public TourDto TourDto { get; set; }
		public IList<Guid> GuideIds { get; set; }
		public Guid PlaceId { get; set; }
	}
}

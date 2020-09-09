using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KolesaTwo.Models;

namespace KolesaTwo.Dtos.Forms {
	public class TourLinkCreation {
		public TourDto Tour { get; set; }
		public IList<Guid> Guides { get; set; }
		public IList<Guid> Places { get; set; }

	}
}

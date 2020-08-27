using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KolesaTwo.Models;

namespace KolesaTwo.Dtos {
    public class TourForCreation {
        public string Name { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int PeopleLimit { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Hotel:BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string HotelType { get; set; }
        public decimal Price { get; set; }

        public string Details { get; set; }
        public int LocationId { get; set; }
        public string Address { get; set; }
        public int RatingId { get; set; }

        public string NearestLoc1 { get; set; }
        public string NearestLoc2 { get; set; }
        public string Image { get; set; }
    }
}

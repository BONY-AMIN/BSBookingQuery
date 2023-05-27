using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.ViewModel
{
    public class HotelViewModel:BaseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Hotel Type")]
        public string HotelType { get; set; }
        public decimal Price { get; set; }
        
        public string Details { get; set; }
        public int LocationId { get; set; }
        [Display(Name = "Location")]
        public string? LocationNm { get; set; }
        public string Address { get; set; }
        public int RatingId { get; set; }
        [Display(Name = "Rating")]
        public string? RatingNm { get; set; }
        
        public string NearestLoc1 { get; set; }
        public string NearestLoc2 { get; set; }
        public string Image { get; set; }
        
        //comment
        public string Title { get; set; }
        public string Comments { get; set; }
        public int HotelId { get; set; }
        [Display(Name = "Author")]
        public string CommentorName { get; set; }
        public List<CommentList> commentLists { get; set; }
    }
    public class CommentList
    {
        public string Title { get; set; }
        public string Comments { get; set; }
        
        [Display(Name = "Author")]
        public string CommentorName { get; set; }

    }
}

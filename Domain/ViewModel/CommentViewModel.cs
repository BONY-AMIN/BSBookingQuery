using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.ViewModel
{
    public class CommentViewModel:BaseViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Comments { get; set; }
        public int HotelId { get; set; }
        [Display(Name = "Author")]
        public string CommentorName { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Comment:BaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Comments { get; set; }
        public int HotelId { get; set; }
        public string CommentorName { get; set; }
    }
}

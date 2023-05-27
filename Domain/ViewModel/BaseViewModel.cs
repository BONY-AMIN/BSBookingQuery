using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModel
{
    public class BaseViewModel
    {
        public string ModifiedBy { get; set; } = "Admin";
        public DateTime? LastModifiedDate { get; set; } = DateTime.Now;
        public bool? IsActive { get; set; } = true;
        public int Status { get; set; } = 0;
    }
}

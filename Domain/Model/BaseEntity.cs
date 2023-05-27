using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class BaseEntity
    {
        public string? ModifiedBy { get; set; }
        [Column(TypeName = "datetime")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? LastModifiedDate { get; set; }
        [DefaultValue(true)]
        public bool? IsActive { get; set; }
        public int Status { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Application.Models
{
    public class BaseEntityModel
    {
   
        public int Id { get; set; }
        public int? CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public int? UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }
        public bool? Deleted { get; set; }
        public bool? IsSelected { get; set; }
        public bool? IsDefault { get; set; }
    }
}

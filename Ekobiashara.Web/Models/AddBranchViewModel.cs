using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ekobiashara.Web.Models
{
    public class AddBranchViewModel
    {
        [Required]
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string PhysicalAddress { get; set; }
        public string PostalAddress { get; set; }
        public string Email { get; set; }
        [Required]
        public long BusinessId { get; set; }
    }
}



using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ekobiashara.Web.Models
{
    public class AddtaxesViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Rate { get; set; }
        [Required]
        public long BusinessId { get; set; }
    }
}

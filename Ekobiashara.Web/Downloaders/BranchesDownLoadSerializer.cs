using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ekobiashara.Web.Downloaders
{
    public class BranchesDownLoadSerializer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhysicalAddress { get; set; }
        public string PostalAddress { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}

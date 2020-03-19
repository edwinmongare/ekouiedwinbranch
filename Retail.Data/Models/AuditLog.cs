using System;
using System.Collections.Generic;
using System.Text;

namespace Retail.Data.Models
{
    public class AuditLog
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
    }
}

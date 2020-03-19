using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ekobiashara.Web.Downloaders
{
    public class TaxesDownloadSerializer
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Rate { get; set; }
        public DateTime DateModified { get; set; }
    }
}

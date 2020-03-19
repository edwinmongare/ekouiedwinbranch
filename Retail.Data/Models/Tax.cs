using System;
using System.Collections.Generic;
using System.Text;

namespace Retail.Data.Models
{
    public class Tax
    {
        #region Properties
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Rate { get; set; }
        public Status Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        #endregion
        #region Foreign Keys
        public long BusinessId { get; set; }
        #endregion
        #region Virtuals
        public virtual Business Business { get; set; }
        #endregion
    }
}

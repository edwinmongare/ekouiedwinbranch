using System;
using System.Collections.Generic;
using System.Text;

namespace Retail.Data.Models
{
    public class BusinessAccount
    {
        #region Properties
        public long Id { get; set; }
        public string Name { get; set; }
        #endregion
        #region Foreign Keys
        public long BusinessId { get; set; }
        #endregion
    }
}

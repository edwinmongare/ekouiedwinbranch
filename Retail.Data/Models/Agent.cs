using System;
using System.Collections.Generic;
using System.Text;

namespace Retail.Data.Models
{
    public class Agent
    {
        public long Id { get; set; }
        public string IdentityId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Region { get; set; }
        public string Code { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public long AgentGroupId { get; set; }
        public virtual AgentGroup AgentGroup { get; set; }
        public virtual ICollection<Business> Businesses { get; set; }
    }
}

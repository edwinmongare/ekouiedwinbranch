using System;
using System.Collections.Generic;
using System.Text;

namespace Retail.Data.Models
{
    public class AgentGroup
    {
        public AgentGroup()
        {
            Agents = new List<Agent>();
        }
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public virtual ICollection<Agent> Agents { get; set; }
    }
}

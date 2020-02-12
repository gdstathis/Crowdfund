using System;
using System.Collections.Generic;
using System.Text;

namespace CrowdfundCore
{
    public class Backer
    {
        public User user { get; set; }
        public string id_backer { get; set; }
        public decimal donate { get; set; }
        public ICollection<Rewards> Rewards { get; set; }
    }
}

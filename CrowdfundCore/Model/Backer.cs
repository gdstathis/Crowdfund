using System.Collections.Generic;
using CrowdfundCore.Model;

namespace CrowdfundCore
{
    public class Backer
    {
        public User user { get; set; }
        public int? id_backer { get; set; }
        public decimal donate { get; set; }
        // public ICollection<Rewards> Rewards { get; set; }
        public ICollection<Project> backers_project { get; set; }
    }
}

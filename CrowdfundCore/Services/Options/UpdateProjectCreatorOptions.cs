using System;
using System.Collections.Generic;
using System.Text;

namespace CrowdfundCore.Services.Options
{
    public class UpdateProjectCreatorOptions
    {
        //public User user { get; set; }
        public decimal TotalCost { get; set; }
        public ICollection<Rewards> Rewards { get; set; }
    }
}

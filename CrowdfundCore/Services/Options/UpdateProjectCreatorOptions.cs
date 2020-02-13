﻿using System.Collections.Generic;
using CrowdfundCore.Model;

namespace CrowdfundCore.Services.Options
{
    public class UpdateProjectCreatorOptions
    {
        //public User user { get; set; }
        public decimal TotalCost { get; set; }
        public ICollection<Rewards> Rewards { get; set; }
    }
}

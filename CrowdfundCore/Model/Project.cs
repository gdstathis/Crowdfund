using System;
using System.Collections.Generic;
using System.Text;
using CrowdfundCore.Model;

namespace CrowdfundCore
{
    public class Project
    {
        public string title { get; set; }
        public string Description { get; set; }
        public decimal budget { get; set; }
        public string nameCreator { get; set; }
        public DateTime dateCreated { get; set; }
        public DateTime deadline { get; set; }
        public string id_project { get; set; }
        public ICollection<string> rewardPackages { get; set; }
        public ProjectCategory projectCategory { get; set; }
    }
}

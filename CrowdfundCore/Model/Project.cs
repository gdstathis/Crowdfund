using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using CrowdfundCore.Model;

namespace CrowdfundCore
{
    public class Project
    {
        public string title { get; set; }
        public string Description { get; set; }
        public decimal budget { get; set; }
       // public string nameCreator { get; set; }


        public DateTime dateCreated { get; set; }
        public DateTime deadline { get; set; }
        public string id_project { get; set; }
        public User Creator { get; set; }
        public ProjectStatus status { get; set; }
        [NotMapped]
        public ICollection<Rewards> rewardPackages { get; set; }
        [NotMapped]
        public ICollection<string> comments { get; set; }
        public ProjectCategory projectCategory { get; set; }
    }
}

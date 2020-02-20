using System;
using System.Collections.Generic;
using System.Text;

namespace CrowdfundCore.Model
{
    public class ProjectRewards
    {
        /// <summary>
        /// 
        /// </summary>
        public int ProjectId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Project project { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int RewardId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Rewards Rewards { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CrowdfundCore.Services.Options
{
    public class AddRewardsOptions
    {
        public decimal Amount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
      //  public int projectId { get; set; }
        public Project project { get; set; }
    }
}

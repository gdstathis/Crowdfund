using System;
using System.Collections.Generic;
using System.Text;

namespace CrowdfundCore.Services.Options
{
   public class SearchRewardsOptions
    {
        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Project project { get; set; }

    }
}

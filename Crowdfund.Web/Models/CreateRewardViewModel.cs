using System;
using CrowdfundCore.Services.Options;


namespace Crowdfund.Web.Models
{
    public class CreateRewardViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public AddRewardsOptions AddRewardsOptions { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string ErrorText { get; set; }
       
    }
}

using System;
using CrowdfundCore.Services.Options;


namespace Crowdfund.Web.Models
{
    public class CreateRewardViewModel
    {
        public AddRewardsOptions AddRewardsOptions { get; set; }
        public string ErrorText { get; set; }
       
    }
}

using System;
using CrowdfundCore.Services.Options;


namespace Crowdfund.Web.Models
{
    public class CreateStatusViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public AddStatusOptions AddStatusOptions { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string ErrorText { get; set; }
       
    }
}

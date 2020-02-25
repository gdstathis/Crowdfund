using System;
using CrowdfundCore.Services.Options;

namespace Crowdfund.Web.Models
{
    public class SearchProjectViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public SearchProjectOptionsOptions SearchProjectOptions { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string ErrorText { get; set; }

    }
}

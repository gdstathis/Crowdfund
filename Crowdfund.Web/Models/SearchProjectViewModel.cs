using System;
using CrowdfundCore.Services.Options;

namespace Crowdfund.Web.Models
{
    public class SearchProjectViewModel
    {
        public SearchProjectOptionsOptions SearchProjectOptions { get; set; }
        public string ErrorText { get; set; }

    }
}

using System;
using CrowdfundCore.Services.Options;


namespace Crowdfund.Web.Models
{
    public class CreateStatusViewModel
    {
        public AddStatusOptions AddStatusOptions { get; set; }
        public string ErrorText { get; set; }
       
    }
}

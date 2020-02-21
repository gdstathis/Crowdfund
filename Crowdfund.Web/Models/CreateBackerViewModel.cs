using System;
using CrowdfundCore.Services.Options;


namespace Crowdfund.Web.Models
{
    public class CreateBackerViewModel
    {
        public AddBackerOptions AddBackerOptions { get; set; }
        public string ErrorText { get; set; }
       
    }
}

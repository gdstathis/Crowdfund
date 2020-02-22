using System;
using CrowdfundCore.Services.Options;

namespace Crowdfund.Web.Models
{
    public class CreateProjectCreatorViewModel
    {
        public AddProjectCreatorOptions AddProjectCreatorOptions { get; set; }
        public string ErrorText { get; set; }

    }
}

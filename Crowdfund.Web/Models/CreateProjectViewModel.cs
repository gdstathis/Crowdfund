using System;
using CrowdfundCore.Services.Options;

namespace Crowdfund.Web.Models
{
    public class CreateProjectViewModel
    {
        public AddProjectOptions CreateProjectOptions { get; set; }
        public string ErrorText { get; set; }

    }
}

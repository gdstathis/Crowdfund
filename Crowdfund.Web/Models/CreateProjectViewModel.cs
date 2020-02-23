using System;
using System.Collections.Generic;
using CrowdfundCore;
using CrowdfundCore.Services.Options;

namespace Crowdfund.Web.Models
{
    public class CreateProjectViewModel
    {
        public AddProjectOptions CreateProjectOptions { get; set; }
        public string ErrorText { get; set; }


        public List<Project> Projects { get; set; }
    }
}

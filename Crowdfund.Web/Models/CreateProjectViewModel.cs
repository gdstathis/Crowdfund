using System;
using System.Collections.Generic;
using CrowdfundCore;
using CrowdfundCore.Model;
using CrowdfundCore.Services.Options;

namespace Crowdfund.Web.Models
{
    public class CreateProjectViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public AddProjectOptions CreateProjectOptions { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ErrorText { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<Rewards> Rewards { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public List<Project> Projects { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrowdfundCore;
using CrowdfundCore.Data;

namespace Crowdfund.Web.Models
{
    public class DetailViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public Project Project { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public CrowdfundDbContext Context { get; set; }
    }
}

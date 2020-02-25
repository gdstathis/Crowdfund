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
        public Project Project { get; set; }

        public CrowdfundDbContext Context { get; set; }
    }
}

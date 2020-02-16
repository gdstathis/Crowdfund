using System;
using System.Collections.Generic;
using System.Text;

namespace CrowdfundCore.Model
{
    public class ProjectBacker
    {
        public Project Project { get; set; }
        public int ProjectId { get; set; }
        public Backer Backer { get; set; }
        public int BackerId { get; set; }
    }
}

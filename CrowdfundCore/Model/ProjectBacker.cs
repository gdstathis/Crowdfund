using System;
using System.Collections.Generic;
using System.Text;

namespace CrowdfundCore.Model
{
    public class ProjectBacker
    {
        /// <summary>
        /// 
        /// </summary>
        public Project Project { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int ProjectId { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public Backer Backer { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public int BackerId { get; set; }
    }
}

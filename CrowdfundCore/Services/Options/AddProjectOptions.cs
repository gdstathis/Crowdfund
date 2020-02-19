using System;
using CrowdfundCore.Model;

namespace CrowdfundCore.Services.Options
{
    public class AddProjectOptions
    {
        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public decimal Budget { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public ProjectCreator Creator { get; set; }
      
        /// <summary>
        /// 
        /// </summary>
        public DateTime Deadline { get; set; }

    }
}

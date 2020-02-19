using System;

namespace CrowdfundCore.Services.Options
{
    public class UpdateProjectOptions
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
        public DateTime Deadline { get; set; }
    }
}

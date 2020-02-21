using System;
using System.Collections.Generic;
using System.Text;
namespace CrowdfundCore.Services.Options
{
    public class AddStatusOptions
    {
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Project project { get; set; }        
        /// <summary>
        /// 
       /// </summary>
        public int ProjectId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String comments { get; set; }
    }
}
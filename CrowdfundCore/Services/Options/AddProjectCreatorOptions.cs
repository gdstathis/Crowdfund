using System.Collections.Generic;
using CrowdfundCore.Model;

namespace CrowdfundCore.Services.Options
{
    public class AddProjectCreatorOptions
    {
        /// <summary>
        /// 
        /// </summary>
        public string Firstname { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Lastname { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal TotalCost { get; set; }

        /// <summary>
        /// 
        /// </summary>
      //  public ICollection<Rewards> Rewards { get; set; }
    }
}

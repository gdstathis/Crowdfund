using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using CrowdfundCore.Model;

namespace CrowdfundCore
{
    public class Backer
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

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
        public decimal Donate { get; set; }

        [NotMapped]
        public ICollection<Rewards> Rewards { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [NotMapped]
        public ICollection<Project> Backers_project { get; set; }
    }
}

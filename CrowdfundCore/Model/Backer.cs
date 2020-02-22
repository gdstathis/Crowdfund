using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using CrowdfundCore.Model;

namespace CrowdfundCore
{
    public class Backer
    {
        /// <summary>
        /// Backer Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Backer firstname
        /// </summary>
        public string Firstname { get; set; }

        /// <summary>
        /// Backer lastname
        /// </summary>
        public string Lastname { get; set; }

        /// <summary>
        /// Backer email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Backer phone
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal Donate { get; set; }

        //public ICollection<Rewards> Rewards { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<Project> Backers_project { get; set; }

        public Backer()
        {
            Backers_project = new List<Project>();
        }
    }
}

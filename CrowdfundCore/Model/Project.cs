using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using CrowdfundCore.Model;

namespace CrowdfundCore
{
    public class Project
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

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
        public decimal budget { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime Deadline { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ProjectCreator Creator { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<ProjectBacker> Backers { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<Rewards> rewardPackages { get; set; }

        /// <summary>
        /// 
        /// </summary>
        
        public ICollection<Status> Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ProjectCategory ProjectCategory { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string photo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string video { get; set; }

        public Project()
        {
            DateCreated = DateTime.Today;
            Deadline = DateTime.Today.AddDays(25);
            Status = new List<Status>();
            rewardPackages = new List<Rewards>();
        }
    }
}

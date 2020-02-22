using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using CrowdfundCore.Model;

namespace CrowdfundCore
{
    public class Project
    {
        /// <summary>
        /// Project Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Project Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Project description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Project budget
        /// </summary>
        public decimal budget { get; set; }

        /// <summary>
        /// The date that project created
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// The deadline of the project
        /// </summary>
        public DateTime Deadline { get; set; }

        /// <summary>
        /// Creator of project
        /// </summary>
        public ProjectCreator Creator { get; set; }

        /// <summary>
        /// The backers of the project
        /// </summary>
        public ICollection<ProjectBacker> Backers { get; set; }

        /// <summary>
        /// Rewards of the project
        /// </summary>
        public ICollection<Rewards> rewardPackages { get; set; }

        /// <summary>
        /// Status of project
        /// </summary>
        public ICollection<Status> Status { get; set; }

        /// <summary>
        /// Project Category
        /// </summary>
        public ProjectCategory ProjectCategory { get; set; }

        /// <summary>
        /// Url photo
        /// </summary>
        public string Photo { get; set; }

        /// <summary>
        /// Url Video
        /// </summary>
        public string Video { get; set; }

        public Project()
        {
            DateCreated = DateTime.Today;
            Deadline = DateTime.Today.AddDays(25);
            Status = new List<Status>();
            rewardPackages = new List<Rewards>();
        }
    }
}

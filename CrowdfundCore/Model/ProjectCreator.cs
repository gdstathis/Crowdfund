using System.Collections.Generic;
using CrowdfundCore.Model;

namespace CrowdfundCore
{
    public class ProjectCreator
    {
        /// <summary>
        /// Id of creator
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// firstname  of project creator
        /// </summary>
        public string Firstname { get; set; }

        /// <summary>
        /// lastname of project creator
        /// </summary>
        public string Lastname { get; set; }

        /// <summary>
        /// Email of project creator
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Phone of project creator
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// List with projects of creator
        /// </summary>
        ICollection<Project> Projects { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal TotalCost { get; set; }

        public ProjectCreator()
        {
            Projects = new List<Project>();
        }
    }
}

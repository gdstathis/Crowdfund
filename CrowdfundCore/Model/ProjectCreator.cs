using System.Collections.Generic;
using CrowdfundCore.Model;

namespace CrowdfundCore
{
    public class ProjectCreator
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

using System;
using System.Collections.Generic;
using System.Text;
using CrowdfundCore.Model;

namespace CrowdfundCore.Services.Options
{
    public class SearchProjectOptionsOptions
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
       // public ProjectStatus Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ProjectCategory ProjectCategory { get; set; }

    }
}

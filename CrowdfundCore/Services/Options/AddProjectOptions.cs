using System;
using CrowdfundCore.Model;

namespace CrowdfundCore.Services.Options
{
    public class AddProjectOptions
    {
        public string title { get; set; }
        public string Description { get; set; }
        public decimal budget { get; set; }
        public User Creator { get; set; }
        public DateTime deadline { get; set; }

    }
}

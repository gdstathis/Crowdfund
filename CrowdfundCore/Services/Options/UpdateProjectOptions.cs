using System;

namespace CrowdfundCore.Services.Options
{
    public class UpdateProjectOptions
    {
        public string title { get; set; }
        public string Description { get; set; }
        public decimal budget { get; set; }
        public string nameCreator { get; set; }
        public DateTime deadline { get; set; }
    }
}

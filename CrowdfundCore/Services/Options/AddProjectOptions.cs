using System;
using CrowdfundCore.Model;

namespace CrowdfundCore.Services.Options
{
    public class AddProjectOptions
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Budget { get; set; }
       // public ProjectCreator Creator { get; set; }
      //  public DateTime Deadline { get; set; }

    }
}

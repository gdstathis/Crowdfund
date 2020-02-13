using CrowdfundCore.Model;

namespace CrowdfundCore
{
    public class ProjectCreator
    {
        public User user { get; set; }
        public decimal TotalCost { get; set; }

        public string id_creator { get; set; }
    }
}

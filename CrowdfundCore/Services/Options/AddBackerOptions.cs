using CrowdfundCore.Model;

namespace CrowdfundCore.Services.Options
{
    public class AddBackerOptions
    {
        public decimal Donate { get; set; }
        public User user { get; set; }

        public int id_backer { get; set; }
    }
}

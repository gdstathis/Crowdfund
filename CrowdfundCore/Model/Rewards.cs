namespace CrowdfundCore.Model
{
    public class Rewards
    {
        public int id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
       public Project project { get; set; }

    }
}

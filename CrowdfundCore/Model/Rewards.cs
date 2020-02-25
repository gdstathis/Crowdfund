namespace CrowdfundCore.Model
{
    public class Rewards
    {
        /// <summary>
        /// The Id of reeard
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Description of reward
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int ProjectId { get; set; }

        /// <summary>
        /// 
        /// </summary>
       public Project Project { get; set; }

    }
}

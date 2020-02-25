using System;
using System.Threading.Tasks;
using CrowdfundCore.Data;
using CrowdfundCore.Model;
using CrowdfundCore.Services;
using CrowdfundCore.Services.Options;

namespace CrowdfundCore
{
    public class Program
    {
        static  async Task Main(string[] args)
        {
            var context = new CrowdfundDbContext();
            context.Database.EnsureCreated();
            
            var BackerService = new BackerService(context);
            var ProjectService = new ProjectService(context);
            var RewardService = new RewardsService(context);
            
        }
    }
}

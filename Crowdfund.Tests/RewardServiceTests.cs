using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using CrowdfundCore.Data;
using CrowdfundCore.Model;
using CrowdfundCore.Services;
using CrowdfundCore.Services.Options;
using Xunit;
using Autofac;
using CrowdfundCore;

namespace Crowdfund.Tests
{
    public partial class RewardServiceTests : IClassFixture<CrowdfundFixture>
    {
        private readonly IRewardsService rwsv_;
        private readonly CrowdfundDbContext context;
        public RewardServiceTests(CrowdfundFixture fixture)
        {
            context = fixture.DbContext;
            rwsv_ = fixture.Container.Resolve<IRewardsService>();
        }

        [Fact]
        public async Task AddReward_Success()
        {
            var project = new Project()
            {
                Title = "sdaqsad",
                Id = 1,
                Description = "Sdasd"
            };
            var reward = new AddRewardsOptions()
            {
                Amount = 150.00M,
                Description = "N2EW REWARD",
                project=project,
            };
            var result = await rwsv_.CreateRewardsAsync(reward);
            Assert.NotNull(result);
            Assert.Equal(StatusCode.Ok, result.ErrorCode);
        }
    }
}

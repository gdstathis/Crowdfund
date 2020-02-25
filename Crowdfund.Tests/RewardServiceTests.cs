using System.Threading.Tasks;
using Autofac;
using CrowdfundCore;
using CrowdfundCore.Data;
using CrowdfundCore.Services;
using CrowdfundCore.Services.Options;
using Xunit;

namespace Crowdfund.Tests
{
    public partial class RewardServiceTests : IClassFixture<CrowdfundFixture>
    {
        private readonly IRewardsService rwsv_;
        private readonly IProjectService prsv_;
        private readonly IProjectCreatorService prsc_;
        private readonly CrowdfundDbContext context;
        public RewardServiceTests(CrowdfundFixture fixture)
        {
            context = fixture.DbContext;
            rwsv_ = fixture.Container.Resolve<IRewardsService>();
            prsv_ = fixture.Container.Resolve<IProjectService>();
            prsc_= fixture.Container.Resolve<IProjectCreatorService>();
        }

        [Fact]
        public async Task AddReward_Success()
        {
            var creator = new AddProjectCreatorOptions()
            {
                Phone = "#24324",
                Email = "Dfdsfsdf"
            };
            var creator1 = await prsc_.AddProjectCreatorAsync(creator);
            var project = new AddProjectOptions()
            {
                Budget = 23,
                Title = "SDFsdf",
                Description = "dfsdf",
                Creator=creator1.Data
            };
            var project1 = await prsv_.CreateProjectAsync(project);
            
            var reward = new AddRewardsOptions()
            {
                Amount = 150.00M,
                Description = "N2EW1133 REWARD",
                project=project1.Data,
                
            };
            var result = await rwsv_.CreateRewardsAsync(reward);
            Assert.NotNull(result);
            Assert.Equal(StatusCode.Ok, result.ErrorCode);
        }
    }
}

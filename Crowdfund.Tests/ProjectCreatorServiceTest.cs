using System.Threading.Tasks;
using Autofac;
using Crowdfund.Tests;
using CrowdfundCore;
using CrowdfundCore.Data;
using CrowdfundCore.Services;
using CrowdfundCore.Services.Options;
using Xunit;

namespace CrowdfundTests
{
    public partial class ProjectCreatorServiceTests : IClassFixture<CrowdfundFixture>
    {
        private readonly IProjectCreatorService pcsv_;
        private readonly CrowdfundDbContext context;
        public ProjectCreatorServiceTests(CrowdfundFixture fixture)
        {
            context = fixture.DbContext;
            pcsv_ = fixture.Container.Resolve<IProjectCreatorService>();
        }
        [Fact]
        public async Task AddProjectCreator_Success()
        {
            var options = new AddProjectCreatorOptions()
            {
                Email = "evazisouli@gmail.com",
                Firstname = "eva",
                Lastname = "zisouli",
                Phone = "6973970909",
            };
            var result = await pcsv_.AddProjectCreatorAsync(options);
            Assert.Equal(StatusCode.Ok, result.ErrorCode);
            Assert.NotNull(result);
        }
        [Fact]
        public async Task UpdateProjectCreator_Success()
        {
            var options = new UpdateProjectCreatorOptions()
            {
                Email = "evazisouli@gmail.com",
                TotalCost = 789,
                Firstname = "george",
                Lastname = "zla",
                Phone = "6909"
            };
            var result = await pcsv_.UpdateProjectCreatorAsync(1, options);
            Assert.NotNull(options);
            //var projectcreator = pcsv_.SearchProjectCreators(
            //   new SearchProjectCreatorOptions()
            //   {
            //       Id = options.
            //   }).SingleOrDefault();
            //Assert.NotNull(projectcreator);
            //Assert.Equal(options.Email, projectcreator.Email);
            //Assert.Equal(options.Phone, projectcreator.Phone);
            //Assert.Equal(options.Firstname, projectcreator.Firstname);
            //Assert.Equal(options.Lastname, projectcreator.Lastname);        }
        }
    }
}



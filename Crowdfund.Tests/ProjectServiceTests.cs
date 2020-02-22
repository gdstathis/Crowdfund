using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using CrowdfundCore;
using CrowdfundCore.Data;
using CrowdfundCore.Model;
using CrowdfundCore.Services;
using CrowdfundCore.Services.Options;
using Xunit;

namespace Crowdfund.Tests
{
    public partial class ProjectServiceTests : IClassFixture<CrowdfundFixture>
    {
        private readonly IProjectService prsv_;
        private readonly CrowdfundDbContext context;
        public ProjectServiceTests(CrowdfundFixture fixture)
        {
            context = fixture.DbContext;
            prsv_ = fixture.Container.Resolve<IProjectService>();
        }
        [Fact]
        public async Task AddProject_Success()
        {
            var creator = new ProjectCreator()
            {
                Email="SDfsd",
                Phone="dsfsdfds"
            };
          
            var options = new AddProjectOptions()
            {
                Title = "SAds2222ad",
                Description = "sd12111asdasd",
                Budget = 456,
                Creator=creator,
                Photo="A photo",
                Video="A video",
               
            };
            
            var result = await prsv_.CreateProject(options);
            Assert.Equal(StatusCode.Ok, result.ErrorCode);

            Assert.NotNull(result);
        }
        [Fact]
        public async Task UpdateProject_Success()
        {
            var options = new UpdateProjectOptions()
            {

                Description = "WHATEVER",
                Title = "NEW TITLE",
                //Budget = 1245

            };
            var result = await prsv_.UpdateProject(1, options);
            Assert.True(result);

        }
    }

}

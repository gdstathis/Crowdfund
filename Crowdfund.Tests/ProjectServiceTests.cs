using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using CrowdfundCore.Data;
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
        public void AddProject_Success()
        {
            var options = new AddProjectOptions()
            {
                Title = "SAds222ad",
                Description = "sd1111asdasd"
            };
            var result = prsv_.CreateProject(options);
            Assert.NotNull(result);
        }
    }
}

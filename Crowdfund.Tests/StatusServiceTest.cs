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
    public partial class StatusServiceTest : IClassFixture<CrowdfundFixture>
    {
        private readonly IStatusService stsrv_;
        private readonly CrowdfundDbContext context;
        public StatusServiceTest(CrowdfundFixture fixture)
        {
            context = fixture.DbContext;
            stsrv_ = fixture.Container.Resolve<IStatusService>();
        }

        [Fact]
        public async Task AddStatus_Success()
        {
            var project = new Project()
            {
                Title = "sdaqsad",
                Id = 1,
                Description = "Sdasd"
            };
            var status = new AddStatusOptions()
            {
                comments="DSFf",
                project=project,
                //ProjectId=1
            };
            var result = await stsrv_.AddStatusAsync(status,1);
            Assert.NotNull(result);
            Assert.Equal(StatusCode.Ok, result.ErrorCode);
        }
    }
}

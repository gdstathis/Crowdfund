using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using CrowdfundCore.Services;
using Autofac;
using CrowdfundCore.Services.Options;
using CrowdfundCore.Data;
using System.Threading.Tasks;
using System.Linq;

namespace Crowdfund.Tests
{
    public partial class BackerServiceTests :IClassFixture<CrowdfundFixture>
    {
        private readonly IBackerService bcsv_;
        
        private readonly CrowdfundDbContext context;

        public BackerServiceTests(CrowdfundFixture fixture)
        {
            context = fixture.DbContext;
            bcsv_ = fixture.Container.Resolve<IBackerService>();
        }

        [Fact]
        public async Task  AddBacker_Success()
        {
            var options = new AddBackerOptions()
            {
                Firstname = "eva",
                Lastname = "zisouli",
                Email = "evage3@gamial.com",
                Phone = "697334970909",
                Donate = 150
            };
            var result = await bcsv_.AddBackerAsync(options);
            
            Assert.NotNull(result);
            Assert.Equal(CrowdfundCore.StatusCode.Ok, result.ErrorCode);

            var backer = bcsv_.SearchBackersAsync(new SearchBackerOptionsOptions()
            {
                Email = options.Email
            }).SingleOrDefault();
            

            Assert.NotNull(backer);
        }

        [Fact]
        public async Task UpdateBacker_Success()
        {
            var options = new UpdateBackerOptions()
            {
                Firstname = "Giannis",
                Lastname = "papadopoulos",
                Email = "afafadfsdfsd",
                Phone = "fsdfsdfsdfwef3"
            };
            var success =await bcsv_.UpdateBackerOptionsAsync(1, options);
            Assert.True(success);
        }
    }
}
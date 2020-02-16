using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using CrowdfundCore.Services;
using Autofac;
using CrowdfundCore.Services.Options;
using CrowdfundCore.Data;

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
        public void AddBacker_Success()
        {
            var options = new AddBackerOptions()
            {
                Firstname = "54654444654",
                Lastname = "5465444454",
                Email = "ge54546s444dfsdfs1df",
                Phone = "5454664544455546154",
                Donate = 150
            };

            //bcsv_.AddBacker(new AddBackerOptions()
            //{
            //    Email = "fdsfsd",
            //    Firstname = "dfsfsd",
            //    Lastname = "dsfdsfsdf",
            //    Phone = "sdfdsfsdfsdfsd"
            //    ,Donate=5
            //});

            var result = bcsv_.AddBacker(options);

            Assert.NotNull(result);

        }

        [Fact]
        public void UpdateBacker_Success()
        {
            var options = new UpdateBackerOptions()
            {
                Firstname = "Giannis",
                Lastname = "papadopoulos",
                Email = "afafadfsdfsd",
                Phone = "fsdfsdfsdfwef3"
            };
            var success = bcsv_.UpdateBackerOptions(1, options);
            Assert.True(success);
        }
    }
}
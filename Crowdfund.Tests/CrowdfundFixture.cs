using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using CrowdfundCore.Data;
using CrowdfundCore;
namespace Crowdfund.Tests
{
    public class CrowdfundFixture : IDisposable
    {
        public CrowdfundDbContext DbContext { get; private set; }
        
        public ILifetimeScope Container { get; private set; }
        
        public CrowdfundFixture()
        {
            Container = ServiceRegistrator.GetContainer().BeginLifetimeScope();
            DbContext = Container.Resolve<CrowdfundDbContext>();
        }
        
        public void Dispose()
        {
            DbContext.Dispose();
            Container.Dispose();
        }
    }
}

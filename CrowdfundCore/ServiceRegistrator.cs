using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using CrowdfundCore.Services;

namespace CrowdfundCore
{
    public class ServiceRegistrator
    {
        public static IContainer GetContainer()
        {
            var builder = new ContainerBuilder();
            builder
                .RegisterType<ProjectService>()
                .InstancePerLifetimeScope()
                .As<IProjectService>();
            //builder
            //    .RegisterType<ProjectCreatorService>()
            //    .InstancePerLifetimeScope()
            //    .As<IProjectCreatorService>();
            builder
                .RegisterType<BackerService>()
                .InstancePerLifetimeScope()
                .As<IBackerService>();
            builder
                .RegisterType<ProjectCreatorService>()
                .InstancePerLifetimeScope()
                .As<IProjectCreatorService>();
            builder.
                RegisterType<CrowdfundCore.Data.CrowdfundDbContext>()
                .InstancePerLifetimeScope()
                .AsSelf();
            return builder.Build();

        }
    }
}

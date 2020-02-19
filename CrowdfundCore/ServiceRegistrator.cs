﻿using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using CrowdfundCore.Services;

namespace CrowdfundCore
{
    public class ServiceRegistrator :Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            RegisterServices(builder);
        }

        public static IContainer GetContainer()
        {
            var builder = new ContainerBuilder();

            RegisterServices(builder);

            return builder.Build();
        }
        public static void RegisterServices(ContainerBuilder builder) 
        {

            if (builder == null) {
                throw new ArgumentNullException(nameof(builder));
            }
            builder
                .RegisterType<ProjectService>()
                .InstancePerLifetimeScope()
                .As<IProjectService>();

            builder
                .RegisterType<ProjectCreatorService>()
                .InstancePerLifetimeScope()
                .As<IProjectCreatorService>();

            builder
                .RegisterType<BackerService>()
                .InstancePerLifetimeScope()
                .As<IBackerService>();

            builder
                .RegisterType<Data.CrowdfundDbContext>()
                .InstancePerLifetimeScope()
                .AsSelf();
            //builder
            //    .RegisterType<ProjectService>()
            //    .InstancePerLifetimeScope()
            //    .As<IProjectService>();
            ////builder
            ////    .RegisterType<ProjectCreatorService>()
            ////    .InstancePerLifetimeScope()
            ////    .As<IProjectCreatorService>();
            //builder
            //    .RegisterType<BackerService>()
            //    .InstancePerLifetimeScope()
            //    .As<IBackerService>();
            //builder
            //    .RegisterType<ProjectCreatorService>()
            //    .InstancePerLifetimeScope()
            //    .As<IProjectCreatorService>();
            //builder.
            //    RegisterType<CrowdfundCore.Data.CrowdfundDbContext>()
            //    .InstancePerLifetimeScope()
            //    .AsSelf();
            //return builder.Build();

        }
    }
}

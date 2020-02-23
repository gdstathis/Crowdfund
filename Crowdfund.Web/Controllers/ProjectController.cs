﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using CrowdfundCore;
using CrowdfundCore.Data;
using CrowdfundCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace Crowdfund.Web.Controllers
{
    public class ProjectController : Controller
    {
        private IContainer Container { get; set; }
        private CrowdfundDbContext context_;
        private CrowdfundCore.Services.IProjectService project_;

        public ProjectController()
        {
            Container = ServiceRegistrator.GetContainer();
            context_ = Container.Resolve<CrowdfundDbContext>();
            project_ = Container.Resolve<IProjectService>();
        }


        public async Task<IActionResult> Index()
        {
            var projectList = await context_
                .Set<Project>()
                .Take(100)
                .ToListAsync();

            return View(projectList);
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(
                  Models.CreateProjectViewModel model)
        {
            var result = await project_.CreateProjectAsync(
                model?.CreateProjectOptions);
            if (result == null) {
                model.ErrorText = "Oops. Something went wrong";
                return View(model);
            }
            return Ok();


        }
    }
}
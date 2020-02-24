using System;
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


        public IActionResult Index()
        {
            var projectList = context_
                .Set<Project>()
                .Take(100)
                .ToList();

            return View(projectList);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet("project/{id}")]
        public IActionResult Detail(int id)
        {
            var project = context_.Set<Project>()
                .SingleOrDefault(p => p.Id == id);

            return View(project);
        }
        //[HttpGet("project/{budget}")]
        //public IActionResult Search(decimal budget)
        //{
        //    var project = context_.Set<Project>()
        //        .SingleOrDefault(p => p.budget==budget);

        //    return View(project);
        //}

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] Models.CreateProjectViewModel model)
        {
            var result = await project_.CreateProjectAsync(
                model?.CreateProjectOptions);
            
            if (result == null) {
                model.ErrorText = "Oops. Something went wrong";

                return View(model);
            }

            return Json(result.Data);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using CrowdfundCore;
using CrowdfundCore.Data;
using CrowdfundCore.Services;
using CrowdfundCore.Services.Options;
using Microsoft.AspNetCore.Mvc;
using Crowdfund.Web.Extensions;

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
         
        [HttpGet]
        public IActionResult Search()
        {
            return View();
        }

        [HttpGet("project/{id}")]
        public IActionResult Detail(int id)
        {
            var project = context_.Set<Project>()
                .Where(p => p.Id == id);

            return View(project);
        }
        [HttpGet("project/title/{title}")]
        public IActionResult Detail(string title)
        {
            var project = context_.Set<Project>()
                .Where(p => p.Title.Contains(title));
            return View(project);
        }

        [HttpGet("project/budget/{budget}")]
        public IActionResult Detail(decimal budget)
        {
            var project = context_.Set<Project>()
                .Where(p => p.budget<budget);
            return View(project);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] Models.CreateProjectViewModel model)
        {
            model.CreateProjectOptions.Rewards = model.Rewards;

            var result = await project_.CreateProjectAsync(
                model?.CreateProjectOptions);
            
            if (!result.Success) {
                return result.AsStatusResult();
            }

            return Json(new {
                id = result.Data.Id
            });
        }

        [HttpPost]
        public IActionResult Search(
           [FromBody] SearchProjectOptionsOptions options)
        {
            if (options.Title==null) {
                return BadRequest("Project title is required");
            }

            var resultList = project_.SearchProjectsAsync(
                new SearchProjectOptionsOptions()
                {
                    Title = options.Title
                })
                .Select(r => new { r.Title, r.Creator.Email, r.Description, r.budget })
                .Take(100)
                .ToList();

            return Json(resultList);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Core;
using Crowdfund.Web.Extensions;
using CrowdfundCore;

using CrowdfundCore.Data;
using CrowdfundCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace Crowdfund.Web.Controllers
{
    public class SearchProjectController : Controller
    {
        private IContainer Container { get; set; }
        private CrowdfundDbContext context_;
        private IProjectService project_;

        public SearchProjectController()
        {
             Container = ServiceRegistrator.GetContainer();
             context_ = Container.Resolve<CrowdfundDbContext>();
            project_ = Container.Resolve<IProjectService>(); ;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Search()
        {
            return View();
        }
        //[HttpGet("project/{id}")]
        //public IActionResult Search(string title)
        //{
        //    var project = context_.Set<Project>()
        //        .SingleOrDefault(p => p.Title.Equals(title));

        //    return View(project);
        //}

        [HttpPost]  
        public async Task<IActionResult> Search(
                Models.SearchProjectViewModel model)
        {
            var result =  project_.SearchProjectsAsync(
                model?.SearchProjectOptions );
            if (result == null) {
                model.ErrorText = "Oops. Something went wrong";
                return View(model);
            }
            return Ok();
        }
    }
}
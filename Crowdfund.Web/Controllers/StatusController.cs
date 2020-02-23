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
    public class StatusController : Controller
    {
        private IContainer Container { get; set; }
        private CrowdfundDbContext context_;
        private IStatusService status_;

        public StatusController()
        {
             Container = ServiceRegistrator.GetContainer();
             context_ = Container.Resolve<CrowdfundDbContext>();
             status_ = Container.Resolve<IStatusService>(); ;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

      [HttpPost]  
        public async Task<IActionResult> Create(
                Models.CreateStatusViewModel model)
        {
            var result = await status_.AddStatusAsync(
                model?.AddStatusOptions,1);
            if (result == null) {
                model.ErrorText = "Oops. Something went wrong";
                return View(model);
            }
            return Ok();


        }
    }
}
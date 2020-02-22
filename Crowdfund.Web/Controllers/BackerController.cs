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
    public class BackerController : Controller
    {
        private IContainer Container { get; set; }
        private CrowdfundDbContext context_;
        private IBackerService backers_;

        public BackerController(IBackerService backers)
        {
             Container = ServiceRegistrator.GetContainer();
             context_ = Container.Resolve<CrowdfundDbContext>();
            backers_ = backers;
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
        public async Task<IActionResult> CreateBacker(
              [FromBody]   CrowdfundCore.Services.Options.AddBackerOptions options)
        {
            var result = await backers_.AddBackerAsync(
                options); 
           
            return result.AsStatusResult();


        }
    }
}
﻿using System.Threading.Tasks;
using Autofac;
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

        public BackerController()
        {
             Container = ServiceRegistrator.GetContainer();
             context_ = Container.Resolve<CrowdfundDbContext>();
             backers_ = Container.Resolve<IBackerService>(); ;
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
                Models.CreateBackerViewModel model)
        {
            var result = await backers_.AddBackerAsync(
                model?.AddBackerOptions);

            if (result == null) {
                model.ErrorText = "Oops. Something went wrong";
                return View(model);
            }

            return Ok();


        }
    }
}
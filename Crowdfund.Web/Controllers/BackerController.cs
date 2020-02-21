using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrowdfundCore.Data;
using Microsoft.AspNetCore.Mvc;

namespace Crowdfund.Web.Controllers
{
    public class BackerController : Controller
    {
        private CrowdfundDbContext context_;
        private CrowdfundCore.Services.IBackerService backers_;

        public BackerController(
            CrowdfundDbContext context,
            CrowdfundCore.Services.IBackerService backers)
        {
            context_ = context;
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
        public async Task<IActionResult> Create(
                  Models.CreateBackerViewModel model)
        {
            var result = await backers_.AddBacker(
                model?.AddBackerOptions); if (result == null)
            {
                model.ErrorText = "Oops. Something went wrong"; return View(model);
            }
            return Ok();
            //public async Task<IActionResult> SearchBackers(string email , string phone)
            //{ 

            //}


        }
    }
}
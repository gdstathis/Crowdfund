using System.Threading.Tasks;
using Autofac;
using CrowdfundCore;
using CrowdfundCore.Data;
using CrowdfundCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace Crowdfund.Web.Controllers
{
    public class RewardController : Controller
    {
        private IContainer Container { get; set; }
        private CrowdfundDbContext context_;
        private IRewardsService rewards_;

        public RewardController()
        {
             Container = ServiceRegistrator.GetContainer();
             context_ = Container.Resolve<CrowdfundDbContext>();
             rewards_ = Container.Resolve<IRewardsService>(); ;
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
                Models.CreateRewardViewModel model)
        {
            var result = await rewards_.CreateRewardsAsync(
                model?.AddRewardsOptions);
            if (result == null) {
                model.ErrorText = "Oops. Something went wrong";
                return View(model);
            }
            return Ok();


        }
    }
}
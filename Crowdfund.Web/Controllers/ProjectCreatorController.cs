using Autofac;
using CrowdfundCore;
using CrowdfundCore.Data;
using CrowdfundCore.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Crowdfund.Web.Controllers
{
    public class ProjectCreatorController : Controller
    {
        private IContainer Container { get; set; }
        private CrowdfundDbContext context_;
        private CrowdfundCore.Services.IProjectCreatorService creators_;

        public ProjectCreatorController()
        {
            Container = ServiceRegistrator.GetContainer();
            context_ = Container.Resolve<CrowdfundDbContext>();
            creators_ = Container.Resolve<IProjectCreatorService>();
        }

        [HttpGet]
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
                [FromBody] Models.CreateProjectCreatorViewModel model)
        {
            var result = await creators_.AddProjectCreatorAsync(
                model?.AddProjectCreatorOptions);

            if (result == null)
            {
                model.ErrorText = "Oops. Something went wrong";
                return View(model);
            }

            return Json(result);

        }


    }
}
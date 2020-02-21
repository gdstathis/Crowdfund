using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Crowdfund.Web.Controllers
{
    public class ProjectCreatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
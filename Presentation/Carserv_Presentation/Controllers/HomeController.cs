
using Carserv_Application;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Carserv_Presentation.Controllers
{
	public class HomeController : Controller
	{
		IExpertService _service;

        public HomeController(IExpertService service)
        {
            _service = service;
        }

        public IActionResult Index()
		{
			return View(_service.GetAll());
		}
	}
}

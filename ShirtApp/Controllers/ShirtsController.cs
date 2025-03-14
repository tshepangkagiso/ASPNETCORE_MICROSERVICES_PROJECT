using Microsoft.AspNetCore.Mvc;
using ShirtApp.Data;
using ShirtApp.Models;

namespace ShirtApp.Controllers
{
    public class ShirtsController : Controller
    {
        private readonly IWebApiExecutor webApiExecutor;
        public ShirtsController(IWebApiExecutor webApiExecutor)
        {
            this.webApiExecutor = webApiExecutor;
        }


        public async Task<IActionResult> Index()
        {
            return View(await webApiExecutor.InvokeGet<List<Shirt>>("shirts"));
        }
    }
}

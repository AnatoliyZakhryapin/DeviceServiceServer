using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace DeviceServiceServer.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

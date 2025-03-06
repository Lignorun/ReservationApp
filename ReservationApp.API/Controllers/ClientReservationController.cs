using Microsoft.AspNetCore.Mvc;

namespace ReservationApp.API.Controllers
{
    public class ClientReservationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

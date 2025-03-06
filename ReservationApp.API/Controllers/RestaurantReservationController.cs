using Microsoft.AspNetCore.Mvc;

namespace ReservationApp.API.Controllers
{
    public class RestaurantReservationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

﻿using Microsoft.AspNetCore.Mvc;

namespace ReservationApp.API.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

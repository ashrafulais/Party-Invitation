using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PartyInvite.Model;

namespace PartyInvite.Controllers
{
    [Route("[controller]")]
    public class GuestCRUDController : Controller
    {
        [HttpGet("EditGuest/{id}")]
        public ViewResult EditGuest(int id)
        {
            return View();
        }

        [HttpPost]
        public ViewResult EditGuest(GuestResponse guestResponse)
        {
            return View();
        }

    }
}
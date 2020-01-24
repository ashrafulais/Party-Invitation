using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PartyInvite.Data.Interfaces;
using PartyInvite.Data.Services;
using PartyInvite.Model;

namespace PartyInvite.Controllers
{
    [Route("[controller]")]
    public class GuestCRUDController : Controller
    {
        private readonly IGuestResponseService _guestResponseService;
        private readonly IGiftRepo _giftRepo;

        public GuestCRUDController(IGuestResponseService guestResponseService, IGiftRepo giftRepo)
        {
            _guestResponseService = guestResponseService;
            _giftRepo = giftRepo;
        }

        [HttpGet]
        public string Get()
        {
            return "Hello";
        }

        [HttpGet("GetGuest/{id}")]
        public JsonResult GetGuest(int id)
        {
            return Json(_guestResponseService
                .GetGuestResponseService(id));
        }

        [HttpGet("EditGuest/{id}")]
        public ViewResult EditGuest(int id)
        {
            return View();
        }

        [HttpPost("EditGuest/{id}")]
        public ViewResult EditGuest(GuestResponse guestResponse)
        {
            if (ModelState.IsValid)
            {
                _guestResponseService
                    .UpdateGuestService(guestResponse);
                //Repository.AddResponse(guestResponse);
                return View("Thanks", guestResponse);
            }
            else
            {
                //there is a validation error
                return View();
            }
        }

        [HttpGet("DeleteGuest/{id}")]
        public ViewResult DeleteGuest(int id)
        {
            _guestResponseService
                .DeleteGuestService(id);
            return View("~/Views/ListResponses");
        }

    }
}
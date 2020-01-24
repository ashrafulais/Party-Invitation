using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PartyInvite.Data.Interfaces;
using PartyInvite.Data.Services;
using PartyInvite.Model;
using PartyInvite.Models;

namespace PartyInvite.Controllers
{
    [Route("[controller]")]
    public class GuestCRUDController : Controller
    {
        private readonly IGuestResponseService _guestResponseService;
        private readonly IGiftService _giftService;

        public GuestCRUDController(IGuestResponseService guestResponseService, IGiftService giftService)
        {
            _guestResponseService = guestResponseService;
            _giftService = giftService;
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
            try
            {
                GuestResponse guest = _guestResponseService
                .GetGuestResponseService(id);
                ViewData["GuestInfo"] = guest;
                ViewData["GiftList"] = _giftService.GetGiftsService();
                return View();
            }
            catch(Exception e)
            {
                return View("ShowError", new ErrorViewModel { 
                    RequestId = e.Message.ToString()
                });
            }
        }

        [HttpPost("EditGuest/{id}")]
        public ViewResult EditGuest(GuestResponse guestResponse)
        {
            if (ModelState.IsValid)
            {
                _guestResponseService
                    .UpdateGuestService(guestResponse);
                //Repository.AddResponse(guestResponse);
                ViewData["Message"] = guestResponse.Name + ", Your response updated successfully.";
                return View("Message");
            }
            else
            {
                //there is a validation error
                return View("ShowError", new ErrorViewModel
                {
                    RequestId = "Failed, Updating request. Please Check input values."
                });
            }
        }

        [HttpGet("DeleteGuest/{id}")]
        public ViewResult DeleteGuest(int id)
        {
            try
            {
                _guestResponseService
                .DeleteGuestService(id);
                ViewData["Message"] = "Record Deleted";
                return View("Message");
            }
            catch (Exception e)
            {
                ViewData["Message"] = "Failed deletion: " + e.Message;
                return View("Message");
            }
        }

    }
}
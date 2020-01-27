using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PartyInvite.Data.Interfaces;
using PartyInvite.Model;
using PartyInvite.Models;

namespace PartyInvite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGreetingsService _greetingsService;
        private readonly IGuestResponseService _guestResponseService;
        private readonly IGiftService _giftService;

        public HomeController(ILogger<HomeController> logger,
            IGreetingsService greetingsService,
            IGuestResponseService guestResponseService,
            IGiftService giftService)
        {
            _logger = logger;
            _greetingsService = greetingsService;
            _guestResponseService = guestResponseService;
            _giftService = giftService;
        }

        public ViewResult Index()
        {
            var result = _greetingsService.GetStatus();

            ViewBag.Time = result["TimeNow"];
            ViewBag.Greeting = result["GreetingsMessage"];

            return View();
        }

        [HttpGet]
        public ViewResult RvspForm()
        {
            ViewData["GiftList"] = _giftService.GetGiftsService();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ViewResult RvspForm(GuestResponse guestResponse)
        {
            if (ModelState.IsValid)
            {
                _guestResponseService
                    .AddGuestService(guestResponse);

                //Repository.AddResponse(guestResponse);
                return View("Thanks", guestResponse);
            }
            else
            {
                ViewData["Message"] = "Failed :" + ModelState.IsValid;
                return View("Message");
            }
        }


        [HttpGet]
        public ViewResult ListResponses()
        {
            try
            {
                return View();
            }
            catch (Exception e)
            {
                ViewData["Message"] = "Failed Fetching:" + e.Message;
                return View("Message");
            }
        }
        

        //[HttpPost]
        //public ViewResult ListResponses(string search)
        //{
        //    try
        //    {
        //        if (!string.IsNullOrEmpty(search))
        //        {
        //            return View(
        //                _guestResponseService.SearchGuestsService(search));
        //        }
        //        else
        //        {
        //            throw new Exception("Invalid input");
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        ViewData["Message"] = "Failed searching:" + e.Message;
        //        return View("Message");
        //    }
        //}

        //[HttpPost("Paginate")]
        //public string Paginate([FromBody]Pager page)
        //{
        //    try
        //    {
        //        int pagesize = 2;

        //        if (page.pagenumber > 0)
        //        {
        //            return JsonSerializer
        //            .Serialize(_guestResponseService
        //            .PaginateService(page.pagenumber, pagesize)
        //            );
        //        }
        //        else
        //        {
        //            throw new Exception("Invalid input");
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        //["Message"] = "Failed:" + e.Message;
        //        return "Failed Msg: " + e.Message;
        //    }
        //}

        public IActionResult About()
        {
            ViewData["Message"] = "Your application About or Description page";
            return View();
        }

        public IActionResult Contact()
        {
            //ViewData["Message"] = "Your contact page";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
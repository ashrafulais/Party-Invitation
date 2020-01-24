using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
        private readonly IGiftRepo _giftRepo;

        public HomeController(ILogger<HomeController> logger,
            IGreetingsService greetingsService,
            IGuestResponseService guestResponseService,
            IGiftRepo giftRepo)
        {
            _logger = logger;
            _greetingsService = greetingsService;
            _guestResponseService = guestResponseService;
            _giftRepo = giftRepo;
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
            ViewData["GiftList"] = (IEnumerable<Gift>)_giftRepo.GetGiftsRepo();
            return View();
        }

        [HttpPost]
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
                //there is a validation error
                return View();
            }
        }

        public ViewResult ListResponses()
        {
            return View(
                _guestResponseService.GetAllGuestsService()
                );

            //return View(
            //    Repository.Responses
            //    .Where(x => x.WillAttend == true)
            //    );
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application About or Description page";
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page";
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

        [HttpGet]
        public IActionResult ShowError(string error)
        {
            //ViewBag["Error"] = error;
            return View(new ErrorViewModel { RequestId = error });
        }
    }
}
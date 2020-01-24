using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PartyInvite.Models;

namespace PartyInvite.Controllers
{
    [Route("[controller]")]
    public class ErrorController : Controller
    {
        [Route("{code}")]
        public ViewResult ShowError(int code)
        {
            return View(new ErrorViewModel
            {
                RequestId = code.ToString()
            });
        }
    }
}
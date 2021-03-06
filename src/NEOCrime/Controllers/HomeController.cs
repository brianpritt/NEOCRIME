﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NEOCrime.Models;
using Newtonsoft.Json.Linq;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace NEOCrime.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult getNeo(string TargetDate)
        {
            NeoRequest newRequest = new Models.NeoRequest(TargetDate);
            List<NeoResult.RootObject> jsonList = newRequest.GetNeoList();

            return Json(jsonList);
        }
    }
}

﻿using LibraryData;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
    public class PatronController : Controller
    {
        private IPatron _patron;

        PatronController(IPatron ipatron)
        {
            _patron = ipatron;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
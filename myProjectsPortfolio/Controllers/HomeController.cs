using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using myProjectsPortfolio.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
// --------------------------------
using System.Globalization;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
// --------------------------------
using myProjectsPortfolio.Controllers;
// using StreamReader

namespace myProjectsPortfolio.Controllers {
    public class HomeController : Controller {
        private MyContext _context;
        public HomeController (MyContext context) {
            _context = context;
        }

        //*************************************************************************************** 
        //                                 LOGIN, LOGOUT, REGISTER
        //***************************************************************************************

        [HttpGet]
        [Route ("")]
        public IActionResult Index () {
            return View ("Home");
        }
        [HttpGet]
        [Route ("wikipedia")]
        public IActionResult wikipedia () {
            return View ("wikipedia");
        }
    }
}
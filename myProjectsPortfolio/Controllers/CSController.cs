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
    public class CSController : Controller {
        private MyContext _context;
        public CSController (MyContext context) {
            _context = context;
        }

        [HttpGet]
        [Route ("CSProjects")]
        public IActionResult Index () {
            return View ("Main");
        }
    }
}
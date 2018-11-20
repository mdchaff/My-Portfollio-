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
    public class AAController : Controller {
        private MyContext _context;
        public AAController (MyContext context) {
            _context = context;
        }
        //*************************************************************************************** 
        //                                      ANGULARAUTO                                    
        [HttpGet]
        [Route ("AngularAuto")]
        public IActionResult angularPage () {
            ViewBag.fileBuild = HttpContext.Session.GetString ("fileBuild");
            return View ("AngularAuto");
        }
        //***************************************************************************************
        //                                      ANGULARAUTO                                    
        [HttpPost]
        [Route ("AngularAutoBuild")]
        public IActionResult AngularAutoBuild (AngAuto model, List<string> theInstalls) {
            // ============= Add name & file destination to DB =============
            AngAuto angAuto = new AngAuto {
                projectName = model.projectName,
                thePath = model.thePath
            };
            _context.Add (model);
            _context.SaveChanges ();
            AngAuto LastAngAuto = _context.AngAutos.Last ();

            // ========== Add the checkedboxed installs to the DB ==========
            foreach (var a in theInstalls) {
                Install newInstall = new Install {
                    TheInstall = " & cls & echo ====   " + a + "   ==== & " + a,
                    AngAuto_ID = LastAngAuto.AngAuto_ID,
                    AngAuto = LastAngAuto
                };
                _context.Add (newInstall);
                _context.SaveChanges ();

                LastAngAuto.theInstalls.Add (newInstall);
                _context.SaveChanges ();
            }

            // ============= BUILD THE STRING THATS SENT BACK ==============
            string x = " & ";
            string thePathx = "\\"+string.Join ("\\", model.thePath.Split (','));
            string fileBuild = "\"C:" + thePathx + "\\Text Files\\";
            string build (string str) {
                str = theStart (str);
                str = allInstalls (str);
                str = theServer (str);
                str = theTasks (str);
                str = theAngularBuild (str);
                str = theCMC (str);
                str = theStartUp (str);
                System.Console.WriteLine ("\n\n\t============================================\n");
                System.Console.WriteLine (str);
                System.Console.WriteLine ("\t============================================\n\n");
                return str;
            }
            // =============================================================
            string theStart (string str) {
                str = str + "cd ..\\.. & cd \"" + thePathx + "\"" + x;
                str = str + "mkdir " + model.projectName + x;
                str = str + "cd " + model.projectName;
                return str;
            }
            string allInstalls (string str) {
                foreach (var a in LastAngAuto.theInstalls) {
                    string temp = a.TheInstall.ToString ();
                    str += temp;
                    System.Console.WriteLine ("\t - " + temp);
                }
                return str;
            }
            string theServer (string str) {
                str += x+"echo ====   CREATING server.js   ====" + x;
                str += "del /f server.js & echo //Auto_Built > server.js" + x;
                str += "type " + fileBuild + "serverFile.txt\" >> server.js" + x;
                str += "cd public\\src\\app" + x;
                return str;
            }
            string theTasks (string str) {
                str += "cls & echo ====   ng g s user   ====" + x;
                str += "ng g s user" + x;

                str += "cls & echo ====   ng generate component home   ====" + x;
                str += "ng generate component home" + x;

                return (str + "cls" + x);
            }
            string theAngularBuild (string str) {
                str += "del /f app.module.ts & echo //Auto_Built > app.module.ts" + x;
                str += "type " + fileBuild + "appModuleTsFile.txt >> app.module.ts" + x;
                str += "del /f app.component.ts & echo //Auto_Built > app.component.ts" + x;
                str += "type " + fileBuild + "appComponentTs.txt >> app.component.ts" + x;
                str += "cd C:\"\\Users\\mdchf\\Desktop\\Angular Projects\\" + model.projectName + "\"" + x;
                return str;
            }
            string theCMC (string str) {
                str += "mkdir server & cd server" + x;

                str += "mkdir config & cd config" + x;
                str += "echo //Auto_Built > mongoose.js & type " + fileBuild + "mongooseFile.txt\" >> mongoose.js" + x;
                str += "echo //Auto_Built > routes.js & type " + fileBuild + "routesFile.txt\" >> routes.js" + x;
                str += "cd \"C:\\Users\\mdchf\\Desktop\\Angular Projects\\" + model.projectName + "\\server\"" + x;

                str += "mkdir controllers & cd controllers" + x;
                str += "echo //Auto_Built > tasks.js & type " + fileBuild + "tasksFile.txt\" >> tasks.js" + x;
                str += "cd \"C:\\Users\\mdchf\\Desktop\\Angular Projects\\" + model.projectName + "\\server\"" + x;

                str += "mkdir models & cd models" + x;
                str += "echo //Auto_Built > task.js & type " + fileBuild + "taskFile.txt\" >> task.js" + x;
                str += "cd \"C:\\Users\\mdchf\\Desktop\\Angular Projects\\" + model.projectName + "\"" + x;

                return str;
            }
            string theStartUp (string str) {
                str += "code . & ";
                str += "start cmd.exe /k nodemon server.js & ";
                str += "cd public & ";
                str += "color 70 & ";
                str += "ng build --watch\n";
                return str;
            }
            // =============================================================
            HttpContext.Session.SetString ("fileBuild", build (""));
            return RedirectToAction ("angularPage");
        }
    }
}
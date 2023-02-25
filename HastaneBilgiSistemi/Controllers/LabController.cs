using HastaneBilgiSistemi.Filter;
using HastaneBilgiSistemi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace HastaneBilgiSistemi.Controllers
{
    [UserFilter]
    public class LabController : Controller
    {
        private readonly ILogger<LabController> _logger;
        public readonly ApplicationDbContext _context;

        public LabController(ILogger<LabController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Anasayfa()
        {
            if (HttpContext.Session.GetString("role") == "Doctor")
            {
                return Redirect("/Doctor/Anasayfa");
            }
            if (HttpContext.Session.GetString("role") == "Admin")
            {
                return Redirect("/Admin/Anasayfa");
            }
            if (HttpContext.Session.GetString("role") == "Hasta")
            {
                return Redirect("/Patient/Anasayfa");
            }

            return View();
        }

        public IActionResult Testler()
        {
            if (HttpContext.Session.GetString("role") == "Doctor")
            {
                return Redirect("/Doctor/Anasayfa");
            }
            if (HttpContext.Session.GetString("role") == "Admin")
            {
                return Redirect("/Admin/Anasayfa");
            }
            if (HttpContext.Session.GetString("role") == "Hasta")
            {
                return Redirect("/Patient/Anasayfa");
            }

            var list = _context.Hastalar.ToList();
            return View(list);
        }

        public async Task<ActionResult> Update(Hastalar hastalar)
        {
               
            _context.Update(hastalar);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Anasayfa));
        }

        public IActionResult TestSonuc(int? Id)
        {
            if (HttpContext.Session.GetString("role") == "Doctor")
            {
                return Redirect("/Doctor/Anasayfa");
            }
            if (HttpContext.Session.GetString("role") == "Admin")
            {
                return Redirect("/Admin/Anasayfa");
            }
            if (HttpContext.Session.GetString("role") == "Hasta")
            {
                return Redirect("/Patient/Anasayfa");
            }

            Hastalar hastalar;
            if (Id.HasValue)
            {
                hastalar = _context.Hastalar.Find(Id);
            }
            else
            {
                hastalar = new Hastalar();
            }
            return View(hastalar);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

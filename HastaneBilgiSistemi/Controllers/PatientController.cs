using HastaneBilgiSistemi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Dynamic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using HastaneBilgiSistemi.Filter;
using Microsoft.AspNetCore.Http;

namespace HastaneBilgiSistemi.Controllers
{
    [UserFilter]
    public class PatientController : Controller
    {
        private readonly ILogger<PatientController> _logger;
        private readonly ApplicationDbContext _context;

        public PatientController(ILogger<PatientController> logger, ApplicationDbContext context)
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
            if (HttpContext.Session.GetString("role") == "Lab")
            {
                return Redirect("/Lab/Anasayfa");
            }

            return View();
        }

        public async Task<ActionResult> Create(Hastalar hastalar)
        {

            if (hastalar.Id == 0)
            {
                await _context.AddAsync(hastalar);
            }
            else
            {
                _context.Update(hastalar);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Anasayfa));
        }

        public async Task<ActionResult> Delete(int id)
        {
            var hastalar = await _context.Hastalar.FindAsync(id);
            _context.Remove(hastalar);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Randevularim));
        }

        public IActionResult RandevuEkle(int? Id)
        {
            if (HttpContext.Session.GetString("role") == "Doctor")
            {
                return Redirect("/Doctor/Anasayfa");
            }
            if (HttpContext.Session.GetString("role") == "Admin")
            {
                return Redirect("/Admin/Anasayfa");
            }
            if (HttpContext.Session.GetString("role") == "Lab")
            {
                return Redirect("/Lab/Anasayfa");
            }

            var productsList = (from product in _context.Bolumler
                                select new SelectListItem()
                                {
                                    Text = product.Bolum,
                                    Value = product.Bolum,
                                }).ToList();

            ViewBag.bolumListesi = productsList;

            foreach (var Data in productsList)
            {
                string ad = Data.Text + "Ad";

                ViewData[ad] = (from product in _context.Kullanicilar.Where(x => x.Bolum == Data.Text)
                                select new SelectListItem()
                                {
                                    Text = product.Ad + " " + product.Soyad,
                                    Value = product.Ad + " " + product.Soyad,
                                }).ToList();

            }


            Hastalar hastalar;
            if (Id.HasValue)
            {
                hastalar = _context.Hastalar.Find(Id);

                productsList.RemoveAll(a => a.Value == _context.Hastalar.Find(Id).Bolum);

                productsList.Insert(0, new SelectListItem()
                {
                    Text = _context.Hastalar.Find(Id).Bolum,
                    Value = _context.Hastalar.Find(Id).Bolum
                });
            }
            else
            {
                hastalar = new Hastalar();
            }
            return View(hastalar);
        }

        public IActionResult Randevularim()
        {
            if (HttpContext.Session.GetString("role") == "Doctor")
            {
                return Redirect("/Doctor/Anasayfa");
            }
            if (HttpContext.Session.GetString("role") == "Admin")
            {
                return Redirect("/Admin/Anasayfa");
            }
            if (HttpContext.Session.GetString("role") == "Lab")
            {
                return Redirect("/Lab/Anasayfa");
            }

            var list = _context.Hastalar.Where(a => a.Ad == HttpContext.Session.GetString("name") || a.Soyad == HttpContext.Session.GetString("surname"));
            return View(list);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

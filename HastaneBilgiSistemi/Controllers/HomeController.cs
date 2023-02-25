using HastaneBilgiSistemi.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;


namespace HastaneBilgiSistemi.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        public ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Login(string Ad, string Soyad, string Sifre)
        {
            var user = _context.Kullanicilar.FirstOrDefault(x => x.Ad.Equals(Ad) && x.Soyad.Equals(Soyad) && x.Sifre.Equals(Sifre)); //giriş yapmaya çalışan kullanıcının verilerini veritabanın'dan çekme işlemi
            if (user != null)
            {
                HttpContext.Session.SetInt32("id", user.Id);        //Http istegi içerisine kullanıcının id,isim,soyisim ve yetkisini atıyoruz
                HttpContext.Session.SetString("name",user.Ad );
                HttpContext.Session.SetString("surname", user.Soyad);
                HttpContext.Session.SetString("role", user.Yetki);
                if (user.Yetki == "Doktor")                     //kullanıcının yetkisine göre gerekli sayfaya yönlendiriyoruz
                    return Redirect("/Doctor/Anasayfa");
                if (user.Yetki == "Hasta")
                    return Redirect("/Patient/Anasayfa");
                if (user.Yetki == "Admin")
                    return Redirect("/Admin/Anasayfa");
                if (user.Yetki == "Lab")
                    return Redirect("/Lab/Anasayfa");
            }

            return Redirect("Index");       //eger bölümü veya böyle bir kullanıcı yoksa login sayfasına geri yönlendiriliyor
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();        //çıkış işlemi yapıldıgında oluştudugumuz oturumu temizliyoruz
            return View("Index");
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("role") == "Admin")
            {
                return Redirect("/Admin/Anasayfa");
            }
            if (HttpContext.Session.GetString("role") == "Doktor")
            {
                return Redirect("/Doctor/Anasayfa");
            }
            if (HttpContext.Session.GetString("role") == "Lab")
            {
                return Redirect("/Lab/Anasayfa");
            }
            if (HttpContext.Session.GetString("role") == "Hasta")
            {
                return Redirect("/Patient/Anasayfa");
            }
            return View();
        }

        public async Task<IActionResult> SignUp(Kullanicilar k)
        {
            await _context.AddAsync(k);         //kullanıcı kayıt oldugunda verileri veritabanına gönderip kaydediyoruz
            await _context.SaveChangesAsync();

            return Redirect("Index");
        }

        public IActionResult Register()
        {
            var productsList = (from product in _context.Bolumler
                                select new SelectListItem()
                                {
                                    Text = product.Bolum,
                                    Value = product.Bolum,
                                }).ToList();
            
            productsList.Insert(0, new SelectListItem()
            {
                Text = "",
                Value = ""
            });

            ViewBag.bolumListesi = productsList;


            if (HttpContext.Session.GetString("role") == "Admin")
            {
                return Redirect("/Admin/Anasayfa");
            }
            if (HttpContext.Session.GetString("role") == "Doktor")
            {
                return Redirect("/Doctor/Anasayfa");
            }
            if (HttpContext.Session.GetString("role") == "Lab")
            {
                return Redirect("/Lab/Anasayfa");
            }
            if (HttpContext.Session.GetString("role") == "Hasta")
            {
                return Redirect("/Patient/Anasayfa");
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using HastaneBilgiSistemi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc.Rendering;
using HastaneBilgiSistemi.Filter;
using Microsoft.AspNetCore.Http;

namespace HastaneBilgiSistemi.Controllers
{
    [UserFilter]

    public class DoctorController : Controller
    {
        private readonly ILogger<DoctorController> _logger;

        public readonly ApplicationDbContext _context;

        public DoctorController(ILogger<DoctorController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }


        public IActionResult Anasayfa()
        {
            if (HttpContext.Session.GetString("role") == "Admin")
            {
                return Redirect("/Admin/Anasayfa");
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

        public async Task<ActionResult> Create(Hastalar hastalar)
        {
            if(hastalar.Id == 0)
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

            return RedirectToAction(nameof(Hastalarim));
        }

        public IActionResult HastaEkle(int? Id)
        {
            if (HttpContext.Session.GetString("role") == "Admin")
            {
                return Redirect("/Admin/Anasayfa");
            }
            if (HttpContext.Session.GetString("role") == "Lab")
            {
                return Redirect("/Lab/Anasayfa");
            }
            if (HttpContext.Session.GetString("role") == "Hasta")
            {
                return Redirect("/Patient/Anasayfa");
            }

            var productsList = (from product in _context.Bolumler       //bölümleri database'den çekip degişkene yüklüyoruz
                                select new SelectListItem()
                                {
                                    Text = product.Bolum,
                                    Value = product.Bolum,
                                }).ToList();

            ViewBag.bolumListesi = productsList;        //bölümleri görüntü sayfasında dropdownlist'te yazdırmak için viewbag'e atıyoruz

            foreach (var Data in productsList)      //bütün bölümleri data degişkeniyle çagırıyoruz
            {
                string ad = Data.Text + "Ad";       //herbir bölüm için parametre ismi oluşturuyoruz örn:KardiyolojiAd
                
                ViewData[ad] = (from product in _context.Kullanicilar.Where(x => x.Bolum == Data.Text)      //kullanıcılar sayfasından o bölümdeki doktorları görüntü sayfasında yazdırmak için viewdata'ya atıyoruz
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

                productsList.RemoveAll(a => a.Value == _context.Hastalar.Find(Id).Bolum);   //eger randevu bilgileri güncellenecek ise dropdownlist'teki randevu oluşturulan bölümün en üste çıkması için o bölümün silinip en üste tekrardan yazdırılması
                                                                                            //örn: randevu kardiyoloji bölümünde ama dropdownlist'te 3.sırada gözüküyor onu ordan silip 1.sıraya yazdırılıyor
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

        public IActionResult Hastalarim()
        {
            if (HttpContext.Session.GetString("role") == "Admin")
            {
                return Redirect("/Admin/Anasayfa");
            }
            if (HttpContext.Session.GetString("role") == "Lab")
            {
                return Redirect("/Lab/Anasayfa");
            }
            if (HttpContext.Session.GetString("role") == "Hasta")
            {
                return Redirect("/Patient/Anasayfa");
            }

            var list = _context.Hastalar.Where(a => a.DoktorAd == HttpContext.Session.GetString("name") || a.DoktorSoyad == HttpContext.Session.GetString("surname"));  //giriş yapan doktorun hastalarını degişkene atma işlemi
            return View(list);
        }

        public IActionResult Konsultasyon()
        {
            if (HttpContext.Session.GetString("role") == "Admin")
            {
                return Redirect("/Admin/Anasayfa");
            }
            if (HttpContext.Session.GetString("role") == "Lab")
            {
                return Redirect("/Lab/Anasayfa");
            }
            if (HttpContext.Session.GetString("role") == "Hasta")
            {
                return Redirect("/Patient/Anasayfa");
            }

            var list = _context.Hastalar.Where(a => a.DoktorAd == HttpContext.Session.GetString("name") || a.DoktorSoyad == HttpContext.Session.GetString("surname"));
            return View(list);
        }

        public IActionResult KonsulteEt(int? Id)
        {
            if (HttpContext.Session.GetString("role") == "Admin")
            {
                return Redirect("/Admin/Anasayfa");
            }
            if (HttpContext.Session.GetString("role") == "Lab")
            {
                return Redirect("/Lab/Anasayfa");
            }
            if (HttpContext.Session.GetString("role") == "Hasta")
            {
                return Redirect("/Patient/Anasayfa");
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

        public IActionResult Test(int? Id)
        {
            if (HttpContext.Session.GetString("role") == "Admin")
            {
                return Redirect("/Admin/Anasayfa");
            }
            if (HttpContext.Session.GetString("role") == "Lab")
            {
                return Redirect("/Lab/Anasayfa");
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

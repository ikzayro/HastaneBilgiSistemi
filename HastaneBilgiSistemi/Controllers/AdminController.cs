using HastaneBilgiSistemi.Filter;
using HastaneBilgiSistemi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace HastaneBilgiSistemi.Controllers
{
    [UserFilter]    //filtre klasöründe yaptıgımız işlemlerin admin sayfalarına uygulanmasını belirtiyoruz
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;

        private readonly ApplicationDbContext _context;     //veritabanına sorgu yollayıp veriler çekebilecegimiz dbcontext nesnemiz

        public AdminController(ILogger<AdminController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Anasayfa()
        {
            if (HttpContext.Session.GetString("role") == "Doctor")      //doktor,lab yada hasta kullanıcısı admin sayfasına girmeye çalışırsa engellemek için yaptıgımız redirect işlemi
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

        public async Task<ActionResult> Create(MultipleModel model)
        {
            

            if (model.bolumler11.Id == 0)
            {
                await _context.AddAsync(model.bolumler11);      //eger id'imiz 0 ise yeni bir kullanıcı oluşturuyoruz
            }
            else
            {
                string bolumAdi = _context.Bolumler.AsNoTracking().Where(a => a.Id == model.bolumler11.Id).First().Bolum;   //kullanıcıların ve hastalarında bölümünü degiştirecegimiz için eski bölüm adını degişkene atadık

                _context.Update(model.bolumler11);      //eger id 0'dan farklı bir deger ise böyle bir kullanıcı var demektir ve güncelleme işlemiyo yapıyoruz
                _context.Kullanicilar.Where(a => a.Bolum == bolumAdi).ToList().ForEach(a => a.Bolum = model.bolumler11.Bolum);  //eski bölüm adına sahip olan satırları yeni bölüm adıyla degiştirdik
                _context.Hastalar.Where(a => a.Bolum == bolumAdi).ToList().ForEach(a => a.Bolum = model.bolumler11.Bolum);

            }

            await _context.SaveChangesAsync();      //yapılan degişiklikleri kaydediyoruz

            return RedirectToAction(nameof(Anasayfa));      //anasayfa'ya yönlendirme işlemi
        }

        public async Task<ActionResult> Delete(int id)
        {
            var bolumler = await _context.Bolumler.FindAsync(id);       //silinmesi istenen bölümü degişkene atıyoruz
            _context.Remove(bolumler);                  //silme işlemi
            
            var list = _context.Hastalar.Where(a => a.Bolum == bolumler.Bolum).ToList();        //bölüm silindigi zaman o bölümde randevusu olan hastalar ve o bölümdeki doktorlar siliniyor
            var list2 = _context.Kullanicilar.Where(a => a.Bolum == bolumler.Bolum).ToList();

            _context.RemoveRange(list);
            _context.RemoveRange(list2);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Anasayfa));
        }

        public IActionResult BolumEkle(int? Id)
        {
            if (HttpContext.Session.GetString("role") == "Doctor")
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

            MultipleModel mp = new MultipleModel();
            mp.kullanicilar1 = _context.Kullanicilar.ToList();
            mp.hastalar1 = _context.Hastalar.ToList();
            

            
            if (Id.HasValue)
            {
                      //düzenleme işlemi için veriyi degişkene atıyoruz
                mp.bolumler11 = _context.Bolumler.Find(Id);
            }
            else
            {
                      //yeni bölüm oluşturulacak ise yeni bir model oluşturuyoruz
                mp.bolumler11 = new Bolumler();
            }
                 //oluşturulan veriyi sayfaya döndürüyoruz
            return View(mp);
        }

        public IActionResult Bolumlerr()
        {
            if (HttpContext.Session.GetString("role") == "Doctor")
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

            MultipleModel mp = new MultipleModel();     //silme işlemi yapıldıgı zaman 3 farklı modelde işlem yapıldıgından dolayı birden fazla model kullanmak için 3 model için tek bir model oluşturuyoruz
            mp.bolumler1 = _context.Bolumler.ToList();
            mp.hastalar1 = _context.Hastalar.ToList();          //verileri modele yüklüyoruz
            mp.kullanicilar1 = _context.Kullanicilar.ToList();
            return View(mp);        //oluşturdugumuz modeli sayfaya döndürüyoruz

        }

        public async Task<ActionResult> Create2(Kullanicilar kullanicilar)      //kullanıcı düzenleme için yaratılan actionresult
        {
            _context.Update(kullanicilar);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Anasayfa));
        }

        public async Task<ActionResult> Delete2(int id)     //kullanıcı silmek için yaratılan actionresult
        {
            var kullanicilar = await _context.Kullanicilar.FindAsync(id);
            _context.Remove(kullanicilar);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Anasayfa));
        }

        public IActionResult KullaniciDuzenle(int? Id)
        {
            if (HttpContext.Session.GetString("role") == "Doctor")
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

            Kullanicilar kullanicilar;          //bölümeklede yapılan işlemlerin kullanıcılar için yapılması
            if (Id.HasValue)
            {
                kullanicilar = _context.Kullanicilar.Find(Id);
            }
            else
            {
                kullanicilar = new Kullanicilar();
            }
            return View(kullanicilar);
        }

        public IActionResult Kullanicilar()
        {
            if (HttpContext.Session.GetString("role") == "Doctor")
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

            var list = _context.Kullanicilar.ToList();
            return View(list);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HastaneBilgiSistemi.Models
{
    public class Kullanicilar
    {
        public int Id { get; set; }

        public string Ad { get; set; }

        public string Soyad { get; set; }

        public string Yetki { get; set; }

        public string Bolum { get; set; }

        public string Sifre { get; set; }

    }
}

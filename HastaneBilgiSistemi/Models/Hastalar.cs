using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HastaneBilgiSistemi.Models
{
    public class Hastalar
    {
        public int Id { get; set; }

        public string Ad { get; set; }

        public string Soyad { get; set; }

        public string Bolum { get; set; }

        public string DoktorAd { get; set; }

        public string DoktorSoyad { get; set; }

        public string HastaOykusu { get; set; }

        public string Teshis { get; set; }

        public string Tedavi { get; set; }

        public string Ilaclar { get; set; }

        public string LaboratuvarTest { get; set; }

        public string LaboratuvarSonuc { get; set; }

}
}

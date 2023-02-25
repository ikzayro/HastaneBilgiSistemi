using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HastaneBilgiSistemi.Models
{
    public class MultipleModel
    {
        public IEnumerable<Bolumler> bolumler1 { get; set; }        //bazen tek bir görüntü sayfasında birden fazla model kullanmamız gerekecegi için 3 modeli tek bir modelde birleştiriyoruz
        public IEnumerable<Kullanicilar> kullanicilar1 { get; set; }

        public IEnumerable<Hastalar> hastalar1 { get; set; }

        public Bolumler bolumler11 { get; set; }        
        public Kullanicilar kullanicilar11 { get; set; }
        public Hastalar hastalar11 { get; set; }
    }
}

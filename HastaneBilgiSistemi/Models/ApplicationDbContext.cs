using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HastaneBilgiSistemi.Models
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) //startup class'ında oluşturdugumuz veritabanı baglantısını dbcontext nesnemize tanıtıyoruz
        {
        }

        public DbSet<Hastalar> Hastalar { get; set; }   //modellerimizi dbcontext sınıfı tarafından tanınıp üzerinde sorgular oluşturabilecegimiz dbset oluşturuyoruz
        public DbSet<Bolumler> Bolumler { get; set; }
        public DbSet<Kullanicilar> Kullanicilar { get; set; }

    }
}

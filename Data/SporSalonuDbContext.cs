
using Microsoft.EntityFrameworkCore;
using SporSalonuYönetimSistemi.Models;

namespace SporSalonuYönetimSistemi.Models.Data
{
    public class SporSalonuDbContext : DbContext
    {
        public SporSalonuDbContext(DbContextOptions<SporSalonuDbContext> options)
            : base(options)
        {
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Egitmen> Egitmenler { get; set; }
        public DbSet<Alet> Aletler { get; set; }
        public DbSet<Ders> Dersler { get; set; }    
        public DbSet<GelirGider> GelirGider { get; set; }
     


    }
}


using Microsoft.EntityFrameworkCore;
using SporSalonuYönetimSistemi.Migrations;

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

    }
}

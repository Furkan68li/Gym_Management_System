using Microsoft.AspNetCore.Mvc;
using SporSalonuYönetimSistemi.Models;
using SporSalonuYönetimSistemi.Models.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace SporSalonuYönetimSistemi.Controllers
{
    public class RaporlamaController : Controller
    {
        private readonly SporSalonuDbContext _context;

        public RaporlamaController(SporSalonuDbContext context)
        {
            _context = context;
        }
        
        public IActionResult raporlama()
        {
            return View();
        }
        public IActionResult Raporlama()
        {
            var model = new RaporlamaViewModel
            {
                // Üye Sayıları
                ToplamUyeSayisi = _context.Members.Count(),
                AktifUyeSayisi = _context.Members.Count(u => u.AktifMi),
                PasifUyeSayisi = _context.Members.Count(u => !u.AktifMi),
                Uyeler = _context.Members.ToList(),

                // Ders Sayıları
                ToplamDersSayisi = _context.Dersler.Count(),
                AktifDersSayisi = _context.Dersler.Count(d => d.Aktif),
                Dersler = _context.Dersler.ToList(),

                // Eğitmen Sayıları
                ToplamEgitmenSayisi = _context.Egitmenler.Count(),
                Egitmenler = _context.Egitmenler.ToList(),

                // Alet Sayıları
                ToplamAletSayisi = _context.Aletler.Count(),
               
                Aletler = _context.Aletler.ToList()
            };

            return View(model);
        }
    }
}

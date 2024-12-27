using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SporSalonuYönetimSistemi.Models;
using SporSalonuYönetimSistemi.Models.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SporSalonuYönetimSistemi.Controllers
{
    public class DersController : Controller
    {
        private readonly SporSalonuDbContext _context;

        public DersController(SporSalonuDbContext context)
        {
            _context = context;
        }

        // GET: Ders_islemleri
        public async Task<IActionResult> Ders_islemleri()
        {
            var dersler = await _context.Dersler.ToListAsync();
            return View(dersler);
        }

        // POST: Ders Ekleme
        [HttpPost]
        public async Task<IActionResult> Ekle(Ders ders)
        {
            ders.Aktif = true;
            if (ModelState.IsValid)
            {
                _context.Add(ders);
                await _context.SaveChangesAsync();
                TempData["Message"] = "Ders başarıyla eklendi!";
                return RedirectToAction(nameof(Ders_islemleri));
            }

            TempData["ErrorMessage"] = "Ders ekleme sırasında hata oluştu!";
            return RedirectToAction(nameof(Ders_islemleri));
        }

        // GET: Güncelleme Sayfası
        [HttpGet]
        public async Task<IActionResult> Guncelle(int id)
        {
            var ders = await _context.Dersler.FindAsync(id);
            if (ders == null)
            {
                TempData["ErrorMessage"] = "Güncellenecek ders bulunamadı!";
                return RedirectToAction(nameof(Ders_islemleri));
            }

            ViewBag.EditMode = true;
            ViewBag.Ders = ders;
            var dersler = await _context.Dersler.ToListAsync();
            return View("Ders_islemleri", dersler);
        }

        // POST: Ders Güncelleme
        [HttpPost]
        public async Task<IActionResult> Guncelle(Ders ders)
        {
            if (ModelState.IsValid)
            {
                _context.Update(ders);
                await _context.SaveChangesAsync();
                TempData["Message"] = "Ders başarıyla güncellendi!";
                return RedirectToAction(nameof(Ders_islemleri));
            }

            TempData["ErrorMessage"] = "Ders güncelleme sırasında hata oluştu!";
            return RedirectToAction(nameof(Ders_islemleri));
        }

        // POST: Ders Silme
        [HttpPost]
        public async Task<IActionResult> Sil(int id)
        {
            var ders = await _context.Dersler.FindAsync(id);
            if (ders == null)
            {
                TempData["ErrorMessage"] = "Silinecek ders bulunamadı!";
                return RedirectToAction(nameof(Ders_islemleri));
            }

            _context.Dersler.Remove(ders);
            await _context.SaveChangesAsync();
            TempData["Message"] = "Ders başarıyla silindi!";
            return RedirectToAction(nameof(Ders_islemleri));
        }
    }
}

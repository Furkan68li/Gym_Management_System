using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SporSalonuYönetimSistemi.Models;
using SporSalonuYönetimSistemi.Models.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SporSalonuYönetimSistemi.Controllers
{
    public class EgitmenController : Controller
    {
        private readonly SporSalonuDbContext _context;

        public EgitmenController(SporSalonuDbContext context)
        {
            _context = context;
        }
        // Eğitmen arama işlemi
        [HttpGet]
        public async Task<IActionResult> Ara(string arama)
        {
            var egitmenlerQuery = _context.Egitmenler.AsQueryable();

            // Eğer arama parametresi varsa, eğitmenleri filtrele
            if (!string.IsNullOrEmpty(arama))
            {
                egitmenlerQuery = egitmenlerQuery.Where(e => e.Adi.Contains(arama) || e.Soyadi.Contains(arama) || e.UzmanlikAlani.Contains(arama));
            }

            var egitmenler = await egitmenlerQuery.ToListAsync();
            ViewBag.Arama = arama; // Arama terimini view'a gönder
            return View("Egitmen_yonetimi", egitmenler); // Filtrelenmiş eğitmenler listesini göster
        }

        // Egitmen yönetimi sayfası (Listeleme, ekleme, düzenleme ve silme işlemleri)
        [HttpGet]
        public async Task<IActionResult> Egitmen_yonetimi()
        {
            var egitmenler = await _context.Egitmenler.ToListAsync();
            return View(egitmenler); // Eğitmenler listesini view'a gönder
        }

        // Eğitmen ekleme işlemi
        [HttpPost]
        public async Task<IActionResult> Egitmen_yonetimi(Egitmen egitmen)
        {
            if (ModelState.IsValid)
            {
                if (egitmen.EgitmenId == 0) // Yeni eğitmen ekleniyor
                {
                    _context.Egitmenler.Add(egitmen);  // Veritabanına yeni eğitmen ekle
                    await _context.SaveChangesAsync(); // Değişiklikleri kaydet
                    TempData["Message"] = "Eğitmen başarıyla eklendi."; // Başarı mesajı
                }
                else // Mevcut eğitmen düzenleniyor
                {
                    var existingEgitmen = await _context.Egitmenler
                        .FirstOrDefaultAsync(e => e.EgitmenId == egitmen.EgitmenId);

                    if (existingEgitmen != null)
                    {
                        existingEgitmen.Adi = egitmen.Adi;
                        existingEgitmen.Soyadi = egitmen.Soyadi;
                        existingEgitmen.UzmanlikAlani = egitmen.UzmanlikAlani;
                        existingEgitmen.Deneyim = egitmen.Deneyim;
                        existingEgitmen.Iletisim = egitmen.Iletisim;

                        await _context.SaveChangesAsync(); // Güncellemeleri kaydet
                        TempData["Message"] = "Eğitmen başarıyla güncellendi."; // Başarı mesajı
                    }
                }

                return RedirectToAction("Egitmen_yonetimi");
            }
            else
            {
                // Model geçerli değilse, kullanıcıya hata mesajlarını göster
                TempData["ErrorMessage"] = "Lütfen tüm alanları doğru şekilde doldurduğunuzdan emin olun.";
                return View(egitmen); // Hata varsa, formu tekrar göster
            }
        }


        // Eğitmen silme işlemi
        [HttpPost]
        public async Task<IActionResult> Sil(int id)
        {
            var egitmen = await _context.Egitmenler.FirstOrDefaultAsync(e => e.EgitmenId == id);
            if (egitmen != null)
            {
                _context.Egitmenler.Remove(egitmen); // Eğitmeni veritabanından sil
                await _context.SaveChangesAsync(); // Değişiklikleri kaydet
                TempData["Message"] = "Eğitmen başarıyla silindi."; // Başarı mesajı
            }

            return RedirectToAction("Egitmen_yonetimi");
        }
        // Eğitmen düzenleme sayfası (GET)
        [HttpGet]
        public async Task<IActionResult> Duzelt(int id)
        {
            var egitmen = await _context.Egitmenler.FirstOrDefaultAsync(e => e.EgitmenId == id);
            if (egitmen == null)
            {
                return NotFound(); // Eğer eğitmen bulunmazsa, hata döndür
            }
            return View(egitmen); // Eğitmeni düzenleme formuna gönder
        }

        // Eğitmen düzenleme işlemi (POST)
        [HttpPost]
        public async Task<IActionResult> Duzelt(Egitmen egitmen)
        {
            if (ModelState.IsValid)
            {
                var existingEgitmen = await _context.Egitmenler
                    .FirstOrDefaultAsync(e => e.EgitmenId == egitmen.EgitmenId);

                if (existingEgitmen != null)
                {
                    existingEgitmen.Adi = egitmen.Adi;
                    existingEgitmen.Soyadi = egitmen.Soyadi;
                    existingEgitmen.UzmanlikAlani = egitmen.UzmanlikAlani;
                    existingEgitmen.Deneyim = egitmen.Deneyim;
                    existingEgitmen.Iletisim = egitmen.Iletisim;

                    await _context.SaveChangesAsync(); // Güncellemeleri kaydet
                    TempData["Message"] = "Eğitmen başarıyla güncellendi."; // Başarı mesajı
                    return RedirectToAction("Egitmen_yonetimi"); // Yönetim sayfasına yönlendir
                }
            }

            // Eğer model geçerli değilse, hata mesajlarını göster
            TempData["ErrorMessage"] = "Lütfen tüm alanları doğru şekilde doldurduğunuzdan emin olun.";
            return View(egitmen); // Hata varsa, formu tekrar göster
        }

    }
}

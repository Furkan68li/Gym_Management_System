using Microsoft.AspNetCore.Mvc;
using SporSalonuYönetimSistemi.Models.Data;
using SporSalonuYönetimSistemi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Fitrack.Controllers
{
    public class UyeController : Controller
    {
        private readonly SporSalonuDbContext _context;

        public UyeController(SporSalonuDbContext context)
        {
            _context = context;
        }

       
        public IActionResult uye_yonetimi(int? id, string search = "", int page = 1, int pageSize = 10)
        {
            var query = _context.Members.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(u => u.AdSoyad.Contains(search) || u.Eposta.Contains(search));
            }

            var uyeler = query
                .OrderBy(u => u.AdSoyad)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            // Üyelik süresi hesaplama
            foreach (var uye in uyeler)
            {
                if (uye.AbonelikBaslangicTarihi != null && uye.AbonelikBitisTarihi != null)
                {
                    var baslangicTarihi = uye.AbonelikBaslangicTarihi.Value;
                    var bitisTarihi = uye.AbonelikBitisTarihi.Value;
                    var gunFarki = (bitisTarihi - baslangicTarihi).Days;
                    uye.UyelikSuresi = (int)(gunFarki / 30)+1;  // 1 ay ortalama 30 gündür
                }
                else
                {
                    uye.UyelikSuresi = 0;
                }
            }

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = Math.Ceiling((double)query.Count() / pageSize);
            ViewBag.SearchTerm = search;

            // Eğer id parametresi varsa, detay ya da düzenleme formu gösterilecektir
            if (id.HasValue)
            {
                var uyeToEdit = _context.Members.Find(id);
                if (uyeToEdit != null)
                {
                    ViewBag.SelectedUye = uyeToEdit;
                }
            }

            return View(uyeler);
        }


        // POST: /Uye/uye_yonetimi
      [HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> uye_yonetimi(Member uye)
{
    // Ekleme işlemi
    if (uye.Id == 0) // Yeni üye ekleniyorsa
    {
        if (ModelState.IsValid)
        {
            // E-posta adresi zaten mevcut mu?
            var existingMember = await _context.Members
                .FirstOrDefaultAsync(m => m.Eposta == uye.Eposta);

            if (existingMember != null)
            {
                TempData["ErrorMessage"] = "Bu e-posta adresiyle zaten bir üye kayıtlı.";
                return RedirectToAction(nameof(uye_yonetimi));
            }

            // Üye ekleme işlemi
            uye.AktifMi = true;
            _context.Add(uye);
            await _context.SaveChangesAsync();
            TempData["Message"] = "Üye başarıyla eklendi!";
            return RedirectToAction(nameof(uye_yonetimi));
        }
    }

//    // Güncelleme işlemi
   

   // Silme işlemi (isteğe bağlı)
    if (uye.Id > 0) // Üye silme işlemi
    {
        var uyeToDelete = await _context.Members.FindAsync(uye.Id);
        if (uyeToDelete != null)
        {
            _context.Members.Remove(uyeToDelete);
            await _context.SaveChangesAsync();
          TempData["Message"] = "Üye başarıyla silindi!";
        }
   }

            //    // Hata durumunda
            //    //TempData["ErrorMessage"] = "Bir işlem sırasında hata oluştu.";
            return RedirectToAction(nameof(uye_yonetimi));
}


        // GET: /Uye/UyeDetay/5
        public async Task<IActionResult> UyeDetay_action(int? id)
        {
            if (id == null)
                return RedirectToAction("uye_yonetimi");

            var uye = await _context.Members.FindAsync(id);
            if (uye == null)
                return RedirectToAction("uye_yonetimi");

            return View(uye);
        }

        // GET: /Uye/UyeDuzenle/5
        public async Task<IActionResult> UyeDuzenle(int? id)
        {
            if (id == null)
                return RedirectToAction("uye_yonetimi");

            var uye = await _context.Members.FindAsync(id);
            if (uye == null)
                return RedirectToAction("uye_yonetimi");

            return View(uye);
        }

        // POST: /Uye/UyeDuzenle
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UyeDuzenle_action(int id, Member uye)
        {
            if (id != uye.Id)
                return RedirectToAction("uye_yonetimi");

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(uye);
                    await _context.SaveChangesAsync();
                    TempData["Message"] = "Üye başarıyla güncellendi!";
                }
                catch (Exception)
                {
                    TempData["ErrorMessage"] = "Üye güncellenirken bir hata oluştu.";
                }
                return RedirectToAction(nameof(uye_yonetimi));
            }
            return RedirectToAction(nameof(uye_yonetimi));
        }

        // GET: /Uye/UyeSil/5
        public async Task<IActionResult> UyeSil(int? id)
        {
            if (id == null)
                return RedirectToAction("uye_yonetimi");

            var uye = await _context.Members.FindAsync(id);
            if (uye == null)
                return RedirectToAction("uye_yonetimi");

            return View(uye);
        }

        // POST: /Uye/UyeSil/5
        [HttpPost, ActionName("UyeSil")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UyeSilOnay(int id)
        {
            var uye = await _context.Members.FindAsync(id);
            if (uye != null)
            {
                _context.Members.Remove(uye);
                await _context.SaveChangesAsync();
                TempData["Message"] = "Üye başarıyla silindi!";
            }
            return RedirectToAction(nameof(uye_yonetimi));
        }
    }
}

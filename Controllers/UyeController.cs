using Microsoft.AspNetCore.Mvc;
using SporSalonuYönetimSistemi.Models.Data;
using SporSalonuYönetimSistemi.Models;
using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
namespace Fitrack.Controllers
{
    public class UyeController : Controller
    {
        private readonly SporSalonuDbContext _context;

        public UyeController(SporSalonuDbContext context)
        {
            _context = context;
        }

        public IActionResult uye_yonetimi(Member model)
        {
            return View(model);
        }

        public IActionResult UyeListesi()
        {
            var uyeler = _context.Members.ToList();
            return View(uyeler);
        }

        // GET: /Process/UyeDetay/5
        public IActionResult UyeDetay_action(int? id)
        {
            if (id == null)
                return NotFound();

            var uye = _context.Members.FirstOrDefault(u => u.Id == id);
            if (uye == null)
                return NotFound();

            return View(uye);
        }

        // GET: /Process/UyeEkle
        public IActionResult UyeEkle()
        {
            return View();
        }

        // POST: /Process/UyeEkle
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UyeEkle_action(Member uye)
        {
            if (ModelState.IsValid)
            {
                _context.Add(uye);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(UyeListesi));
            }
            return View(uye);
        }

        // GET: /Process/UyeDuzenle/5
        public IActionResult UyeDuzenle(int? id)
        {
            if (id == null)
                return NotFound();

            var uye = _context.Members.Find(id);
            if (uye == null)
                return NotFound();

            return View(uye);
        }

        // POST: /Process/UyeDuzenle/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UyeDuzenle_action(int id, Member uye)
        {
            if (id != uye.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(uye);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(UyeListesi));
            }
            return View(uye);
        }

        // GET: /Process/UyeSil/5
        public IActionResult UyeSil(int? id)
        {
            if (id == null)
                return NotFound();

            var uye = _context.Members.FirstOrDefault(u => u.Id == id);
            if (uye == null)
                return NotFound();

            return View(uye);
        }

        // POST: /Process/UyeSil/5
        [HttpPost, ActionName("UyeSil")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UyeSilOnay(int id)
        {
            var uye = _context.Members.Find(id);
            if (uye != null)
            {
                _context.Members.Remove(uye);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(UyeListesi));
        }
    }
}


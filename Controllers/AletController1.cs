using Microsoft.AspNetCore.Mvc;
using SporSalonuYönetimSistemi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SporSalonuYönetimSistemi.Controllers
{
    public class AletController : Controller
    {
        // Geçici veritabanı için bir liste
        private static List<Alet> aletler = new List<Alet>();

        // Alet listesi ve ekleme/güncelleme formunu gösteren GET metodu
        public IActionResult Alet_yonetimi()
        {
            return View(aletler);
        }

        // Alet eklemek için POST metodu
        [HttpPost]
        public IActionResult Ekle(Alet alet)
        {
            if (ModelState.IsValid)
            {
                alet.AletId = aletler.Count > 0 ? aletler.Max(a => a.AletId) + 1 : 1; // Yeni AletId oluştur
                aletler.Add(alet);
                return RedirectToAction("Alet_yonetimi");
            }
            return View("Alet_yonetimi", aletler);
        }

        // Alet güncellemek için GET metodu
        public IActionResult Guncelle(int id)
        {
            var alet = aletler.FirstOrDefault(a => a.AletId == id);
            if (alet == null)
                return NotFound();
            return View(alet);
        }

        // Alet güncellemek için POST metodu
        [HttpPost]
        public IActionResult Guncelle(Alet alet)
        {
            if (ModelState.IsValid)
            {
                var mevcutAlet = aletler.FirstOrDefault(a => a.AletId == alet.AletId);
                if (mevcutAlet != null)
                {
                    mevcutAlet.AletAdi = alet.AletAdi;
                    mevcutAlet.AletTuru = alet.AletTuru;
                    mevcutAlet.Durum = alet.Durum;
                    mevcutAlet.Miktar = alet.Miktar;
                    mevcutAlet.Aciklama = alet.Aciklama;
                    mevcutAlet.AlimTarihi = alet.AlimTarihi;
                }
                return RedirectToAction("Alet_yonetimi");
            }
            return View(alet);
        }

        // Alet silmek için POST metodu
        [HttpPost]
        public IActionResult Sil(int id)
        {
            var alet = aletler.FirstOrDefault(a => a.AletId == id);
            if (alet != null)
            {
                aletler.Remove(alet);
            }
            return RedirectToAction("Alet_yonetimi");
        }
        public IActionResult Alet_duzenle()
        { 
            return View();  
        }
    }
}
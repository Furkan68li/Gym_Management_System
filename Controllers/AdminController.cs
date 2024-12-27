using Microsoft.AspNetCore.Mvc;
using SporSalonuYönetimSistemi.Models.Data;
using SporSalonuYönetimSistemi.Models;
using System;
using System.Linq;
using Microsoft.AspNetCore.Http;

public class AdminController : Controller
{
    private readonly SporSalonuDbContext _context;

    public AdminController(SporSalonuDbContext context)
    {
        _context = context;
    }

    public IActionResult Login()
    {
        return View();
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login_Action(string username, string password)
    {
        // Kullanıcıyı veritabanından çekiyoruz
        var admin = _context.Admins.FirstOrDefault(a => a.UserName == username);

        if (admin == null)
        {
            // Kullanıcı bulunamadı, hata mesajı ekle
            ModelState.AddModelError("", "Bu kullanıcı adıyla kayıtlı bir hesap bulunamadı!");
            return View("Login"); // Login sayfasına geri dön
        }

        // Şifreyi doğrula
        if (!BCrypt.Net.BCrypt.Verify(password, admin.PasswordHash))
        {
            // Şifre yanlışsa hata mesajı ekle
            ModelState.AddModelError("", "Geçersiz şifre. Lütfen tekrar deneyin.");
            return View("Login");
        }

        // Kullanıcı adı ve şifre doğruysa, session'a admin id'sini ekle
        HttpContext.Session.SetString("AdminUserName", admin.UserName);

        // Kullanıcı adı ve şifre doğruysa Anasayfa'ya yönlendir
        return RedirectToAction("Anasayfa");
    }

    [HttpPost]
    public IActionResult Register_Action(string username, string password, string confirmPassword)
    {
        // Kullanıcı adı daha önce alınmış mı kontrol et
        if (_context.Admins.Any(a => a.UserName == username))
        {
            // Kullanıcı adı alınmış, hata mesajını ekle
            ModelState.AddModelError("", "Bu kullanıcı adı zaten alınmış.");
            return View("Register"); // Kullanıcıyı Register sayfasına geri gönder
        }

        // Şifre ve tekrar şifreyi karşılaştır
        if (password != confirmPassword)
        {
            // Şifreler eşleşmiyor, hata mesajını ekle
            ModelState.AddModelError("", "Şifreler birbirini tutmuyor!");
            return View("Register");
        }

        // Şifreyi hash'le
        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

        // Yeni admin objesi oluştur
        var admin = new Admin
        {
            UserName = username,
            PasswordHash = hashedPassword,
            CreatedAt = DateTime.Now
        };

        // Veritabanına kaydet
        _context.Add(admin);
        _context.SaveChanges();

        // Başarı sayfasına yönlendirme
        return RedirectToAction("Success");
    }

    // Kayıt sonrası başarı sayfası
    public IActionResult Success()
    {
        return View();
    }

    // Anasayfa'ya yönlendirme işlemi
    public IActionResult  Anasayfa()
    {
        // Oturum açmış kullanıcıyı kontrol et
        var adminUserName = HttpContext.Session.GetString("AdminUserName");

        if (string.IsNullOrEmpty(adminUserName))
        {
            // Kullanıcı giriş yapmamışsa login sayfasına yönlendir
            return RedirectToAction("Login");
        }

        return View("~/Views/Sayfa/Anasayfa.cshtml"); // Özel bir dizindeki Anasayfa view dosyasına yönlendiriyor
    }

    // Çıkış işlemi
    public IActionResult Logout()
    {
        // Kullanıcının oturumunu sonlandır
        HttpContext.Session.Remove("AdminUserName");

        // Çıkış işlemi sonrası giriş sayfasına yönlendir
        return RedirectToAction("Login");
    }
}

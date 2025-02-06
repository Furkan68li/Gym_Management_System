# Fitrack - Spor Salonu Yönetim Sistemi

## Proje Hakkında
Fitrack, spor salonlarının üye kayıt, rezervasyon ve ödeme gibi işlemlerini kolaylıkla yönetebileceği bir sistemdir. ASP.NET Core ve SQL Server kullanılarak geliştirilmektedir.

## Proje Durumu
- [X] Giriş ve Küyet Kayıt Sayfaları
- [X] Küyet Kayıt Sonrası Yönlendirme
- [ ] Dashboard Tasarımı
- [ ] Randevu ve Rezervasyon Modülü
- [ ] Ödeme Takibi

## Kullanılan Teknolojiler
- **Backend:** ASP.NET Core
- **Veritabanı:** SQL Server
- **Frontend:** Razor Pages, HTML, CSS
- **Kimlik Doğrulama:** ASP.NET Identity

## Kurulum
### Gereksinimler
- Visual Studio (2022+)
- .NET 6+ SDK
- SQL Server

### Kurulum Adımları
1. Projeyi klonlayın:
   ```bash
   git clone https://github.com/kullaniciadi/fitrack.git
   ```
2. Visual Studio ile projeyi açın.
3. **appsettings.json** dosyasında SQL Server bağlantı bilgilerinizi düzenleyin.
4. Veritabanını oluşturun:
   ```bash
   dotnet ef database update
   ```
5. Projeyi çalıştırın:
   ```bash
   dotnet run
   ```

## Kullanım
1. **Giriş Yap:** Kullanıcı adı ve şifre ile sisteme giriş yapın.
2. **Üye Kaydı:** Yeni üyeler için kayıt oluşturun.
3. **Rezervasyonlar:** Spor salonundaki randevuları ve rezervasyonları yönetin.
4. **Ödeme Takibi:** Üyelik ödemelerini takip edin.

## Katkıda Bulunma
Katkıda bulunmak için lütfen bir **Pull Request** oluşturun veya bir **Issue** açarak geri bildirimde bulunun.

## Lisans
Bu proje MIT Lisansı altında sunulmaktadır.

---
Fitrack geliştirme aşamasında olduğu için, geri bildirimleriniz ve önerileriniz bizim için çok önemlidir! İletişime geçmek için bizimle GitHub veya e-posta aracılığıyla iletişime geçebilirsiniz.


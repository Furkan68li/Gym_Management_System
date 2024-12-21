namespace SporSalonuYönetimSistemi.Models
{
    public class Member
    {

            public int Id { get; set; } // Üye ID
            public string AdSoyad { get; set; } // Üye Adı
            public string Eposta { get; set; } // E-posta adresi
            public string Telefon { get; set; } // Telefon Numarası
            public string UyelikTuru { get; set; } // "Standart" veya "VIP"
            public decimal AylikUcret { get; set; } // Aylık Ücret
            public decimal? IndirimOrani { get; set; } // VIP için indirim oranı (%)
            public DateTime? AbonelikBaslangicTarihi { get; set; }
            public DateTime? AbonelikBitisTarihi { get; set; } // Üyelik bitiş tarihi
            public bool AktifMi { get; set; } // Üyelik durumu (Aktif/Pasif)
        

    }
}

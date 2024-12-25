namespace SporSalonuYönetimSistemi.Models;
public class Alet
{
    public int AletId { get; set; } // Aletin benzersiz ID'si
    public string AletAdi { get; set; } // Aletin adı
    public string AletTuru { get; set; } // Aletin türü (örneğin; kardiyo, ağırsiklet, yoga vb.)
    public string Durum { get; set; } // Aletin durumu (örneğin; aktif, bakımda, arızalı vb.)
    public int Miktar { get; set; } // Salon içindeki aletin sayısı
    public string Aciklama { get; set; } // Aletle ilgili ek bilgiler
    public DateTime AlimTarihi { get; set; } // Aletin alım tarihi
}

namespace SporSalonuYönetimSistemi.Models;
public class Ders
{
    public int DersId { get; set; } // Dersin benzersiz ID'si
    public string DersAdi { get; set; } // Dersin adı
    public string Aciklama { get; set; } // Dersin açıklaması
    public DateTime BaslangicSaati { get; set; } // Dersin başlangıç saati
    public DateTime BitisSaati { get; set; } // Dersin bitiş saati
    public int EgitmenId { get; set; } // Eğitmenin ID'si
    public string DersYeri { get; set; } // Dersin yapılacağı yer (örneğin, spor salonu)
    public bool Aktif { get; set; } // Dersin aktif olup olmadığı
}

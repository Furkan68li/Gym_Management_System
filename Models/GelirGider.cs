namespace SporSalonuYönetimSistemi.Models;
public class GelirGider
{
    public int GelirGiderId { get; set; } // Gelir/Gider'in benzersiz ID'si
    public string Tipi { get; set; } // Gelir veya gider (Gelir / Gider)
    public int Miktar { get; set; } // Gelir veya gider miktarı
    public string Aciklama { get; set; } // Gelir veya gider ile ilgili açıklama
    public DateTime Tarih { get; set; } // Gelir veya giderin gerçekleştiği tarih
}

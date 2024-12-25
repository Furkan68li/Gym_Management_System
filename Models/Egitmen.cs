namespace SporSalonuYönetimSistemi.Models;
public class Egitmen
{
    public int EgitmenId { get; set; } // Eğitmenin benzersiz ID'si
    public string Adi { get; set; } // Eğitmenin adı
    public string Soyadi { get; set; } // Eğitmenin soyadı
    public string UzmanlikAlani { get; set; } // Eğitmenin uzmanlık alanı
    public string Deneyim { get; set; } // Eğitmenin deneyimi (yıl olarak)
    public string Iletisim { get; set; } // Eğitmenin iletişim bilgisi
}

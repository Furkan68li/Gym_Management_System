using System;
using System.Collections.Generic;

namespace SporSalonuYönetimSistemi.Models
{
    public class RaporlamaViewModel
    {
        public int ToplamUyeSayisi { get; set; }
        public int AktifUyeSayisi { get; set; }
        public int PasifUyeSayisi { get; set; }
        public List<Member> Uyeler { get; set; }

        public int ToplamDersSayisi { get; set; }
        public int AktifDersSayisi { get; set; }
        public List<Ders> Dersler { get; set; }

        public int ToplamEgitmenSayisi { get; set; }
        public int AktifEgitmenSayisi { get; set; }
        public List<Egitmen> Egitmenler { get; set; }

        public int ToplamAletSayisi { get; set; }
        public int AktifAletSayisi { get; set; }
        public List<Alet> Aletler { get; set; }
    }
}

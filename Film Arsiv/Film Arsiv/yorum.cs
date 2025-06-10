using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Film_Arsiv
{
    public class Yorum
    {
        public string YazanKullanici { get; set; }
        public string Icerik { get; set; }
        public DateTime Tarih { get; set; }

        public Yorum(string yazanKullanici, string icerik)
        {
            YazanKullanici = yazanKullanici;
            Icerik = icerik;
            Tarih = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{YazanKullanici} ({Tarih}): {Icerik}";
        }
    }
}

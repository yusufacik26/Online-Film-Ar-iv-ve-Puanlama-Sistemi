using System;

namespace Film_Arsiv
{
    public class Kullanıcı
    {
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public string Rol { get; set; } // "Admin" veya "Uye"

        public Kullanıcı(string kullaniciAdi, string sifre, string rol)
        {
            KullaniciAdi = kullaniciAdi;
            Sifre = sifre;
            Rol = rol;
        }
    }
}
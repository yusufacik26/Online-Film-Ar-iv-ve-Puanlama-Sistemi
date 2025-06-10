using System;
 namespace Film_Arsiv
{
    public class Film
    {
        public string isim { get; set; }
        public string tur { get; set; }

        public string yil { get; set; }

        public Film(string isim, string tur, string yil)
        {

            this.isim = isim;
            this.tur = tur;
            this.yil = yil;


        }

    }
}
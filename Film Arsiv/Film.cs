using System;
using System.Collections.Generic;
using System.Linq;

namespace Film_Arsiv
{

    namespace FilmArsiv
    {
        public class Film : IPuanlanabilir, IYorumlanabilir
        {
            public string Ad { get; set; }
            public string Tur { get; set; }
            public string Yil { get; set; }

            public List<int> Puanlar { get; set; } = new List<int>();
            public List<Yorum> Yorumlar { get; set; } = new List<Yorum>();

            public void YorumEkle(Yorum yorum)
            {
                Yorumlar.Add(yorum);
            }

            public Film(string ad, string tur, string yil)
            {
               this.Ad = ad;
                this.Tur = tur;
                this.Yil = yil;
            }

            public void PuanVer(int puan)
            {
                Puanlar.Add(puan);
            }

            public void YorumYap(Yorum yorum)
            {
                Yorumlar.Add(yorum);
            }

            // Ortalama Puan Özelliği
            public double OrtalamaPuan
            {
                get
                {
                    if (Puanlar.Count == 0) return 0;
                    return Puanlar.Average();
                }
            }
        }
    }



}
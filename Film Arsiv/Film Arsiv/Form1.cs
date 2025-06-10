using Film_Arsiv;
using Film_Arsiv.FilmArsiv;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Film_Arsiv
{
    public partial class Form1 : Form
    {
        List<Film> filmler = new List<Film>();

        
        Kullanıcı aktifKullanici;

        public Form1()
        {
            InitializeComponent();

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            MessageBox.Show("LÜTFEN İŞLEMLERDEN ÖNCE GİRİŞ YAPINIZ!!");

        }

        private void Listeleme_SelectedIndexChanged(object sender, EventArgs e)
        {
                                                                                                                                                                                                     Listeleme.Items.Clear();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Listeleme.Items.Clear(); // Önce listeyi temizle

            if (filmler.Count == 0)
            {
                Listeleme.Items.Add("Hiç film eklenmemiş.");
                return;
            }

            var populerFilmler = filmler
                
                .OrderByDescending(f => f.OrtalamaPuan)
                .Take(10)
                .ToList();

            if (populerFilmler.Count == 0)
            {
                Listeleme.Items.Add("Popüler film bulunamadı.");
                return;
            }

            foreach (var film in populerFilmler)
            {
                Listeleme.Items.Add($"{film.Ad} ({film.Yil}) - Ortalama Puan: {film.OrtalamaPuan:F1}");
            }
        }




        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string filmAdi = textBox7.Text;
            string filmTuru = textBox8.Text;
            string filmYili = textBox9.Text;
            if (textBox5.Text == "admin")
            {
                if (string.IsNullOrEmpty(filmAdi) || string.IsNullOrEmpty(filmTuru) || string.IsNullOrEmpty(filmYili))
                {
                    MessageBox.Show("Lütfen tüm film bilgilerini doldurun!");
                    return;
                }

                Film film = new Film(filmAdi, filmTuru, filmYili);
                filmler.Add(film);


                // Dosyaya yazılacak format şekli 

                string filmSatiri = $"{filmAdi} | {filmTuru} | {filmYili}";

                // Dosyaya ekleme kısmı
                try
                {
                    System.IO.File.AppendAllText("C:\\Users\\Yusuf Açık\\source\\repos\\Film Arsiv\\Imdb.txt", filmSatiri + Environment.NewLine);


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Dosyaya yazılırken bir hata oluştu: " + ex.Message);
                    return;
                }

                MessageBox.Show("Film başarıyla eklendi ve dosyaya kaydedildi!");
            }
            else { MessageBox.Show("admin olmadığınız için film ekleme işlemini yapamazsınız!!!"); }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            string filmAdi = textBox3.Text;
            int filmPuani;

            if (!int.TryParse(textBox1.Text, out filmPuani) || filmPuani < 0 || filmPuani > 10)
            {
                MessageBox.Show("Lütfen 0-10 arasında bir puan giriniz!");
                return;
            }

            Film bulunanFilm = filmler.FirstOrDefault(f => f.Ad.Equals(filmAdi, StringComparison.OrdinalIgnoreCase));

            if (bulunanFilm == null)
            {
                MessageBox.Show("Film bulunamadı!");
                return;
            }

            // Ortalama hesaplama (ve Puanlar listesine ekleme)
            bulunanFilm.OrtalamaPuan = (bulunanFilm.OrtalamaPuan + filmPuani) / 2;
            bulunanFilm.Puanlar.Add(filmPuani); // ← BU ÇOK ÖNEMLİ

            // TXT dosyasını güncelle
            List<string> yeniSatirlar = new List<string>();
            foreach (var film in filmler)
            {
                string satir = $"{film.Ad} | {film.Tur} | {film.Yil} | {film.OrtalamaPuan:F2}";
                yeniSatirlar.Add(satir);
            }

            File.WriteAllLines("C:\\Users\\Yusuf Açık\\source\\repos\\Film Arsiv\\Imdb.txt", yeniSatirlar);

            MessageBox.Show($"Puan eklendi. Yeni ortalama: {bulunanFilm.OrtalamaPuan:F2}");
        }





        private void button2_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = textBox5.Text;
            string sifre = textBox6.Text;

            // Örnek sabit admin kontrolü:
            if (kullaniciAdi == "admin" && sifre == "admin123")
            {
                aktifKullanici = new Admin(kullaniciAdi, sifre, "Admin");
                MessageBox.Show("Admin olarak giriş yapıldı.");
            }
            else
            {
                aktifKullanici = new Uye(kullaniciAdi, sifre, "Uye");
                MessageBox.Show("Üye olarak giriş yapıldı.");
            }

            // Giriş yapınca filmleri yükle
            string dosyaYolu = "C:\\Users\\Yusuf Açık\\source\\repos\\Film Arsiv\\Imdb.txt";

           

            if (File.Exists(dosyaYolu))
            {
                var satirlar = File.ReadAllLines(dosyaYolu);

                foreach (string satir in satirlar)
                {
                    string[] parcala = satir.Split('|');

                    if (parcala.Length >= 4)
                    {
                        string ad = parcala[0].Trim();
                        string tur = parcala[1].Trim();
                        string yil = parcala[2].Trim();
                        double ortalamaPuan = double.TryParse(parcala[3].Trim(), out var op) ? op : 0;

                        // Film nesnesi oluşturuluyor
                        Film film = new Film(ad, tur, yil);

                        // Ortalama puanı film nesnesine ekle
                        film.OrtalamaPuan = ortalamaPuan;

                        filmler.Add(film);
                    }
                }

                MessageBox.Show($"{filmler.Count} film başarıyla yüklendi.");
            }
            else
            {
                MessageBox.Show("Film dosyası bulunamadı!");
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            string filmAdi = textBox2.Text;
            string yorumIcerik = textBox4.Text;

            bool bulunduMu = false;

            foreach (Film film in filmler)
            {
                if (film.Ad.Equals(filmAdi))
                {
                    // Bir Yorum nesnesi oluşturur
                    Yorum yeniYorum = new Yorum(aktifKullanici.KullaniciAdi, yorumIcerik);

                    ((IYorumlanabilir)film).YorumYap(yeniYorum);

                    MessageBox.Show("Yorum başarıyla eklendi!");
                    bulunduMu = true;
                    break;
                }
            }

            if (!bulunduMu)
            {
                MessageBox.Show("Film bulunamadı!");
            }
        }

    }









}



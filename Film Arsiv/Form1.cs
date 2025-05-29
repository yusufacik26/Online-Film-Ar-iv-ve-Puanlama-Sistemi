using Film_Arsiv;
using Film_Arsiv.FilmArsiv;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Film_Arsiv
{
    public partial class Form1 : Form
    {
        List<Film> filmler = new List<Film>();
        Dictionary<Film, List<int>> puanlar = new Dictionary<Film, List<int>>();
        
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
            string populerFilmler = "";

            foreach (Film film in filmler)
            {
                int count = 0;
                int filmPuan = Convert.ToInt32(film.OrtalamaPuan);
                if(filmPuan> 8 && count < 10)
                {
                    count++;
                    populerFilmler += "/n" + film.Ad;

                    

                }


            }
            Listeleme.Items.Clear();
            Listeleme.Items.Add(populerFilmler);


            
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
          //  if (aktifKullanıcı is Admin) ??? Burayı nasıl ayarlayabilirim
            {
                string filmAdi = textBox7.Text;
                string filmTuru = textBox8.Text;
                string filmYili = textBox9.Text;

                Film film = new Film(filmAdi, filmTuru, filmYili);

                filmler.Add(film);
                MessageBox.Show("Film başarıyla eklendi!");

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Puan ekle kısmı

            string filmAdi = textBox3.Text;
            int filmPuani = Convert.ToInt32(textBox1.Text);
            Boolean bulunduMu = false;

            foreach (Film film in filmler)
            {

                if (film.Ad.Equals(filmAdi))
                {
                    bulunduMu = true;
                    film.PuanVer(filmPuani);

                    break;
                }


            }
            if (!bulunduMu)
            {
                MessageBox.Show("Film bulunamadı!!");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        { // Giriş Yapma Kısmı
            string kullaniciAdi = textBox5.Text;
            // Kullanıcını adını bir dosyadan alarak admin mi üye mi olduğuna bakabiliriz ?
            
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



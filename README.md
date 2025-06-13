# 🎬 Film Arşiv Otomasyonu

Bu proje, kullanıcıların film bilgilerini ekleyebildiği, puanlayabildiği ve yorum yapabildiği basit bir **Windows Forms (WinForms)** uygulamasıdır. Projede filmler `.txt` dosyasına kaydedilir ve kullanıcı girişine göre işlem yapılabilir.

## 🛠 Özellikler

- 🎥 Film ekleme (Ad, Tür, Yıl)
- ⭐ Filme puan verme (0–10 arası)
- 📊 Ortalama puanları görüntüleme
- 🔥 Popüler filmleri listeleme (Ortalama puanı 6 üzeri olanlar)
- 💬 Yorum yapma
- 👥 Kullanıcı girişi (Admin / Üye)

## 🗂 Dosya Yapısı

### `Imdb.txt` örnek satır:
Inception | Bilim Kurgu | 2010 | 8.50
Titanic | Dram | 1997 | 7.80


Her satır: `Film Adı | Türü | Yılı | Ortalama Puan` şeklinde yazılır.

## 👤 Kullanıcı Rolleri

- **Admin**: `admin` / `admin123` ile giriş yapılabilir.
- **Üye**: İstediğiniz kullanıcı adı/şifre ile giriş yapılabilir.

Girişten sonra film listesi otomatik olarak yüklenir.

## 💡 Kullanım Akışı

1. Uygulama açıldığında giriş yapılması istenir.
2. Giriş sonrası mevcut filmler `.txt` dosyasından yüklenir.
3. Kullanıcı film ekleyebilir.
4. Filmlere puan verilebilir. Ortalama puan güncellenir ve dosyaya yazılır.
5. Popüler filmler listelenebilir.
6. Filmlere yorum yapılabilir.

## 💾 Kalıcı Veri

Tüm filmler ve ortalama puanlar `Imdb.txt` dosyasında saklanır. Film silme veya düzenleme işlevi henüz eklenmemiştir.

## ✅ Gereksinimler

- Visual Studio 2019/2022
- .NET Framework (örn. 4.7.2)
- WinForms projesi olarak ayarlanmalı

## 📁 Önemli Notlar

- Dosya yolu sabittir:  
  `"C:\\Users\\Yusuf Açık\\source\\repos\\Film Arsiv\\Imdb.txt"`  
  Farklı kullanıcılar için değiştirilmesi gerekir.
- Uygulama yalnızca tek bilgisayarda çalışacak şekilde tasarlanmıştır (dosya tabanlı sistem).

## 🚀 Geliştirme Önerileri

- Filmleri silme veya güncelleme desteği eklenebilir.
- `Imdb.txt` yerine veri tabanı kullanılabilir (SQLite, SQL Server).
- Kullanıcı yetkilendirme sistemi geliştirilebilir.
- Yorumlar da dosyada saklanabilir.

---

🧑‍💻 **Geliştirici**: Yusuf Açık  
📅 **Proje Başlangıcı**: 2025  
📚 **Dil**: C#, WinForms




public class Board
{
    public List<Line> Lines { get; set; }
    public List<Uyeler> TakimUyeleri { get; set; }

    public Board()
    {
        Lines = new List<Line>
        {
            new Line("TODO"),
            new Line("IN PROGRESS"),
            new Line("DONE")
        };
        TakimUyeleri = new List<Uyeler>
        {
            new Uyeler(1,"Deniz"),
            new Uyeler(2,"Elif"),
            new Uyeler(3,"Ali")

        };
    }
    public void KartEkle(string baslik, string icerik, int atananKisiID, KartBuyukluk buyukluk)
    {
        Kart yeniKart = new Kart(baslik, icerik, atananKisiID, buyukluk);
        Lines[0].KartListesi.Add(yeniKart);

    }
    public void BoardListele()
    {
        foreach (var line in Lines)
        {
            Console.WriteLine(line.Ad + "\n********************");
            if (line.KartListesi.Count == 0)
            {
                Console.WriteLine("-BOS-");
            }
            else
            {
                foreach (var Kart in line.KartListesi)
                {
                    var TakimUyesi = TakimUyeleri.FirstOrDefault(t => t.ID == Kart.AtananKisiID);
                    Console.WriteLine($"Başlık : {Kart.Baslik}\nİçerik : {Kart.Icerik}\nAtanan Kişi : {TakimUyesi?.Ad ?? "Bilinmeyen Kişi"}\nBüyüklük : {Kart.Buyukluk}\n-");
                }
            }
        }

    }
    public void KartSil(string baslik)
    {
        var bulunanKartlar = new List<Kart>();

        foreach (var line in Lines)
        {
            var kartlar = line.KartListesi.Where(k => k.Baslik == baslik).ToList();
            if (kartlar.Any())
            {
                bulunanKartlar.AddRange(kartlar);
            }
        }

        if (bulunanKartlar.Count == 0)
        {
            Console.WriteLine("Aradığınız kritere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.");
            Console.WriteLine("* Silmeyi sonlandırmak için : (1)");
            Console.WriteLine("* Yeniden denemek için : (2)");
            int giris;
            if (int.TryParse(Console.ReadLine(), out giris))
            {
                if (giris == 1)
                {
                    return; // Silmeyi sonlandırmak için herhangi bir işlem yapmaya gerek yok.
                }
                else if (giris == 2)
                {
                    Console.WriteLine("Lütfen farklı bir kart başlığı yazınız: ");
                    string yeniBaslik = Console.ReadLine();
                    KartSil(yeniBaslik); // Yeniden deneme işlemi.
                }
                else
                {
                    Console.WriteLine("Geçersiz seçim. İşlem sonlandırılıyor.");
                }
            }
            else
            {
                Console.WriteLine("Geçersiz giriş. İşlem sonlandırılıyor.");
            }
        }
        else
        {
            foreach (var kart in bulunanKartlar)
            {
                Console.WriteLine($"Bulunan Kart Bilgileri:\n{kart}");
                Console.WriteLine("Kartı silmek için 'E' tuşuna basın, başka bir tuşa basarak işlemi iptal edin.");
                string onay = Console.ReadLine().ToUpper();

                if (onay == "E")
                {
                    foreach (var line in Lines)
                    {
                        line.KartListesi.Remove(kart);
                    }
                    Console.WriteLine("Kart başarıyla silindi.");
                }
                else
                {
                    Console.WriteLine("Kart silme işlemi iptal edildi.");
                }
            }
        }

    }
    public void KartTasi(string hedefBaslik)
    {
        var bulunanKartlar = new List<Kart>();

        foreach (var line in Lines)
        {
            var kartlar = line.KartListesi.Where(k => k.Baslik == hedefBaslik).ToList();
            if (kartlar.Any())
            {
                bulunanKartlar.AddRange(kartlar);
            }
        }

        if (bulunanKartlar.Count == 0)
        {
            Console.WriteLine("Aradığınız kritere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.");
            Console.WriteLine("* Tasima islemini sonlandırmak için : (1)");
            Console.WriteLine("* Yeniden denemek için : (2)");
            int giris1;
            if (int.TryParse(Console.ReadLine(), out giris1))
            {
                if (giris1 == 1)
                {
                    return;
                }
                else if (giris1 == 2)
                {
                    Console.WriteLine("Lütfen farklı bir kart başlığı yazınız: ");
                    string yeniBaslik = Console.ReadLine();
                    KartTasi(yeniBaslik); // Yeniden deneme işlemi.
                }
                else
                {
                    Console.WriteLine("Geçersiz seçim. İşlem sonlandırılıyor.");
                }
            }
            else
            {
                Console.WriteLine("Geçersiz giriş. İşlem sonlandırılıyor.");
            }
        }
        else
        {
            Console.WriteLine("\nBulunan Kart Bilgileri:");
            foreach (var kart in bulunanKartlar)
            {
                Console.WriteLine($"**************************************");
                Console.WriteLine($"Başlık: {kart.Baslik}");
                Console.WriteLine($"İçerik: {kart.Icerik}");
                var TakimUyesi = TakimUyeleri.FirstOrDefault(t => t.ID == kart.AtananKisiID);
                Console.WriteLine($"Atanan Kişi: {TakimUyesi?.Ad ?? "Bilinmeyen Kişi"}");
                Console.WriteLine($"Büyüklük: {kart.Buyukluk}");

                Console.WriteLine("\nLütfen taşımak istediğiniz Line'ı seçiniz: (1) TODO (2) IN PROGRESS (3) DONE");
            int kontrol;

            if (int.TryParse(Console.ReadLine(), out kontrol))
            {
                if (kontrol >= 1 && kontrol <= 3)
                {
                    string hedefLineAdi = kontrol == 1 ? "TODO" : kontrol == 2 ? "IN PROGRESS" : "DONE";
                    var hedefLine = Lines.FirstOrDefault(l => l.Ad == hedefLineAdi);
                    if (hedefLine != null)
                    {
                        foreach (var line in Lines)
                        {
                            line.KartListesi.Remove(kart); // Corrected line here
                        }
                        hedefLine.KartListesi.Add(kart);
                        Console.WriteLine("Kart başarıyla taşındı.");
                    }
                    else
                    {
                        Console.WriteLine("Hatalı bir seçim yaptınız! İşlem sonlandırılıyor.");
                    }
                }
                else
                {
                    Console.WriteLine("Geçersiz giriş. İşlem sonlandırılıyor.");
                }
            }
            else
            {
                Console.WriteLine("Geçersiz giriş. İşlem sonlandırılıyor.");
            }
        }
    }
    }
}

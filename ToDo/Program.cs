class Program
{
    static void Main(string[] args)
    {
        Board board = new Board();

        while (true)
        {
            Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz:");
            Console.WriteLine("*******************************************");
            Console.WriteLine("(1) Board Listelemek");
            Console.WriteLine("(2) Board'a Kart Eklemek");
            Console.WriteLine("(3) Board'dan Kart Silmek");
            Console.WriteLine("(4) Kart Taşımak");

            int secim = Convert.ToInt32(Console.ReadLine());

            switch (secim)
            {
                case 1:
                    board.BoardListele();
                    break;
                case 2:
                    Console.WriteLine("Başlık Giriniz: ");
                    string baslik = Console.ReadLine();

                    Console.WriteLine("İçerik Giriniz: ");
                    string icerik = Console.ReadLine();

                    Console.WriteLine("Büyüklük Seçiniz -> XS(1), S(2), M(3), L(4), XL(5): ");
                    KartBuyukluk buyukluk = (KartBuyukluk)Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Kişi Seçiniz: ");
                    int atananKisiID = Convert.ToInt32(Console.ReadLine());

                    board.KartEkle(baslik, icerik, atananKisiID, buyukluk);
                    break;
                case 3:
                    Console.WriteLine("Oncelikle silmek istediginiz karti secmeniz gerekiyor.");
                    Console.WriteLine("Lutfen kart basligini yaziniz:");
                    string GirilenBaslik = Console.ReadLine();
                    board.KartSil(GirilenBaslik);
                    break;
                case 4:
                    Console.WriteLine("Öncelikle taşımak istediğiniz kartı seçmeniz gerekiyor.");
                    Console.WriteLine("Lütfen kart başlığını yazınız: ");
                    string tasinacakKartBaslik = Console.ReadLine();
                    board.KartTasi(tasinacakKartBaslik);
                    break;

                default:
                    Console.WriteLine("Hatalı bir seçim yaptınız!");
                    break;
            }
        }
    }
}

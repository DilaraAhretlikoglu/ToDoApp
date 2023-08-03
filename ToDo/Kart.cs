public enum KartBuyukluk
{
    XS = 1,
    S,
    M,
    L,
    XL
}

public class Kart
{
    public string Baslik {get; set;}
    public string Icerik {get; set;}
    public int AtananKisiID {get; set;}
    public KartBuyukluk Buyukluk {get; set;}
    public Kart(string baslik, string icerik, int atananKisiID, KartBuyukluk buyukluk)
    {
        Baslik = baslik;
        Icerik = icerik;
        AtananKisiID = atananKisiID;
        Buyukluk = buyukluk;
    }
    
}
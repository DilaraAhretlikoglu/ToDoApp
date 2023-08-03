public class Line
{
    public string Ad {get; set;}
    public List<Kart> KartListesi {get; set;}

    public Line(string ad)
    {
        this.Ad=ad;
        KartListesi = new List<Kart>();
    }    
}
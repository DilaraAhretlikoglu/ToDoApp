public class Uyeler
{
    public string Ad { get; set; }
    public int ID { get; set; }

    public Uyeler(int id,string ad)
    {
        this.Ad=ad;
        this.ID=id;
    }
}
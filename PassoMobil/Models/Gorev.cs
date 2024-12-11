namespace PassoMobil.Models
{
    public class Gorev
    {
        public int Id { get; set; }
        public int CihazId { get; set; }
        public string Mac { get; set; }
        public bool Bulundu { get; set; }
        public string IstenilenKategori { get; set; }

        public bool Ertele { get; set; }
    }
}

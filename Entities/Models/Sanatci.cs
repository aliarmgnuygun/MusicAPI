namespace Entities.Models
{
    public class Sanatci
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public int AlbumSayisi { get; set; }
        public DateTime KurulusTarihi { get; set; }
        public ICollection<Sarki> Sarkilar { get; set; }
        public ICollection<Album> Albumler { get; set; }
    }
}

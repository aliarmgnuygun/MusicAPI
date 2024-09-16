namespace Entities.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public DateTime CikisTarihi { get; set; }
        public int SanatciId { get; set; }
        public Sanatci Sanatci { get; set; }
        public ICollection<Sarki> Sarkilar { get; set; }
    }
}

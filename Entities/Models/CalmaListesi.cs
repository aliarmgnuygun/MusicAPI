namespace Entities.Models
{
    public class CalmaListesi
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public ICollection<CalmaListesiSarkilari> CalmaListesiSarkilari { get; set; }
    }
}

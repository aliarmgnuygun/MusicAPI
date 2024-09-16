using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories.EFCore
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Sanatci> Sanatci { get; set; }
        public DbSet<Album> Album { get; set; }
        public DbSet<Sarki> Sarki { get; set; }
        public DbSet<CalmaListesi> CalmaListesi { get; set; }
        public DbSet<CalmaListesiSarkilari> CalmaListesiSarkilari { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Album>()
                .HasOne(a => a.Sanatci)         
                .WithMany(s => s.Albumler)      
                .HasForeignKey(a => a.SanatciId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Sarki>()
                .HasOne(s => s.Album)
                .WithMany(a => a.Sarkilar)
                .HasForeignKey(s => s.AlbumId)
                .OnDelete(DeleteBehavior.Restrict);  // Albüm silinmek istendiğinde şarkılar silinmemeli

          
            modelBuilder.Entity<Sarki>()
                .HasOne(s => s.Sanatci)
                .WithMany(sa => sa.Sarkilar)
                .HasForeignKey(s => s.SanatciId)
                .OnDelete(DeleteBehavior.Restrict);  // Sanatçı silinmek istendiğinde şarkılar silinmemeli
        }
    }
}
